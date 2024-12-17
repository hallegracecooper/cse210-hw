using System;

namespace FitnessTracker
{
    public class Swimming : Activity
    {
        private int laps;
        private const double metersPerLap = 50.0;
        private const double metersToMiles = 0.000621371;

        public int Laps
        {
            get { return laps; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Number of laps cannot be negative.");
                laps = value;
            }
        }

        public Swimming(DateTime date, int length, int laps)
            : base(date, length)
        {
            this.Laps = laps;
        }

        public override double GetDistance()
        {
            double totalMeters = Laps * metersPerLap;
            return totalMeters * metersToMiles;
        }

        public override double GetSpeed()
        {
            double distance = GetDistance();
            return distance / (Length / 60.0);
        }

        public override double GetPace()
        {
            double distance = GetDistance();
            if (distance == 0)
                return 0;
            return Length / distance;
        }

        public override string GetSummary()
        {
            string baseSummary = base.GetSummary();
            return baseSummary + $", Laps: {Laps}";
        }
    }
}
