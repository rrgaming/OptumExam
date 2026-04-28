using FlightManagementSystem.Domain.Entities;

namespace FlightManagementSystem.Infrastructure.Interfaces
{
    public interface IFlightRepository
    {
        Task AddAsync(Flight flight);
        Task<Flight?> GetAsync(int flightNumber);
        Task<List<Flight>> GetAllAsync();
    }
}
