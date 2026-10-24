
class Word
{
    private string _word;
    private bool _hidden;

    public Word(string word)
    {
        _word = word;
        _hidden = false;
    }

    public void Hide()
    {
        _hidden = true;
    }

    public bool IsHidden()
    {
        return _hidden;
    }

    public void Display()
    {
        Console.Write($"{GetWordString()} ");
    }

    public string GetWordString()
    {
        if (_hidden)
        {
            string returnString = "";
            for (int i = 0; i < _word.Length; i++)
            {
                returnString += '_';
            }
            return returnString;
        }
        else
        {
            return _word;
        }
    }
}
