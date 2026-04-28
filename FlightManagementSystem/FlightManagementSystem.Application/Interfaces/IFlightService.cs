using FlightManagementSystem.Application.Models.Dtos;
using FlightManagementSystem.Domain.Entities;

namespace FlightManagementSystem.Application.Interfaces
{
    public interface IFlightService
    {
        Task AddFlightAsync(AddFlightRequest request);

        Task<IEnumerable<Flight>> GetAllFlightsAsync();

        Task<object> GetFlightAsync(int flightNumber);

        Task<AddPassengerResponse> AddPassengerAsync(int flightNumber, AddPassengerRequest request);

        Task<IEnumerable<Passenger>> GetPassengersAsync(int flightNumber);
    }
}
