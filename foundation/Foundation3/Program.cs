using System;
using System.Collections.Generic;

namespace FitnessTracker
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Activity> activities = new List<Activity>();

            Running run = new Running(new DateTime(2022, 11, 3), 30, 3.0);
            Cycling cycle = new Cycling(new DateTime(2022, 11, 4), 45, 15.0);
            Swimming swim = new Swimming(new DateTime(2022, 11, 5), 60, 40);

            activities.Add(run);
            activities.Add(cycle);
            activities.Add(swim);

            foreach (Activity activity in activities)
            {
                Console.WriteLine(activity.GetSummary());
            }
        }
    }
}
