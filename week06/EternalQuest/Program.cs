using System;

namespace EternalQuest
{
    internal class Program
    {
        private static readonly GoalManager _manager = new("quest_save.txt");

        private static void Main(string[] args)
        {
            // Creative extras in this version: a simple level system and a streak bonus
            // for every third recorded action, which goes beyond the core requirements.
            Console.WriteLine("Welcome to Eternal Quest!");
            Console.WriteLine("Your mission is to complete goals, earn points, and level up.");

            _manager.LoadProgress();

            bool keepGoing = true;
            while (keepGoing)
            {
                Console.WriteLine();
                Console.WriteLine("==============================");
                Console.WriteLine("1. View goals");
                Console.WriteLine("2. Create a new goal");
                Console.WriteLine("3. Record an event");
                Console.WriteLine("4. Save progress");
                Console.WriteLine("5. Load saved progress");
                Console.WriteLine("6. Quit");
                Console.WriteLine("==============================");
                _manager.DisplayScore();
                Console.Write("Choose an option: ");

                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        _manager.DisplayGoals();
                        break;
                    case "2":
                        CreateGoal();
                        break;
                    case "3":
                        RecordGoal();
                        break;
                    case "4":
                        _manager.SaveProgress();
                        break;
                    case "5":
                        _manager.LoadProgress();
                        break;
                    case "6":
                        keepGoing = false;
                        Console.WriteLine("Thanks for playing Eternal Quest!");
                        break;
                    default:
                        Console.WriteLine("Please choose a valid menu option.");
                        break;
                }

                if (keepGoing)
                {
                    Console.WriteLine("\nPress Enter to continue...");
                    Console.ReadLine();
                }
            }
        }

        private static void CreateGoal()
        {
            Console.WriteLine("\nWhat kind of goal do you want to add?");
            Console.WriteLine("1. Simple goal");
            Console.WriteLine("2. Eternal goal");
            Console.WriteLine("3. Checklist goal");
            Console.Write("Type: ");

            string? type = Console.ReadLine();
            Console.Write("Goal name: ");
            string? name = Console.ReadLine();
            Console.Write("Short description: ");
            string? description = Console.ReadLine();
            Console.Write("Points for each event: ");
            int points = ReadInt();

            switch (type)
            {
                case "1":
                    _manager.AddGoal(new SimpleGoal(name ?? "New Goal", description ?? "A new goal", points));
                    break;
                case "2":
                    _manager.AddGoal(new EternalGoal(name ?? "Daily Habit", description ?? "Keep going every day", points));
                    break;
                case "3":
                    Console.Write("How many times to complete it? ");
                    int target = ReadInt();
                    Console.Write("Bonus points for the final completion: ");
                    int bonus = ReadInt();
                    _manager.AddGoal(new ChecklistGoal(name ?? "Checklist Goal", description ?? "Finish the checklist", points, target, bonus));
                    break;
                default:
                    Console.WriteLine("That goal type is not available.");
                    return;
            }

            Console.WriteLine("Your new goal has been added to the quest.");
        }

        private static void RecordGoal()
        {
            _manager.DisplayGoals();
            if (_manager.Goals.Count == 0)
            {
                return;
            }

            Console.Write("Which goal did you finish? ");
            int choice = ReadInt() - 1;
            _manager.RecordGoal(choice);
        }

        private static int ReadInt()
        {
            while (true)
            {
                string? input = Console.ReadLine();
                if (int.TryParse(input, out int value) && value >= 0)
                {
                    return value;
                }

                Console.Write("Please enter a valid number: ");
            }
        }
    }
}
