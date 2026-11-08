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