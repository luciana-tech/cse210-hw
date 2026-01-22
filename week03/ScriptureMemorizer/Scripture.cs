using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _random;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        _random = new Random();
        
        // Split text into words and create Word objects
        string[] wordArray = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        foreach (string word in wordArray)
        {
            _words.Add(new Word(word));
        }
    }

    public void HideRandomWords(int numberToHide)
    {
        
        var visibleWords = _words.Where(w => !w.IsHidden()).ToList();
        
        // If there are fewer visible words than requested, hide all remaining
        int wordsToHide = Math.Min(numberToHide, visibleWords.Count);
        
        for (int i = 0; i < wordsToHide; i++)
        {
            int index = _random.Next(visibleWords.Count);
            
            // Find the original index of the word in the _words list
            Word wordToHide = visibleWords[index];
            visibleWords.RemoveAt(index);
            wordToHide.Hide();
        }
    }
    
    
    public string GetDisplayText()
    {
        string displayText = _reference.GetDisplayText() + "\n\n";
        
        foreach (Word word in _words)
        {
            displayText += word.GetDisplayText() + " ";
        }
        
        return displayText.Trim();
    }
    
        public bool IsCompletelyHidden()
    {
        return _words.All(word => word.IsHidden());
    }
}
