/* class journalEntry
{
    public string _date;
    public string _prompt;

    public string _response;
    public void DisplayEntry()
    {
        Console.Write($"{_date}, ");
        Console.WriteLine($"{_prompt}, ");
        Console.WriteLine($"{_response}, ");
    }
    
    public void CreateJournalEntry()
    {
        _date = "October 7, 2026";
        _prompt = "How was your day? ";
            
        Console.Write($"{_prompt}");
        _response = Console.ReadLine();
    }


} */
using System;

public class Entry
{
    public string _date;
    public string _promptText;
    public string _entryText;

    public void Display()
    {
        Console.WriteLine($"Date: {_date} - Prompt: {_promptText}");
        Console.WriteLine($"{_entryText}\n");
    }
}