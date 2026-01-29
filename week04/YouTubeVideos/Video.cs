using System;
using System.Collections.Generic;

public class Video
{
    public string _title;
    public string _author;
    public int _length;
    public List<Comment> _comments = new List<Comment>();

    // Method to return number of comments
    public int GetNumberOfComments()
    {
        return _comments.Count;
    }

    // Method to display all videos and comments
    public void Display()
    {
        Console.WriteLine($"Video title: {_title}");
        Console.WriteLine($"Author: {_author}");
        Console.WriteLine($"Length in seconds: {_length}");
        Console.WriteLine($"Number of comments: {GetNumberOfComments()}");
        Console.WriteLine("Comments:");
        
        foreach (Comment comment in _comments)
        {
            Console.WriteLine($"  {comment.GetFormatted()}");
        }
        Console.WriteLine();
    }
}