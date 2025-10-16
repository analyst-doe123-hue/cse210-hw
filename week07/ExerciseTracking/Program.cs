using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create a list of activities (demonstrating polymorphism)
        List<Activity> activities = new List<Activity>();

        activities.Add(new Running(new DateTime(2022, 11, 3), 30, 3.0));  // 3 miles
        activities.Add(new Cycling(new DateTime(2022, 11, 3), 45, 12.0)); // 12 mph
        activities.Add(new Swimming(new DateTime(2022, 11, 3), 25, 15));  // 15 laps

        // Iterate and display summaries (polymorphic behavior)
        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
