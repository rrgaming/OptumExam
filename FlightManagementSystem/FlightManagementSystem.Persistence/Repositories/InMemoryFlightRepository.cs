using FlightManagementSystem.Domain.Entities;
using FlightManagementSystem.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementSystem.Infrastructure.Repositories
{
    public class InMemoryFlightRepository : IFlightRepository
    {
        private readonly List<Flight> _flights = new();

        public Task AddAsync(Flight flight)
        {
            _flights.Add(flight);
            return Task.CompletedTask;
        }

        public Task<Flight?> GetAsync(int flightNumber)
            => Task.FromResult(_flights.FirstOrDefault(f => f.FlightNumber == flightNumber));

        public Task<List<Flight>> GetAllAsync()
            => Task.FromResult(_flights);
    }
}
