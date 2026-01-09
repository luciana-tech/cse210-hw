using System;

class Program
{
    //Main function
    static void Main(string[] args)
    {
        DisplayWelcomeMessage();

        string userName = PromptUserName();
        int userNumber = PromptUserNumber();

        int squaredNumber = SquaredNumber(userNumber);

        DisplayResult(userName, squaredNumber);
    }

    // Function 1: Display a welcome message
    static void DisplayWelcomeMessage()
    {
        Console.WriteLine("Welcome to the program!");
    }

    // Function 2: Prompt the user for their name
    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        return Console.ReadLine();

    }

    // Function 3: Prompt the user for their favorite number
    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        int number = int.Parse(Console.ReadLine());
        return number;
    }

    // Function 4: Square the number
    static int SquaredNumber(int number)
    {
        return number * number;
    }

    // Function 5: Display the final result
    static void DisplayResult(string name, int squaredNumber)
    {
        Console.WriteLine($"{name}, the square of your number is {squaredNumber}");
    }
}