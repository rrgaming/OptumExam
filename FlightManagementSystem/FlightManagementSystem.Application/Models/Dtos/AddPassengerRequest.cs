using FlightManagementSystem.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace FlightManagementSystem.Application.Models.Dtos
{
    public class AddPassengerRequest
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string PassengerId { get; set; }

        [Required]
        public FlightClass Class { get; set; }

        [Required]
        public decimal TicketPrice { get; set; }

        [Required]
        public int NumberOfBags { get; set; }

        [Required]
        public double TotalBaggageWeight { get; set; }
    }
}
