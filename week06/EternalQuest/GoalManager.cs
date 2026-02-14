using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;
    private string _filePath;
    private LevelSystem _levelSystem;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
        _filePath = "";
        _levelSystem = new LevelSystem(); // Initialize the level system
    }

    public void Start()
    {
        Console.WriteLine("Welcome to the Eternal Quest Program!\n");

        bool running = true;
        while (running)
        {
            DisplayPlayerInfo();
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoalDetails();
                    break;
                case "3":
                    SaveGoals();
                    break;
                case "4":
                    LoadGoals();
                    break;
                case "5":
                    RecordEvent();
                    break;
                case "6":
                    running = false;
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        // Update level system with current score
        _levelSystem.UpdateLevel(_score);
        
        // Display both score and rank information
        Console.WriteLine($"You have {_score} points.");
        Console.WriteLine($"🏆 {_levelSystem.GetRankInfo()}");
    }

    private string GetFilenameFromUser()
    {
        Console.Write("Enter the filename to save/load your goals (will add .txt if not specified): ");
        string filename = Console.ReadLine().Trim();
        
        if (string.IsNullOrEmpty(filename))
        {
            Console.WriteLine("Filename cannot be empty.\n");
            return null;
        }

        // Add .txt extension if not present
        if (!filename.EndsWith(".txt", StringComparison.OrdinalIgnoreCase))
        {
            filename += ".txt";
        }

        // Check if the filename contains invalid characters
        char[] invalidChars = Path.GetInvalidFileNameChars();
        bool hasInvalidChars = false;
        foreach (char c in filename)
        {
            if (Array.IndexOf(invalidChars, c) >= 0)
            {
                hasInvalidChars = true;
                break;
            }
        }

        if (hasInvalidChars)
        {
            Console.WriteLine("Filename contains invalid characters. Please try again.\n");
            return null;
        }

        return filename;
    }

    public void ListGoalNames()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals created yet.\n");
            return;
        }

        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetName()}");
        }
        Console.WriteLine();
    }

    public void ListGoalDetails()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals created yet.\n");
            return;
        }

        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
        Console.WriteLine();
    }

    public void CreateGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        
        string goalType = Console.ReadLine();
        
        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        
        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();
        
        Console.Write("What is the amount of points associated with this goal? ");
        if (!int.TryParse(Console.ReadLine(), out int points))
        {
            Console.WriteLine("Invalid points value. Goal not created.\n");
            return;
        }

        switch (goalType)
        {
            case "1":
                SimpleGoal simpleGoal = new SimpleGoal(name, description, points);
                _goals.Add(simpleGoal);
                Console.WriteLine("Simple goal created successfully!\n");
                break;
                
            case "2":
                EternalGoal eternalGoal = new EternalGoal(name, description, points);
                _goals.Add(eternalGoal);
                Console.WriteLine("Eternal goal created successfully!\n");
                break;
                
            case "3":
                Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                if (!int.TryParse(Console.ReadLine(), out int target))
                {
                    Console.WriteLine("Invalid target value. Goal not created.\n");
                    return;
                }
                
                Console.Write("What is the bonus for accomplishing it that many times? ");
                if (!int.TryParse(Console.ReadLine(), out int bonus))
                {
                    Console.WriteLine("Invalid bonus value. Goal not created.\n");
                    return;
                }
                
                ChecklistGoal checklistGoal = new ChecklistGoal(name, description, points, target, bonus);
                _goals.Add(checklistGoal);
                Console.WriteLine("Checklist goal created successfully!\n");
                break;
                
            default:
                Console.WriteLine("Invalid goal type.\n");
                break;
        }
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals to record events for.\n");
            return;
        }

        ListGoalNames();
        Console.Write("Which goal did you accomplish? ");
        
        if (!int.TryParse(Console.ReadLine(), out int goalIndex))
        {
            Console.WriteLine("Invalid input.\n");
            return;
        }
        
        goalIndex -= 1; // Convert to zero-based index

        if (goalIndex >= 0 && goalIndex < _goals.Count)
        {
            Goal goal = _goals[goalIndex];
            
            // Check if goal is already complete (except for eternal goals)
            if (goal.IsComplete() && !(goal is EternalGoal))
            {
                Console.WriteLine("This goal is already complete!\n");
                return;
            }
            
            int pointsEarned = goal.GetPoints();
            int oldScore = _score;
            goal.RecordEvent();
            
            // Add bonus points for checklist goals if completed
            if (goal is ChecklistGoal checklistGoal && checklistGoal.IsComplete())
            {
                pointsEarned += checklistGoal.GetBonus();
                Console.WriteLine($"*** BONUS! You earned an extra {checklistGoal.GetBonus()} points! ***");
            }
            
            _score += pointsEarned;
            
            // Check for level up!
            int oldLevel = _levelSystem.GetLevel();
            _levelSystem.UpdateLevel(_score);
            int newLevel = _levelSystem.GetLevel();
            
            Console.WriteLine($"Congratulations! You have earned {pointsEarned} points!");
            Console.WriteLine($"You now have {_score} points.\n");
            
            // Celebrate level up if it happened
            if (newLevel > oldLevel)
            {
                Console.WriteLine($"⭐ ⭐ ⭐ LEVEL UP! ⭐ ⭐ ⭐");
                Console.WriteLine($"You are now Level {newLevel} - {_levelSystem.GetTitle()}!");
                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine("Invalid goal number.\n");
        }
    }

    public void SaveGoals()
    {
        // Ask for filename if not set yet
        if (string.IsNullOrEmpty(_filePath))
        {
            string filename = GetFilenameFromUser();
            if (filename == null)
            {
                return; // User gave invalid filename
            }
            _filePath = filename;
        }
        else
        {
            // If filename already set, ask if user wants to use the same file or different one
            Console.WriteLine($"Current save file: {_filePath}");
            Console.Write("Use this file? (y/n): ");
            string response = Console.ReadLine().Trim().ToLower();
            
            if (response == "n" || response == "no")
            {
                string filename = GetFilenameFromUser();
                if (filename == null)
                {
                    return; // User gave invalid filename
                }
                _filePath = filename;
            }
        }

        using (StreamWriter writer = new StreamWriter(_filePath))
        {
            writer.WriteLine(_score);
            foreach (Goal goal in _goals)
            {
                writer.WriteLine(goal.GetStringsRepresentation());
            }
        }
        Console.WriteLine($"Goals saved successfully to {_filePath}!\n");
    }

    public void LoadGoals()
    {
        // Ask for filename if not set yet
        if (string.IsNullOrEmpty(_filePath))
        {
            string filename = GetFilenameFromUser();
            if (filename == null)
            {
                return; // User gave invalid filename
            }
            _filePath = filename;
        }
        else
        {
            // If filename already set, ask if user wants to use the same file or different one
            Console.WriteLine($"Current save file: {_filePath}");
            Console.Write("Use this file? (y/n): ");
            string response = Console.ReadLine().Trim().ToLower();
            
            if (response == "n" || response == "no")
            {
                string filename = GetFilenameFromUser();
                if (filename == null)
                {
                    return; // User gave invalid filename
                }
                _filePath = filename;
            }
        }

        if (!File.Exists(_filePath))
        {
            Console.WriteLine($"File {_filePath} not found.\n");
            return;
        }

        string[] lines = File.ReadAllLines(_filePath);
        
        if (lines.Length == 0)
        {
            Console.WriteLine("File is empty.\n");
            return;
        }

        _goals.Clear();
        
        // First line is the score
        if (int.TryParse(lines[0], out int loadedScore))
        {
            _score = loadedScore;
            _levelSystem.UpdateLevel(_score);
        }
        else
        {
            Console.WriteLine("Error reading score from file.\n");
            return;
        }
        
        // Load goals from remaining lines
        for (int i = 1; i < lines.Length; i++)
        {
            string line = lines[i];
            if (string.IsNullOrWhiteSpace(line))
                continue;
                
            string[] parts = line.Split(':');
            if (parts.Length < 2)
                continue;
                
            string goalType = parts[0];
            string[] goalData = parts[1].Split(',');
            
            switch (goalType)
            {
                case "SimpleGoal":
                    if (goalData.Length >= 4)
                    {
                        SimpleGoal simpleGoal = new SimpleGoal(
                            goalData[0], 
                            goalData[1], 
                            int.Parse(goalData[2]), 
                            bool.Parse(goalData[3]));
                        _goals.Add(simpleGoal);
                    }
                    break;
                    
                case "EternalGoal":
                    if (goalData.Length >= 3)
                    {
                        EternalGoal eternalGoal = new EternalGoal(
                            goalData[0], 
                            goalData[1], 
                            int.Parse(goalData[2]));
                        _goals.Add(eternalGoal);
                    }
                    break;
                    
                case "ChecklistGoal":
                    if (goalData.Length >= 6)
                    {
                        ChecklistGoal checklistGoal = new ChecklistGoal(
                            goalData[0],                          // name
                            goalData[1],                          // description
                            int.Parse(goalData[2]),                // points
                            int.Parse(goalData[4]),                // target
                            int.Parse(goalData[3]),                // bonus
                            int.Parse(goalData[5]));                // amountCompleted
                        _goals.Add(checklistGoal);
                    }
                    break;
            }
        }
        
        Console.WriteLine($"Goals loaded successfully from {_filePath}!\n");
    }
}