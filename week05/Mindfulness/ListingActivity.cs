using System;
using System.Collections.Generic;

// ListingActivity class that inherits from Activity
public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "What are things that give you hope for the future?",
        "What are acts of kindness you've witnessed or received?",
        "What are your favorite memories from childhood?",
        "What are things you love about your current season of life?",
        "What are simple pleasures you enjoy daily?",
        "What are goals you've accomplished recently?",
        "Who are mentors that have helped shape who you are?",
        "What are things you're looking forward to?",
        "What are your favorite personal traditions or rituals?",
        "What are ways you've grown emotionally or spiritually?"
    };
    
    private List<string> _usedPrompts = new List<string>();
    private int _count;
    
    public ListingActivity() : base(
        "Listing",
        "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area."
    ) { }
    
    public void Run()
    {
        DisplayStartingMessage();
        
        Console.Clear();
        Console.WriteLine("Get ready...");
        ShowSpinner(3);
        
        // Display random prompt
        string prompt = GetRandomPrompt();
        Console.WriteLine();
        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.WriteLine($"--- {prompt} ---");
        Console.Write("You may begin in: ");
        ShowCountDown(5);
        
        Console.WriteLine();
        Console.WriteLine("Start listing:");
        
        _count = 0;
        List<string> items = GetListFromUser();
        _count = items.Count;
        
        Console.WriteLine();
        Console.WriteLine($"You listed {_count} items!");
        
        DisplayEndingMessage();
        
        // Log activity
        ActivityLogger.LogActivity("Listing", _duration, _count);
    }
    
    public string GetRandomPrompt()
    {
        // If all prompts have been used, reset the used list
        if (_usedPrompts.Count >= _prompts.Count)
        {
            _usedPrompts.Clear();
        }
        
        Random random = new Random();
        string selectedPrompt;

        // Keep selecting until we find an unused prompt
        do
        {
            selectedPrompt = _prompts[random.Next(_prompts.Count)];
        } while (_usedPrompts.Contains(selectedPrompt));
        
        _usedPrompts.Add(selectedPrompt);
        return selectedPrompt;
    }
    
    public List<string> GetListFromUser()
    {
        List<string> items = new List<string>();
        
        
        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        
        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string item = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(item))
            {
                items.Add(item);
            }
        }

        return items;
    }
}