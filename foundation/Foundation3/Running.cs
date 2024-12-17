using System;

namespace FitnessTracker
{
    public class Running : Activity
    {
        private double distance;

        public double Distance
        {
            get { return distance; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Distance cannot be negative.");
                distance = value;
            }
        }

        public Running(DateTime date, int length, double distance)
            : base(date, length)
        {
            this.Distance = distance;
        }

        public override double GetDistance()
        {
            return Distance;
        }

        public override double GetSpeed()
        {
            return Distance / (Length / 60.0);
        }

        public override double GetPace()
        {
            if (Distance == 0)
                return 0;
            return Length / Distance;
        }
    }
}
