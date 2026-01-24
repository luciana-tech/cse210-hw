using System;

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

    // Constructor that parses string references
    public Reference(string referenceText)
    {

        string[] parts = referenceText.Split(' ');
        
        if (parts.Length >= 2)
        {
            // Book might have spaces (e.g., "1 Nephi")
            
            _book = string.Join(" ", parts, 0, parts.Length - 1);
            
            string chapterVerse = parts[parts.Length - 1];
            string[] cvParts = chapterVerse.Split(':');
            
            if (cvParts.Length == 2)
            {
                _chapter = int.Parse(cvParts[0]);
                
                if (cvParts[1].Contains('-'))
                {
                    string[] verses = cvParts[1].Split('-');
                    _verse = int.Parse(verses[0]);
                    _endVerse = int.Parse(verses[1]);
                }
                else
                {
                    _verse = int.Parse(cvParts[1]);
                    _endVerse = null;
                }
            }
        }
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