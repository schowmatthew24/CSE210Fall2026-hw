using System;
using System.Collections.Generic;
using System.Threading;

// ==========================================
// EXCEEDING REQUIREMENTS NOTE:
// This program keeps a running session log tracker 
// that records how many times each activity has been 
// performed during the current execution and displays 
// a summary report when quitting the application.
// ==========================================

class Program
{
    static void Main(string[] args)
    {
        Menu menu = new Menu();
        menu.DisplayMenu();
    }
}

class Menu
{
    private Dictionary<string, int> _activityCounts = new Dictionary<string, int>()
    {
        { "Breathing Activity", 0 },
        { "Reflection Activity", 0 },
        { "Listing Activity", 0 }
    };

    public void DisplayMenu()
    {
        bool running = true;
        while (running)
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflection activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Quit");
            Console.Write("Select a choice from the menu: ");
            
            string choice = Console.ReadLine();

            BaseActivity activity = null;
            string activityKey = "";

            if (choice == "1")
            {
                activity = new BreathingActivity();
                activityKey = "Breathing Activity";
            }
            else if (choice == "2")
            {
                activity = new ReflectionActivity();
                activityKey = "Reflection Activity";
            }
            else if (choice == "3")
            {
                activity = new ListingActivity();
                activityKey = "Listing Activity";
            }
            else if (choice == "4")
            {
                running = false;
                Console.Clear();
                Console.WriteLine("Session Summary (Exceeding Requirements - Activity Log):");
                foreach (KeyValuePair<string, int> entry in _activityCounts)
                {
                    Console.WriteLine($" - {entry.Key}: Completed {entry.Value} time(s)");
                }
                Console.WriteLine("\nThank you for using the Mindfulness Program. Goodbye!");
                Thread.Sleep(2000);
            }
            else
            {
                Console.WriteLine("\nInvalid choice. Please press Enter to try again.");
                Console.ReadLine();
                continue;
            }

            if (activity != null)
            {
                activity.RunActivity();
                _activityCounts[activityKey]++;
            }
        }
    }
}

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

class BreathingActivity : BaseActivity
{
    public BreathingActivity() : base("Breathing Activity", 
        "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    public override void RunActivity()
    {
        DisplayStartingMessage();

        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(_duration);

        while (DateTime.Now < futureTime)
        {
            Console.Write("\nBreathe in...");
            RunCountdownMessage("", 4);
            Console.WriteLine();
            
            if (DateTime.Now >= futureTime) break;

            Console.Write("Breathe out...");
            RunCountdownMessage("", 6);
            Console.WriteLine();
        }

        DisplayEndingMessage();
    }
}

class ReflectionActivity : BaseActivity
{
    private List<string> _prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectionActivity() : base("Reflection Activity", 
        "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
    }

    public override void RunActivity()
    {
        DisplayStartingMessage();

        Random random = new Random();
        Console.WriteLine("\nConsider the following prompt:\n");
        Console.WriteLine($"--- {_prompts[random.Next(_prompts.Count)]} ---\n");
        Console.Write("When you have something in mind, press enter to continue: ");
        Console.ReadLine();

        Console.Clear();
        Console.WriteLine("Now ponder on each of the following questions as they related to this experience.");
        DisplaySpinnerMessage("You may begin in", 3);

        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(_duration);

        while (DateTime.Now < futureTime)
        {
            string question = _questions[random.Next(_questions.Count)];
            Console.Write($"\n> {question} ");
            DisplaySpinnerMessage("", 5);
        }

        DisplayEndingMessage();
    }
}

class ListingActivity : BaseActivity
{
    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity() : base("Listing Activity", 
        "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
    }

    public override void RunActivity()
    {
        DisplayStartingMessage();

        Random random = new Random();
        Console.WriteLine("\nList as many responses you can to the following prompt:");
        Console.WriteLine($"--- {_prompts[random.Next(_prompts.Count)]} ---\n");
        
        DisplaySpinnerMessage("You may begin in", 5);

        List<string> userItems = new List<string>();
        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(_duration);

        while (DateTime.Now < futureTime)
        {
            Console.Write("> ");
            if (Console.KeyAvailable)
            {
                string item = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(item))
                {
                    userItems.Add(item);
                }
            }
            else
            {
                Thread.Sleep(100);
            }

            if (DateTime.Now >= futureTime)
            {
                break;
            }
        }

        Console.WriteLine($"\nYou listed {userItems.Count} items!");
        DisplayEndingMessage();
    }
}