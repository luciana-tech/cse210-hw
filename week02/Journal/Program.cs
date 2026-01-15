using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Journal Program!");
        Console.WriteLine("Test classes.");

        Journal journal = new Journal();
        Entry entry = new Entry();
        PromptGenerator promptGenerator = new PromptGenerator();

        Console.WriteLine("Stub version, all classes created successfully.");
        Console.WriteLine("Program compiled without errors."); 
    }
}