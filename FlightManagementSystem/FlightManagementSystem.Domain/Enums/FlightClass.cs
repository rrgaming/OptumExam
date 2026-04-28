using System.Text.Json.Serialization;

namespace FlightManagementSystem.Domain.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum FlightClass
    {
        First,
        Business,
        Economy
    }
}
