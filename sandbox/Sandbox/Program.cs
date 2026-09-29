// using System;

// class Program
// {
//     static void Main(string[] args)
//     {
        
//         int x = 10;
//         int y = 20;
//         int z = 30;

//         if (x == 10 || y == 21 && z == 30)
//         {
//             Console.WriteLine("X is 10");
//             Console.WriteLine("Y is fun");
//         }
//         else if (x == 20)
//         {
//             Console.WriteLine("We are in else if");

//         }
//         else
//         {
//             Console.WriteLine("Z is not much fun");

//         }

//     }
// }

//  bool done = false;
//     while (! done)
//     {
//         Console.Write("Are we done? (y/n): ");
//         done = Console.ReadLine().ToLower() == "y";
//     }


// bool done;

// do
// {
//     Console.Write("Are we done? (y/n): ");
//     done = Console.ReadLine().ToLower() == "y";
// } while (!done);

using System;

class Program
{
    static double AddNumbers(double x, int y)
    {
        return x + y;
    }
    static void DisplayGreeting(string name)
    {
        Console.WriteLine($"Welcome {name}, pelased to meet you.");
    }
     static void Main(string[] args)
    {
        
        DisplayGreeting("Bob");
        double answer = AddNumbers(12.234, 10);
        Console.WriteLine(answer);

        // for(int i = 0; i < 10000; i+=500)
        // {
        //     Console.Write($"i -");
        //     Console.WriteLine("Hey Bob");
        // }
        
        
        
        // List<string> myFriends = ["Bob", "Betty", "Bubba"];
        // List<string> names = new List<string>();
        // myFriends.Add("Jean");
        // myFriends.Add("Doug");


        // foreach(string name in myFriends)
        // {
        //     Console.WriteLine(name);
        // }
    }
}

//classes and object - each cake is an instance of my recipe. I can make 100 objects from 1 class.
// Class ia a template, objects are instances. Classes have data and functions. You combine them into 1 type
//class contains chunks of attributes and methods. The atrrributes are the state of our object
//class - int - object - x - int x
//you need class diagrams for assignments / 1. Class name 2. Attributes 3. Methods
//class is the actual code.
