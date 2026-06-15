using System;
using System.Collections.Generic;

namespace ExerciseTracking
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            List<Activity> activities = new()
            {
                new Running(new DateTime(2024, 11, 3), 30, 3.0),
                new Cycling(new DateTime(2024, 11, 4), 45, 12.0),
                new Swimming(new DateTime(2024, 11, 5), 20, 10)
            };

            foreach (Activity activity in activities)
            {
                Console.WriteLine(activity.GetSummary());
            }
        }
    }
}
