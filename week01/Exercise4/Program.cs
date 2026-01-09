using System;

class Program
{
    static void Main(string[] args)
        {
        List<int> numbers = new List<int>();
        int userInput;

        Console.WriteLine("Enter a list of numbers. Type 0 to finish:");

        // Input loop
        do
        {
            Console.Write("Enter number: ");
            userInput = int.Parse(Console.ReadLine());

            if (userInput != 0)
            {
                numbers.Add(userInput);
            }

        } while (userInput != 0);

        // Check if any numbers were entered
        if (numbers.Count == 0)
        {
            Console.WriteLine("No numbers entered.");
            return;
        }

        // Core Requirement 1: Compute sum
        int sum = 0;
        foreach (int num in numbers)
        {
            sum += num;
        }

        // Core Requirement 2: Compute average
         float average = ((float)sum) / numbers.Count;

        // Core Requirement 3: Find maximum
        int max = numbers[0];  // Start by assuming the first number is the largest
        foreach (int num in numbers)
        {
            if (num > max)
            {
                max = num;
            }
        }

        // Display results
        Console.WriteLine($"\nThe sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The maximum number is: {max}");
    }
}

