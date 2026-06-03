using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace Mindfulness
{
    public class ListingActivity : Activity
    {
        private readonly PromptPool<string> _promptPool = new PromptPool<string>(new[]
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        });

        public ListingActivity() : base("Listing Activity",
            "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
        {
        }

        protected override void Run()
        {
            var prompt = _promptPool.GetNext();
            Console.WriteLine();
            Console.WriteLine("List as many responses as you can to the following prompt:");
            Console.WriteLine($" --- {prompt} ---");
            Console.WriteLine();
            Console.WriteLine("You will have a short moment to think...");
            Countdown(5);
            Console.WriteLine("Start listing. Press Enter after each item.");

            var items = ReadTimedItems(_durationSeconds);
            Console.WriteLine();
            Console.WriteLine($"You listed {items.Count} items. Nice work!");
            ActivityLogger.Log(_name);
        }

        private List<string> ReadTimedItems(int duration)
        {
            var items = new List<string>();
            var sw = Stopwatch.StartNew();
            Console.Write("\r> ");
            var current = string.Empty;
            while (sw.Elapsed.TotalSeconds < duration)
            {
                while (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true);
                    if (key.Key == ConsoleKey.Enter)
                    {
                        if (!string.IsNullOrWhiteSpace(current))
                        {
                            items.Add(current.Trim());
                        }
                        current = string.Empty;
                        Console.WriteLine();
                        Console.Write("> ");
                    }
                    else if (key.Key == ConsoleKey.Backspace && current.Length > 0)
                    {
                        current = current.Substring(0, current.Length - 1);
                        Console.Write("\b \b");
                    }
                    else if (!char.IsControl(key.KeyChar))
                    {
                        current += key.KeyChar;
                        Console.Write(key.KeyChar);
                    }
                }

                Thread.Sleep(50);
            }

            if (!string.IsNullOrWhiteSpace(current))
            {
                items.Add(current.Trim());
                Console.WriteLine();
            }

            return items;
        }
    }
}
