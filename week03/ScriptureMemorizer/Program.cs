using System;
class Program
{
    static void Main(string[] args)
    {
        // Create scripture using required constructor
        Reference reference = new Reference("John", 3, 16);
        
        Scripture scripture = new Scripture(reference, 
            "For God so loved the world that he gave his one and only Son, " +
            "that whoever believes in him shall not perish but have eternal life.");
        
        while (!scripture.IsCompletelyHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\n\nPress ENTER to continue or type 'quit' to finish: ");
            
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
                break;
            
            scripture.HideRandomWords(3); // Hide three random words
        }
    }
}