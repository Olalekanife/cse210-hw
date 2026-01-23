using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGen = new PromptGenerator();

        bool running = true;

        while (running)
        {
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");

            string choice = Console.ReadLine();
            Console.WriteLine();

            if (choice == "1")
            {
                Entry entry = new Entry();

                entry._date = DateTime.Now.ToShortDateString();
                entry._promptText = promptGen.GetRandomPrompt();

                Console.WriteLine(entry._promptText);
                Console.Write("> ");
                entry._response = Console.ReadLine();

                journal.AddEntry(entry);
            }
            else if (choice == "2")
            {
                journal.DisplayAll();
            }
            else if (choice == "3")
            {
                Console.Write("Enter the filename to load: ");
                string filename = Console.ReadLine();
                journal.LoadFromFile(filename);
            }
            else if (choice == "4")
            {
                Console.Write("Enter the filename to save: ");
                string filename = Console.ReadLine();
                journal.SaveToFile(filename);
            }
            else if (choice == "5")
            {
                running = false;
            }
            else
            {
                Console.WriteLine("Invalid option. Try again.");
            }

            Console.WriteLine();
        }
    }
}
