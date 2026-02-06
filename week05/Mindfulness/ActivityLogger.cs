using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public static class ActivityLogger
{
    private static string logFile = "activity_log.txt";
    private static Dictionary<string, int> activityCounts = new Dictionary<string, int>();
    
    public static void LogActivity(string activityName, int duration, int additionalData = 0)
    {
        // This overload accepts 2 or 3 parameters
        if (!activityCounts.ContainsKey(activityName))
        {
            activityCounts[activityName] = 0;
        }
        activityCounts[activityName]++;
        
        string logEntry = $"{DateTime.Now}: {activityName} - {duration} seconds";
        if (additionalData > 0)
        {
            logEntry += $", Items: {additionalData}";
        }
        
        File.AppendAllText(logFile, logEntry + Environment.NewLine);
    }
    
    public static void DisplayLogSummary()
    {
        Console.Clear();
        Console.WriteLine("Activity Statistics");
        Console.WriteLine("===================");
        Console.WriteLine();
        
        if (File.Exists(logFile))
        {
            string[] lines = File.ReadAllLines(logFile);
            Console.WriteLine($"Total activities logged: {lines.Length}");
            Console.WriteLine();
            
            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }
        }
        else
        {
            Console.WriteLine("No activities logged yet.");
        }
        
        Console.WriteLine();
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
    
    public static void LoadLog()
    {
        if (File.Exists(logFile))
        {
            string[] lines = File.ReadAllLines(logFile);
            foreach (string line in lines)
            {
                if (line.Contains("Breathing"))
                {
                    UpdateCount("Breathing");
                }
                else if (line.Contains("Reflecting") || line.Contains("Reflection"))
                {
                    UpdateCount("Reflection");
                }
                else if (line.Contains("Listing"))
                {
                    UpdateCount("Listing");
                }
            }
        }
    }
    
    public static void ClearLog()
    {
        if (File.Exists(logFile))
        {
            File.Delete(logFile);
            activityCounts.Clear();
            Console.WriteLine("\nActivity log has been cleared.");
        }
        else
        {
            Console.WriteLine("\nNo activity log found to clear.");
        }
    }
    
    private static void UpdateCount(string activityName)
    {
        if (!activityCounts.ContainsKey(activityName))
        {
            activityCounts[activityName] = 0;
        }
        activityCounts[activityName]++;
    }
}