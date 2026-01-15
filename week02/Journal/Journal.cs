using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
 public List<Entry> _entries = new List<Entry>();
 public void AddEntry(Entry newEntry)

    {
        _entries.Add(newEntry);
        Console.WriteLine("Journal.AddEntry() - Entry added.");
    }
 public void DisplayAll()
    {
        Console.WriteLine("Journal.DisplayAll()");
        Console.WriteLine("Journal entries to be displayed here.");
    }   
 public void SaveToFile(string file)
    {
        Console.WriteLine($"Journal.SaveToFile() - File: {file}");
    }
    
public void LoadFromFile(string file)
    {
        Console.WriteLine($"Jounal.LoadFromFile() - File: {file}");
    }
}

