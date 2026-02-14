using System;

class Program
{

    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\n--- Eternal Quest Menu ---");
            Console.WriteLine("1. Create Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. Display Score & Badges");
            Console.WriteLine("5. Save Goals");
            Console.WriteLine("6. Load Goals");
            Console.WriteLine("7. Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoal(manager);
                    break;
                case "2":
                    manager.DisplayGoals();
                    break;
                case "3":
                    Console.Write("Enter goal number to record: ");
                    if (int.TryParse(Console.ReadLine(), out int idx))
                        manager.RecordEvent(idx - 1);
                    break;
                case "4":
                    manager.DisplayScore();
                    break;
                case "5":
                    manager.SaveGoals("goals.txt");
                    break;
                case "6":
                    manager.LoadGoals("goals.txt");
                    break;
                case "7":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }

    static void CreateGoal(GoalManager manager)
    {
        Console.WriteLine("Choose Goal Type:");
        Console.WriteLine("1. SimpleGoal");
        Console.WriteLine("2. EternalGoal");
        Console.WriteLine("3. ChecklistGoal");
        Console.WriteLine("4. NegativeGoal");
        string type = Console.ReadLine();

        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();
        Console.Write("Enter description: ");
        string desc = Console.ReadLine();
        Console.Write("Enter points: ");
        int points = int.Parse(Console.ReadLine());

        switch (type)
        {
            case "1":
                manager.AddGoal(new SimpleGoal(name, desc, points));
                break;
            case "2":
                manager.AddGoal(new EternalGoal(name, desc, points));
                break;
            case "3":
                Console.Write("Enter target completions: ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("Enter bonus points: ");
                int bonus = int.Parse(Console.ReadLine());
                manager.AddGoal(new ChecklistGoal(name, desc, points, target, bonus));
                break;
            case "4":
                manager.AddGoal(new NegativeGoal(name, desc, points));
                break;
            default:
                Console.WriteLine("Invalid goal type.");
                return;
        }

        Console.WriteLine("Goal created");
    }
}
