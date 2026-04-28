using FlightManagementSystem.Application.Interfaces;
using FlightManagementSystem.Application.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace FlightManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightsController : ControllerBase
    {
        private readonly IFlightService _flightService;

        public FlightsController(IFlightService service)
        {
            _flightService = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _flightService.GetAllFlightsAsync();
            return Ok(result);
        }

        [HttpGet("{flightNumber}")]
        public async Task<IActionResult> Get(int flightNumber)
        {
            var result = await _flightService.GetFlightAsync(flightNumber);
            return Ok(result);
        }

        [HttpGet("{flightNumber}/passengers")]
        public async Task<IActionResult> GetPassengers(int flightNumber)
        {
            var result = await _flightService.GetPassengersAsync(flightNumber);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddFlight(AddFlightRequest request)
        {
            await _flightService.AddFlightAsync(request);
            return Ok();
        }

        [HttpPost("{flightNumber}/passengers")]
        public async Task<IActionResult> AddPassenger(int flightNumber, AddPassengerRequest request)
        {
            var result = await _flightService.AddPassengerAsync(flightNumber, request);
            return Ok(result);
        }
    }
}
