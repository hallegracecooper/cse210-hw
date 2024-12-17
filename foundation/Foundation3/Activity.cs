using System;

namespace FitnessTracker
{
    public abstract class Activity
    {
        private DateTime date;
        private int length;

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        public int Length
        {
            get { return length; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Length cannot be negative.");
                length = value;
            }
        }

        public Activity(DateTime date, int length)
        {
            this.Date = date;
            this.Length = length;
        }

        public abstract double GetDistance();
        public abstract double GetSpeed();
        public abstract double GetPace();

        public virtual string GetSummary()
        {
            string activityType = this.GetType().Name;
            return $"{Date.ToString("dd MMM yyyy")} {activityType} ({Length} min) - " +
                   $"Distance: {GetDistance():0.0} miles, " +
                   $"Speed: {GetSpeed():0.0} mph, " +
                   $"Pace: {GetPace():0.00} min per mile";
        }
    }
}
