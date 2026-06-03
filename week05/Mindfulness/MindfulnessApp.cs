using System;
using System.Threading;

namespace Mindfulness
{
    public class MindfulnessApp
    {
        public void Run()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Mindfulness App");
                Console.WriteLine("1. Breathing Activity");
                Console.WriteLine("2. Reflection Activity");
                Console.WriteLine("3. Listing Activity");
                Console.WriteLine("4. View activity log");
                Console.WriteLine("5. Exit");
                Console.Write("Select an option: ");

                var choice = Console.ReadLine();
                Activity? activity = null;
                switch (choice)
                {
                    case "1": activity = new BreathingActivity(); break;
                    case "2": activity = new ReflectionActivity(); break;
                    case "3": activity = new ListingActivity(); break;
                    case "4": ShowLog(); break;
                    case "5": Console.WriteLine("Goodbye!"); Thread.Sleep(800); return;
                    default: Console.WriteLine("Please choose 1-5."); Thread.Sleep(800); continue;
                }

                if (activity != null)
                {
                    activity.Start();
                    Console.WriteLine("Press Enter to return to the main menu...");
                    Console.ReadLine();
                }
            }
        }

        private void ShowLog()
        {
            Console.Clear();
            Console.WriteLine("Activity Log");
            var entries = ActivityLogger.ReadLog();
            if (entries.Length == 0)
            {
                Console.WriteLine("No sessions have been completed yet.");
            }
            else
            {
                foreach (var entry in entries)
                {
                    Console.WriteLine(entry);
                }
            }
            Console.WriteLine();
            Console.WriteLine("Press Enter to return to the main menu...");
            Console.ReadLine();
        }
    }
}

