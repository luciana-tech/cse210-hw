using System;
using System.Collections.Generic;

// This program demonstrates an exercise tracking application that uses inheritance and polymorphism.
// It defines a base class 'Activity' and derived classes 'Running', 'Cycling', and 'Swimming'.
// Each activity calculates distance, speed, and pace based on its specific parameters.
// The main program creates a list of activities, displays their summaries, and also shows detailed calculations for verification (this last feature exceeds requirements).
class Program
{
    static void Main(string[] args)
    {
        // Create activities
        List<Activity> activities = new List<Activity>();

        // Running activity
        activities.Add(new Running(
            new DateTime(2022, 11, 3), 
            30, 
            3.0 // 3 miles
        ));

        // Cycling activity
        activities.Add(new Cycling(
            new DateTime(2022, 11, 3), 
            45, 
            12.0 // 12 mph
        ));

        // Swimming activity
        activities.Add(new Swimming(
            new DateTime(2022, 11, 4), 
            60, 
            40 // 40 laps (40 * 50m = 2000m = 2km ≈ 1.24 miles)
        ));

        // Additional activity to show more variety
        activities.Add(new Running(
            new DateTime(2022, 11, 5), 
            45, 
            4.5 // 4.5 miles
        ));

        // Display summaries for all activities
        Console.WriteLine("Exercise Tracking Summary");
        Console.WriteLine("=========================\n");

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }

        // Exceeding requirement: Display detailed calculations for verification
        Console.WriteLine("\nDetailed Calculations:");
        Console.WriteLine("======================");
        
        foreach (Activity activity in activities)
        {
            Console.WriteLine($"\n{activity.GetType().Name} on {activity.GetDate():dd MMM yyyy}:");
            Console.WriteLine($"  Minutes: {activity.GetMinutes()}");
            Console.WriteLine($"  Distance: {activity.GetDistance():F2} miles");
            Console.WriteLine($"  Speed: {activity.GetSpeed():F2} mph");
            Console.WriteLine($"  Pace: {activity.GetPace():F2} min/mile");
        }
    }
}