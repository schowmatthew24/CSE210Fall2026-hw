class BaseActivity
{
    private string _name;
    private string _description;
    protected int _duration;

    public BaseActivity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name}.\n");
        Console.WriteLine(_description + "\n");
        Console.Write("Enter the duration of the activity in seconds: ");
        _duration = int.Parse(Console.ReadLine());

        Console.Clear();
        Console.WriteLine("Get ready...");
        DisplaySpinnerMessage("Preparing", 3);
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine("\nWell done!!");
        DisplaySpinnerMessage("Wrapping up", 3);
        Console.WriteLine($"\nYou have completed another {_duration} seconds of the {_name}.");
        DisplaySpinnerMessage("Finishing", 3);
    }

    public void RunCountdownMessage(string message, int seconds)
    {
        Console.CursorVisible = false;
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"\r{message} {i}   ");
            Thread.Sleep(1000);
        }
        Console.CursorVisible = true;
    }

    public void DisplaySpinnerMessage(string message, int seconds)
    {
        Console.Write($"{message} ");
        List<string> spinnerSymbols = new List<string> { "|", "/", "-", "\\" };
        
        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(seconds);

        int i = 0;
        while (DateTime.Now < futureTime)
        {
            string s = spinnerSymbols[i];
            Console.Write(s);
            Thread.Sleep(250);
            Console.Write("\b \b");
            i = (i + 1) % spinnerSymbols.Count;
        }
        Console.WriteLine();
    }

    public virtual void RunActivity()
    {
        // To be overridden by derived classes
    }
}