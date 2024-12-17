using System;

namespace FitnessTracker
{
    public class Cycling : Activity
    {
        private double speed;

        public double SpeedValue
        {
            get { return speed; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Speed cannot be negative.");
                speed = value;
            }
        }

        public Cycling(DateTime date, int length, double speed)
            : base(date, length)
        {
            this.SpeedValue = speed;
        }

        public override double GetDistance()
        {
            return SpeedValue * (Length / 60.0);
        }

        public override double GetSpeed()
        {
            return SpeedValue;
        }

        public override double GetPace()
        {
            if (SpeedValue == 0)
                return 0;
            return 60.0 / SpeedValue;
        }
    }
}
