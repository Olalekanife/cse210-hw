using System;

class Program
{
    //Ask the user for their name
    static void Main(string[] args)
    {
        Console.Write("What is your first name? ");
        string first = Console.Readline();

        Console.Write("What is your last name? ");
        string last = Console.ReadLine();

        Console.Writeline($"Your name is {last}, {first} {last}");

    }
}