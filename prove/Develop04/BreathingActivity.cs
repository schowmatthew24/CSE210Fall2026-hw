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