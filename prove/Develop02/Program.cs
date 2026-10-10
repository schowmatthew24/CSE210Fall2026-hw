using System;

class Program
{
    static void Main(string[] args)
    {
        // Exceeding Requirements Note:
        // Used a custom string delimiter '~|~' in save/load functionality to handle user responses containing commas and quotes without breaking the file structure.

        Journal journal = new Journal();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\nPlease select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    journal.AddEntry();
                    break;
                case "2":
                    journal.DisplayAll();
                    break;
                case "3":
                    Console.Write("What is the filename? ");
                    string loadFile = Console.ReadLine();
                    journal.LoadFromFile(loadFile);
                    break;
                case "4":
                    Console.Write("What is the filename? ");
                    string saveFile = Console.ReadLine();
                    journal.SaveToFile(saveFile);
                    break;
                case "5":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid selection. Please enter a number from 1 to 5.");
                    break;
            }
        }
    }
}