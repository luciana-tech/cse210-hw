// Stretch challenge: only select from words that aren't hidden
// Load scriptures from file: scriptures.txt
// Option to load from a file or use default
// Option to choose specific scripture or get random

using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Scripture Memorizer ===\n");
        
        // Offer to load from file
        Console.Write("Would you like to load scriptures from file? (y/n): ");
        string loadChoice = Console.ReadLine();
        
        Scripture scripture;
        
        if (loadChoice.ToLower() == "y")
        {
            // Try to load from file
            List<Scripture> loadedScriptures = LoadScripturesFromFile("scriptures.txt");
            
            if (loadedScriptures.Count > 0)
            {
                // Let user choose or get random
                Console.WriteLine($"\nLoaded {loadedScriptures.Count} scriptures.");
                Console.Write("Enter a number (1 for random, 2 to choose): ");
                string selection = Console.ReadLine();
                
                if (selection == "2" && loadedScriptures.Count > 1)
                {
                    // Show available scriptures
                    Console.WriteLine("\nAvailable Scriptures:");
                    for (int i = 0; i < loadedScriptures.Count; i++)
                    {
                        string display = loadedScriptures[i].GetDisplayText();
                        string reference = display.Split('\n')[0];
                        Console.WriteLine($"{i + 1}. {reference}");
                    }
                    
                    Console.Write($"\nSelect scripture (1-{loadedScriptures.Count}): ");
                    if (int.TryParse(Console.ReadLine(), out int choice) && 
                        choice >= 1 && choice <= loadedScriptures.Count)
                    {
                        scripture = loadedScriptures[choice - 1];
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice. Selecting random.");
                        scripture = GetRandomScripture(loadedScriptures);
                    }
                }
                else
                {
                    // Get random scripture
                    scripture = GetRandomScripture(loadedScriptures);
                }
                
                Console.WriteLine($"\nSelected: {scripture.GetDisplayText().Split('\n')[0]}");
                Console.WriteLine("Press Enter to begin memorization...");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("No scriptures loaded. Using default.");
                scripture = CreateDefaultScripture();
            }
        }
        else
        {
            // Use default scripture
            scripture = CreateDefaultScripture();
        }
        
        // Loop until scripture is complete or user quits
        while (!scripture.IsCompletelyHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            
            Console.WriteLine("\n\nPress ENTER to continue or type 'quit' to finish: ");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
                return;
            
            scripture.HideRandomWords(3);
        }
        
        // Show final hidden state once
        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());
        // Program ends immediately after showing final state
    }
    
    static List<Scripture> LoadScripturesFromFile(string filename)
    {
        List<Scripture> scriptures = new List<Scripture>();
        
        // Check if file exists
        if (!File.Exists(filename))
        {
            Console.WriteLine($"File '{filename}' not found.");
            return scriptures; // Return empty list
        }
        
        // Read all lines from file
        string[] lines = File.ReadAllLines(filename);
        int loadedCount = 0;
        
        foreach (string line in lines)
        {
            // Skip empty lines
            if (string.IsNullOrWhiteSpace(line))
                continue;
            
            // Format should be: "Reference|Text"
            string[] parts = line.Split('|');
            
            // Need exactly 2 parts (reference and text)
            if (parts.Length != 2)
                continue;
            
            string referenceText = parts[0].Trim();
            string scriptureText = parts[1].Trim();
            
            // Skip if reference or text is empty
            if (string.IsNullOrEmpty(referenceText) || string.IsNullOrEmpty(scriptureText))
                continue;
            
            // Create Reference object - handle parsing errors
            Reference reference = null;
            if (IsValidReference(referenceText))
            {
                reference = new Reference(referenceText);
            }
            else
            {
                continue;
            }
            
            // Create Scripture object
            Scripture scripture = new Scripture(reference, scriptureText);
            scriptures.Add(scripture);
            loadedCount++;
        }
        
        if (loadedCount > 0)
        {
            Console.WriteLine($"Successfully loaded {loadedCount} scriptures.");
        }
        else
        {
            Console.WriteLine("No valid scriptures found in file.");
        }
        
        return scriptures;
    }
    
    static bool IsValidReference(string referenceText)
    {
        // Basic validation: reference should contain a space and a colon
        return referenceText.Contains(" ") && referenceText.Contains(":");
    }
    
    static Scripture GetRandomScripture(List<Scripture> scriptures)
    {
        if (scriptures.Count == 0)
            return CreateDefaultScripture();
        
        Random random = new Random();
        int index = random.Next(scriptures.Count);
        return scriptures[index];
    }
    
    static Scripture CreateDefaultScripture()
    {
        Reference reference = new Reference("John", 3, 16);
        return new Scripture(reference, 
            "For God so loved the world that he gave his one and only Son, " +
            "that whoever believes in him shall not perish but have eternal life.");
    }
}