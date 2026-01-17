// Exceeds requirements:
// Created several prompts and categorized them so users can choose from a list of categories when WRITE option is selected
// Included alert signal to be displayed when load file is empty
// Process writing of a new entry in fancy format to improve user experience  
using System;

class Program
{
    static void Main(string[] args)
    {
        // Set console encoding for proper character display
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        bool running = true;

        // Display welcome message
        Console.WriteLine("Welcome to the Journal Program!");

        // Main program loop
        while (running)
        {
            // Get user choice
            Console.WriteLine("\nPlease select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");

            Console.Write("\nWhat would you like to do? ");
            string choice = Console.ReadLine();
            
            // Process user choice
            switch (choice)
            {
                case "1": // Write
                    WriteNewEntryWithCategories(journal, promptGenerator);
                    break;

                case "2": // Display journal
                    journal.DisplayAll();
                    break;

                case "3": // Load
                    Console.Write("Enter filename to load: ");
                    string loadFile = Console.ReadLine();
                    journal.LoadFromFile(loadFile);
                    break;

                case "4": // Save
                    Console.Write("Enter filename to save: ");
                    string saveFile = Console.ReadLine();
                    journal.SaveToFile(saveFile);
                    break;

                case "5": // Quit
                    Console.WriteLine("\nGoodbye!");
                    running = false;
                    break;

                default: // Invalid choice
                    Console.WriteLine("Invalid choice. Enter 1-5."); 
                    break;    
            } 
        }
    }
    
    // Method with category selection
    // Process writing of a new entry in fancy format to improve user experience
    static void WriteNewEntryWithCategories(Journal journal, PromptGenerator promptGenerator)
    {
        Console.WriteLine("\n" + new string('─', 40));
        Console.WriteLine("        WRITE NEW ENTRY");
        Console.WriteLine(new string('─', 40));
        
        // Menu prompt category
        Console.WriteLine("\nChoose a prompt category:");
        Console.WriteLine("1. Faith & Discipleship");
        Console.WriteLine("2. Challenges & Growth");
        Console.WriteLine("3. Gratitude & Positivity");
        Console.WriteLine("4. Self-Care & Well-Being");
        Console.WriteLine("5. Goals & Achievements");
        Console.WriteLine("6. Relationships & Service");
        Console.WriteLine("7. Reflection & Future");
        Console.WriteLine("8. Random (any category)");
        
        Console.Write("\nSelect category (1-8): ");
        string categoryChoice = Console.ReadLine();
        
        string prompt;
        bool showPrompt = true; // Flag to control prompt display

        if (int.TryParse(categoryChoice, out int categoryNumber))
        {
            if (categoryNumber >= 1 && categoryNumber <= 7)
            {
                // Gets prompt from chosen category
                prompt = promptGenerator.GetRandomPromptByCategoryNumber(categoryNumber);
                string categoryName = promptGenerator.GetCategoryName(categoryNumber);
                Console.WriteLine($"\nCategory: {categoryName}");
            }
            else if (categoryNumber == 8)
            {
                // Display random prompt 
                prompt = promptGenerator.GetRandomPrompt();
                Console.WriteLine($"\nRandom prompt selected");
            }
            else
            {
                // Invalid category, use random
                prompt = promptGenerator.GetRandomPrompt();
                Console.WriteLine($"\nInvalid category, using random prompt");
            }
        }
        else
        {
            // Non-numeric choice, uses random
            prompt = promptGenerator.GetRandomPrompt();
            Console.WriteLine($"\nInvalid input, using random prompt");
        }
        
        // Display the prompt
        Console.WriteLine($"\nPrompt: {prompt}");
        
        // Continue normal writing process
        Console.Write("\nYour response: ");
        string response = Console.ReadLine();
        
        // Validate response
        if (string.IsNullOrWhiteSpace(response))
        {
            Console.WriteLine("\n✗ Entry not saved. Response cannot be empty.");
            return;
        }
        
        // Create new entry
        Entry newEntry = new Entry();
        newEntry._date = DateTime.Now.ToShortDateString();
        newEntry._promptText = prompt;
        newEntry._entryText = response;
        
        // Add entry to the Journal
        journal.AddEntry(newEntry);
        Console.WriteLine("\n✓ Entry added successfully!");
    }
}