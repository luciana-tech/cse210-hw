using System;

public class Comment

// Attributes
{
    public string _commentAuthor;
    public string _commentText;

// Constructor
public Comment(string author, string text)
    {
        _commentAuthor = author;
        _commentText = text;
    } 

// Method to display comment
// Get formatted comment as a string
public string GetFormatted()
    {
       return $"{_commentAuthor} said: \"{_commentText}\"";
    }
      
}