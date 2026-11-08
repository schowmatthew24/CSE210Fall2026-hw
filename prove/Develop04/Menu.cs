using System;
using System.Collections.Generic;
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