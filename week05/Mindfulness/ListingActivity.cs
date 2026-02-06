using System;

using System.Runtime.CompilerServices;
// ListingActivity class that inherits from Activity
public class ListingActivity : Activity
    {
        private List<string> _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };
        
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
            Random random = new Random();
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
        }
        
        public string GetRandomPrompt()
        {
            Random random = new Random();
            return _prompts[random.Next(_prompts.Count)];
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