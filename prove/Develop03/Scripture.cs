
using System;
using System.Collections.Generic;

class Scripture
{
    private List<Word> _words;
    private ScriptureReference _reference;

    public Scripture(string bookName, int chapter, int verse, string text)
    {
        _words = ConvertToWords(text);
        _reference = new ScriptureReference(bookName, chapter, verse);
    }

    public Scripture(string bookName, int chapter, int startVerse, int endVerse, string text)
    {
        _words = ConvertToWords(text);
        _reference = new ScriptureReference(bookName, chapter, startVerse, endVerse);
    }

    public void ShowScripture()
    {
        Console.WriteLine(_reference.GetDisplayText());

        foreach (Word word in _words)
        {
            word.Display();
        }

        Console.WriteLine();
    }

    public void HideRandomWords(Random random, int numberToHide)
    {
        int wordsHidden = 0;

        while (wordsHidden < numberToHide && !IsCompletelyHidden())
        {
            int randomIndex = random.Next(_words.Count);

            if (!_words[randomIndex].IsHidden())
            {
                _words[randomIndex].Hide();
                wordsHidden++;
            }
        }
    }

    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }

        return true;
    }

    private List<Word> ConvertToWords(string text)
    {
        List<Word> tempWords = new List<Word>();

        string[] words = text.Split(
            ' ',
            StringSplitOptions.RemoveEmptyEntries
        );

        foreach (string word in words)
        {
            Word tempWord = new Word(word);
            tempWords.Add(tempWord);
        }

        return tempWords;
    }
}
