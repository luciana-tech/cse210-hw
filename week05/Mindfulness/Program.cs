using System;
using System.Threading;

// Exceeding requirements: Keeping a log of how many times activities were performed. 
// Logs are saved in a file and loaded from ActivityLoggers. User can view log summary or clear log from menu. 
// No random prompts/questions are selected until they have all been used at least once in that session.

// Main program class

class Program
{
    static void Main(string[] args)
    {
       while (true)
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1 - Start breathing activity");
            Console.WriteLine("  2 - Start reflecting activity");
            Console.WriteLine("  3 - Start listing activity");
            Console.WriteLine("  4 - View activity statistics");
            Console.WriteLine("  5 - Clear activity log");
            Console.WriteLine("  6 - Quit");
            Console.WriteLine();
            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();

            
            switch (choice)
                {
                    case "1":
                        BreathingActivity breathing = new BreathingActivity();
                        breathing.Run();
                        break;
                        
                    case "2":
                        ReflectingActivity reflection = new ReflectingActivity();
                        reflection.Run();
                        break;
                        
                    case "3":
                        ListingActivity listing = new ListingActivity();
                        listing.Run();
                        break;

                    case "4":
                        ActivityLogger.DisplayLogSummary();    
                        break;  

                    case "5":
                        Console.Write("Are you sure you want to clear all activity logs? (y/n): ");
                        string confirm = Console.ReadLine().ToLower();
                        if (confirm == "y" || confirm == "yes")
                        {
                            ActivityLogger.ClearLog();
                        }
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;

                    case "6":
                        Console.WriteLine();
                        Console.WriteLine("Thank you for using the Mindfulness App. Have a peaceful day!");
                        return;
                        
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        Thread.Sleep(2000);
                        break;
            }
        }
    }
}