using FlightManagementSystem.Domain.Enums;

namespace FlightManagementSystem.Application.Helpers
{
    public class FlightClassRules
    {
        public int MinSeat { get; }
        public int MaxSeat { get; }
        public int MaxBags { get; }
        public double MaxWeight { get; }

        public FlightClassRules(int minSeat, int maxSeat, int maxBags, double maxWeight)
        {
            MinSeat = minSeat;
            MaxSeat = maxSeat;
            MaxBags = maxBags;
            MaxWeight = maxWeight;
        }
    }

    public static class FlightRulesHelper
    {
        public static FlightClassRules GetRules(FlightClass cls)
        {
            return cls switch
            {
                FlightClass.First => new FlightClassRules(1, 5, 2, 30),
                FlightClass.Business => new FlightClassRules(21, 50, 2, 20),
                FlightClass.Economy => new FlightClassRules(51, 200, 1, 20),
                _ => throw new ArgumentOutOfRangeException(nameof(cls))
            };
        }
    }
}
