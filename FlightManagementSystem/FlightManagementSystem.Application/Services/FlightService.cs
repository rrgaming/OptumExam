using FlightManagementSystem.Application.Helpers;
using FlightManagementSystem.Application.Interfaces;
using FlightManagementSystem.Application.Models;
using FlightManagementSystem.Application.Models.Dtos;
using FlightManagementSystem.Domain.Entities;
using FlightManagementSystem.Domain.Enums;
using FlightManagementSystem.Infrastructure.Interfaces;

namespace FlightManagementSystem.Application.Services
{
    public class FlightService : IFlightService
    {
        private readonly IFlightRepository _repo;

        public FlightService(IFlightRepository repo)
        {
            _repo = repo;
        }

        public async Task AddFlightAsync(AddFlightRequest request)
        {
            var existing = await _repo.GetAsync(request.FlightNumber);

            // Duplicate flight — cannot add a flight with an existing flight number
            if (existing != null)
                throw new ApiException("DuplicateFlight", "Flight already exists");

            var flight = new Flight
            {
                FlightNumber = request.FlightNumber,
                Destination = request.Destination
            };

            await _repo.AddAsync(flight);
        }

        public async Task<IEnumerable<Flight>> GetAllFlightsAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<object> GetFlightAsync(int flightNumber)
        {
            var flight = await _repo.GetAsync(flightNumber);
            if (flight == null)
                throw new ApiException("FlightNotFound", "Flight not found");

            return new
            {
                flight.FlightNumber,
                flight.Destination,
                totalPassengers = flight.Passengers.Count,
                availableSeats = new
                {
                    first = 20 - flight.Passengers.Count(p => p.Class == FlightClass.First),
                    business = 30 - flight.Passengers.Count(p => p.Class == FlightClass.Business),
                    economy = 150 - flight.Passengers.Count(p => p.Class == FlightClass.Economy)
                }
            };
        }

        public async Task<AddPassengerResponse> AddPassengerAsync(int flightNumber, AddPassengerRequest request)
        {
            var flight = await _repo.GetAsync(flightNumber);

            //Flight existence — cannot add a passenger to a non-existent flight
            if (flight == null)
                throw new ApiException("FlightNotFound", "Flight does not exist");

            //Duplicate passenger — same passengerId cannot be added to the same flight twice
            if (flight.Passengers.Any(p => p.PassengerId == request.PassengerId))
                throw new ApiException("DuplicatePassenger", "Passenger already exists");

            var flightRules = FlightRulesHelper.GetRules(request.Class);

            // Baggage validation — number of bags and total weight must comply with the class rules
            if (request.NumberOfBags > flightRules.MaxBags ||
                request.TotalBaggageWeight > flightRules.MaxWeight)
            {
                throw new ApiException(
                    "BaggageExceeded",
                    $"{request.Class} allows maximum {flightRules.MaxBags} bags with total weight of {flightRules.MaxWeight} kg. " +
                    $"Provided: {request.NumberOfBags} bags, {request.TotalBaggageWeight} kg."
                );
            }

            // Seat availability — the requested class must have at least one available seat
            var usedSeats = flight.Passengers
                .Where(p => p.Class == request.Class)
                .Select(p => p.SeatNumber)
                .ToHashSet();

            // if seat is 1 - 5, then total seat should be 5 - 1 + 1 = 5,
            // if seat is 21 - 50, then total seat should be 50 - 21 + 1 = 30,
            var totalSeats = flightRules.MaxSeat - flightRules.MinSeat + 1;
            var seat = Enumerable.Range(flightRules.MinSeat, totalSeats)
                .FirstOrDefault(s => !usedSeats.Contains(s));

            if (seat == 0)
                throw new ApiException("NoSeatsAvailable", "No seats available in this class");

            var passenger = new Passenger
            {
                PassengerId = request.PassengerId,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Class = request.Class,
                TicketPrice = request.TicketPrice,
                NumberOfBags = request.NumberOfBags,
                TotalBaggageWeight = request.TotalBaggageWeight,
                SeatNumber = seat
            };

            flight.Passengers.Add(passenger);

            return new AddPassengerResponse
            {
                SeatNumber = seat,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Class = request.Class.ToString(),
                Message = "Passenger added successfully"
            };
        }

        public async Task<IEnumerable<Passenger>> GetPassengersAsync(int flightNumber)
        {
            var flight = await _repo.GetAsync(flightNumber);
            if (flight == null)
                throw new ApiException("FlightNotFound", "Flight not found");

            return flight.Passengers;
        }
    }
}
