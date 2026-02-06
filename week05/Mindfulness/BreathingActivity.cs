using System;

// BreathingActivity class that inherits from Activity
public class BreathingActivity : Activity
{
    public BreathingActivity() : base(
        "Breathing",
            "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing."
        ) { }
    public void Run()
    {
        DisplayStartingMessage();
        Console.Clear();
        Console.WriteLine("Get ready to begin the Breathing Activity...");
        ShowSpinner(3);

        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.WriteLine();
            Console.Write("Breathe in... ");
            ShowCountDown(4);

            Console.WriteLine();
            Console.Write("Breathe out... ");
            ShowCountDown(6);
        }
        DisplayEndingMessage();
        // Log activity
        ActivityLogger.LogActivity("Breathing", _duration);
    }
}
