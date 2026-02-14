using System;

// Main entry point for the Eternal Quest program
// This program allows users to create and manage goals, track their progress, and level up based on their score. 
// Exceeding requirements: The LevelSystem class manages the user's level and rank titles based on their score.
// Current rank and level displayed with user score;
// Show next rank and points needed to reach it;
class Program
{
    static void Main(string[] args)
    {   
        GoalManager goalManager = new GoalManager();
        goalManager.Start();
    }
}