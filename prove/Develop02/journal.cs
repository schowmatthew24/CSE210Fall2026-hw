using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    private List<string> _prompts = new List<string>()
    {
        "Who was the most interesting person I interacted with today?",
        "Who is someone you would love to see right now?",
        "What is yout go to place for food?",
        "What was the funnest activity of my day?",
        "If you had to pick anywhere for a vacation, where would you go?"
    };

    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        
        return _prompts[index];
    }

    public void AddEntry()
    {
        string prompt = GetRandomPrompt();
        Console.WriteLine($"\n{prompt}");
        Console.Write("> ");
        string response = Console.ReadLine();

        string date = DateTime.Now.ToShortDateString();

        Entry newEntry = new Entry
        {
            _date = date,
            _promptText = prompt,
            _entryText = response
        };

        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        Console.WriteLine();
        if (_entries.Count == 0)
        {
            Console.WriteLine("No journal entries to display.");
            return;
        }

        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string file)  // you make your own file everytime and you can type 3 to make it load and you can type that  file to load what you have typed.
    {
        using (StreamWriter outputFile = new StreamWriter(file))
        {
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine($"{entry._date}~|~{entry._promptText}~|~{entry._entryText}");
            }
        }
        Console.WriteLine("Journal saved successfully.");
    }

    public void LoadFromFile(string file)
    {
        if (!File.Exists(file))
        {
            Console.WriteLine("File not found.");
            return;
        }

        _entries.Clear();

        string[] lines = File.ReadAllLines(file);
        foreach (string line in lines)
        {
            string[] parts = line.Split("~|~");
            if (parts.Length == 3)
            {
                Entry entry = new Entry
                {
                    _date = parts[0],
                    _promptText = parts[1],
                    _entryText = parts[2]
                };
                _entries.Add(entry);
            }
        }
        Console.WriteLine("Journal loaded successfully.");
    }
}