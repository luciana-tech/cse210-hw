using System;
using System.Security.Cryptography;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What is your grade percentage? ");
        string answer = Console.ReadLine();
        int percent = int.Parse(answer);

        string letter = "";

        if (percent >= 90)
        {
            letter = "A";
        } 
        else if (percent >= 80)
        {
            letter = "B";
        }
         else if (percent >= 70)
        {
            letter = "C";
        }
         else if (percent >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }
        Console.WriteLine($"Ÿour grade is {letter}");

        if (percent>=70)
        {
            Console.WriteLine("Congratulations, you passed!");
        }  
        else
        {
            Console.WriteLine("Keep trying!");
        }  
    }
        
}