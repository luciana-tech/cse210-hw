using System;

// ReflectionActivity class that inherits from Activity
public class ReflectingActivity : Activity
    {
        private List<string> _prompts = new List<string>
        {
           "Think of a time when you overcame a challenge.",
            "Recall a moment when you felt truly at peace.",
            "Reflect on a recent accomplishment you're proud of.",
            "Consider a time when you helped someone in need."
        };
        
        private List<string> _questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };
        
        public ReflectingActivity() : base(
            "Reflecting",
            "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life."
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
            Console.WriteLine("Consider the following prompt:");
            Console.WriteLine();
            Console.WriteLine($"--- {prompt} ---");
            Console.WriteLine();
            Console.WriteLine("When you have something in mind, press Enter to continue.");
            Console.ReadLine();
            
            Console.WriteLine("Now ponder on each of the following questions as they relate to this experience.");
            Console.Write("You may begin in: ");
            ShowCountDown(5);
            
            Console.Clear();
            DateTime endTime = DateTime.Now.AddSeconds(_duration);
            
            while (DateTime.Now < endTime)
            {
                string question = GetRandomQuestion();
                Console.Write($"> {question} ");
                ShowSpinner(10);
                Console.WriteLine();
            }
            
            // Count questions answered
            int questionsAnswered = 0;

            DisplayEndingMessage();
            // Log activity 
            ActivityLogger.LogActivity("Reflection", _duration, questionsAnswered);
        }
        
        public string GetRandomPrompt()
        {
            Random random = new Random();
            return _prompts[random.Next(_prompts.Count)];
        }
        
        public string GetRandomQuestion()
        {
            Random random = new Random();
            return _questions[random.Next(_questions.Count)];
        }
        
        public void DisplayPrompt()
        {
            string prompt = GetRandomPrompt();
            Console.WriteLine($"Prompt: {prompt}");
        }
        
       public void DisplayQuestions()
        {
            foreach (string question in _questions)
            {
                Console.WriteLine($"Question: {question}");
            }
        }
    }