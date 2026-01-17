using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    // Attributes: List of entries
    public List<Entry> _entries = new List<Entry>();
    
    // Method: Add new entry
    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }
    
    // Method: Display all entries
    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries in the journal");
            return;
        }

        Console.WriteLine("\n=== Journal Entries ===\n");
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }
    
    // Method: Save to file
    public void SaveToFile(string filename)
    {
        if (!filename.EndsWith(".txt", StringComparison.OrdinalIgnoreCase))
    {
        filename += ".txt";
    }
        // Check if there are entries to save
        if (_entries.Count == 0)
        {
            Console.WriteLine(" No entries to save. Write some entries first!");
            return;
        }
        
        try
        {
            using (StreamWriter outputFile = new StreamWriter(filename))
            {
                foreach (Entry entry in _entries)
                {
                    // Uses ~|~ as a separator
                    outputFile.WriteLine($"{entry._date}~|~{entry._promptText}~|~{entry._entryText}");
                }
            }
            Console.WriteLine($"✓ Journal saved to {filename}");
            Console.WriteLine($"  Entries saved: {_entries.Count}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"✗ Error saving file: {ex.Message}");
        }
    }
    
    // Method: Load from file 
    public void LoadFromFile(string filename)
    {
        // Check if file exists before clearing entries
        if (!File.Exists(filename))
        {
            Console.WriteLine($"✗ File '{filename}' not found.");
            Console.WriteLine("  Your current entries were NOT affected.");
            return;
        }
        
        // Check if file is empty
        FileInfo fileInfo = new FileInfo(filename);
        if (fileInfo.Length == 0)
        {
            Console.WriteLine($"⚠️  File '{filename}' is empty.");
            Console.WriteLine("  Your current entries were NOT affected.");
            return;
        }
        
        // Reads looking for errors
        string[] lines;
        try
        {
            lines = File.ReadAllLines(filename);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"✗ Error reading file: {ex.Message}");
            Console.WriteLine("  Your current entries were NOT affected.");
            return;
        }
        
        // Check if file contains data
        if (lines.Length == 0)
        {
            Console.WriteLine($"⚠️  File '{filename}' contains no data.");
            Console.WriteLine("  Your current entries were NOT affected.");
            return;
        }
        
        // Count valid entries
        int validEntriesInFile = 0;
        foreach (string line in lines)
        {
            if (!string.IsNullOrWhiteSpace(line))
            {
                string[] parts = line.Split("~|~");
                if (parts.Length >= 3)
                {
                    validEntriesInFile++;
                }
            }
        }
        
        // If file does nto have valid entries
        if (validEntriesInFile == 0)
        {
            Console.WriteLine($"⚠️  File '{filename}' has no valid journal entries.");
            Console.WriteLine("  Your current entries were NOT affected.");
            return;
        }
        
        // Ask if there is unsaved entries
        if (_entries.Count > 0)
        {
            Console.Write($"\n⚠️  You have {_entries.Count} unsaved entries. ");
            Console.Write("Loading will replace them. Continue? (y/n): ");
            
            string confirm = Console.ReadLine();
            if (confirm.ToLower() != "y" && confirm.ToLower() != "yes")
            {
                Console.WriteLine("Load cancelled.");
                return;
            }
        }
        
        // Backup of current entries
        List<Entry> backupEntries = new List<Entry>(_entries);
        int originalCount = _entries.Count;
        
        // Clear and tries to load
        _entries.Clear();
        int loadedCount = 0;
        
        foreach (string line in lines)
        {
            // Skip empty lines
            if (string.IsNullOrWhiteSpace(line))
                continue;
                
            string[] parts = line.Split("~|~");
            
            if (parts.Length >= 3)
            {
                Entry loadedEntry = new Entry();
                loadedEntry._date = parts[0];
                loadedEntry._promptText = parts[1];
                loadedEntry._entryText = parts[2];
                
                _entries.Add(loadedEntry);
                loadedCount++;
            }
        }
        
        // Checks if successfully loaded
        if (loadedCount > 0)
        {
            Console.WriteLine($"\n✓ Journal loaded successfully!");
            Console.WriteLine($"  File: {filename}");
            Console.WriteLine($"  Entries loaded: {loadedCount}");
            
            if (originalCount > 0)
            {
                Console.WriteLine($"  Previous {originalCount} entries were replaced.");
            }
        }
        else
        {
            // If fails, backup restores
            _entries = backupEntries;
            Console.WriteLine($"\n✗ Failed to load valid entries from '{filename}'.");
            Console.WriteLine($"  Your {originalCount} entries were restored.");
        }
    }
}