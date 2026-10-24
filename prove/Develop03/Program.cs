
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create a list of scriptures
        List<Scripture> scriptures = new List<Scripture>();

        scriptures.Add(new Scripture(
            "Moses",
            1,
            39,
            "For behold, this is my work and my glory to bring to pass the immortality and eternal life of man."
        ));

        scriptures.Add(new Scripture(
            "3 Nephi",
            27,
            20,
            "Now this is the commandment: Repent, all ye ends of the earth, and come unto me and be baptized in my name, that ye may be sanctified by the reception of the Holy Ghost, that ye may stand spotless before me at the last day."
        ));

        scriptures.Add(new Scripture(
            "James",
            1,
            5,
            "If any of you lack wisdom, let him ask of God, that giveth to all men liberally, and upbraideth not; and it shall be given him."
        ));

        // Randomly select one scripture
        Random random = new Random();

        int randomIndex = random.Next(scriptures.Count);
        Scripture selectedScripture = scriptures[randomIndex];

        // Begin the memorization activity
        while (true)
        {
            Console.Clear();

            selectedScripture.ShowScripture();

            // Stop when every word has been hidden
            if (selectedScripture.IsCompletelyHidden())
            {
                Console.WriteLine();
                Console.WriteLine("All words have been hidden. Great job!");
                break;
            }

            Console.WriteLine();
            Console.WriteLine("Press Enter to hide two random words.");
            Console.WriteLine("Type 'quit' to exit the program.");

            string input = Console.ReadLine();

            if (input != null &&
                input.Trim().Equals("quit", StringComparison.OrdinalIgnoreCase))
            {
                break;
            }
            selectedScripture.HideRandomWords(random, 2);
        }
    }
}

