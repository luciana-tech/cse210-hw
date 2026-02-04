using System;

class Program
{
    static void Main(string[] args)

    {
        Assignment assignment1 = new Assignment();
        assignment1.SetStudentName("Luciana Oliveira");
        assignment1.SetTopic("Factoring");

        Console.WriteLine(assignment1.GetSummary());
        Console.WriteLine();

        MathAssignment assignment2 = new MathAssignment();
        assignment2.SetStudentName("Roberto Silva");
        assignment2.SetTopic("Fractions");
        assignment2.SetTextbookSection("2.3");
        assignment2.SetProblems("8-19");

        Console.WriteLine(assignment2.GetHomeworkList());
        Console.WriteLine();
        
        WritingAssignment assignment3 = new WritingAssignment();
        assignment3.SetStudentName("Ana Costa");
        assignment3.SetTitle("The Mystery of the Lost Key");
        Console.WriteLine(assignment3.GetWritingInformation());
    }
}