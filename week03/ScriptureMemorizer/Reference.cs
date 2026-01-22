using System;
using System.Collections.Concurrent;
using System.Data;

public class Reference
{
    private string _book;
    private int _chapter;
    private int _verse;
    private int? _endVerse;

    // Constructor for single verse
    public Reference(string book, int chapter, int verse)
    {
       _book = book;
       _chapter = chapter;
       _verse = verse;
       _endVerse = null; 
    }

    // Constructor for verse range
    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _verse = startVerse;
        _endVerse = endVerse; 
    }

   public string GetDisplayText()
    {
        if (_endVerse.HasValue)
        {
            return $"{_book} {_chapter}:{_verse}-{_endVerse}";
        }
        else
        {
            return $"{_book} {_chapter}:{_verse}";
        }
    }
}


