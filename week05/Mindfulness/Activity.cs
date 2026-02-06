using System;
using System.Collections.Generic;
using System.Threading;

// Base Activity class
public class Activity
{
    // Class attributes
    protected string _name;
    protected string _description;
    protected int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void DisplayStartingMessage()
    {
            Console.Clear();
            Console.WriteLine($"Welcome to the {_name} Activity.");
            Console.WriteLine();
            Console.WriteLine(_description);
            Console.WriteLine();
            Console.Write("How long, in seconds, would you like for your session? ");
            _duration = int.Parse(Console.ReadLine());
            
            Console.WriteLine();
            Console.WriteLine("Prepare to begin...");
            ShowSpinner(3);
        }
        
        public void DisplayEndingMessage()
        {
            Console.WriteLine();
            Console.WriteLine("Well done!");
            ShowSpinner(3);
            Console.WriteLine();
            Console.WriteLine($"You have completed the {_name} Activity for {_duration} seconds.");
            ShowSpinner(3);
        }
        
        protected void ShowSpinner(int seconds)
        {
            List<string> animation = new List<string> { "|", "/", "-", "\\" };
            DateTime endTime = DateTime.Now.AddSeconds(seconds);
            
            while (DateTime.Now < endTime)
            {
                foreach (string frame in animation)
                {
                    Console.Write(frame);
                    Thread.Sleep(250);
                    Console.Write("\b \b");
                }
            }
        }
        
        protected void ShowCountDown(int seconds)
        {
            for (int i = seconds; i > 0; i--)
            {
                Console.Write(i);
                Thread.Sleep(1000);
                Console.Write("\b \b");
            }
        }
        protected int GetDuration()
        {
            return _duration;
        }

}        