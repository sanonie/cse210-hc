using System;
using System.Threading;
using System.Diagnostics;

namespace Mindfulness
{
    public abstract class Activity
    {
        protected string _name;
        protected string _description;
        protected int _durationSeconds;

        public Activity(string name, string description)
        {
            _name = name;
            _description = description;
        }

        public void Start()
        {
            Console.Clear();
            ShowStartingMessage();
            PromptDuration();
            PrepareToBegin();
            Run();
            Finish();
        }

        protected virtual void ShowStartingMessage()
        {
            Console.WriteLine($"=== {_name} ===");
            Console.WriteLine(_description);
            Console.WriteLine();
        }

        protected void PromptDuration()
        {
            Console.Write("How long, in seconds, would you like for your session? ");
            while (true)
            {
                var input = Console.ReadLine();
                if (int.TryParse(input, out var val) && val > 0)
                {
                    _durationSeconds = val;
                    break;
                }
                Console.Write("Please enter a positive integer: ");
            }
        }

        protected void PrepareToBegin()
        {
            Console.WriteLine("Get ready...");
            Spinner(3);
        }

        protected abstract void Run();

        protected virtual void Finish()
        {
            Console.WriteLine();
            Console.WriteLine("Well done!");
            Console.WriteLine($"You have completed the {_name} for {_durationSeconds} seconds.");
            Spinner(3);
        }

        // small utilities used by derived classes
        protected void Spinner(int seconds)
        {
            var sw = Stopwatch.StartNew();
            var spinner = new[] { '|', '/', '-', '\\' };
            int i = 0;
            while (sw.Elapsed.TotalSeconds < seconds)
            {
                Console.Write(spinner[i % spinner.Length]);
                Thread.Sleep(250);
                Console.Write('\b');
                i++;
            }
        }

        protected void Countdown(int seconds)
        {
            for (int i = seconds; i >= 1; i--)
            {
                Console.Write(i);
                Thread.Sleep(1000);
                Console.Write('\r');
                Console.Write(new string(' ', 10));
                Console.Write('\r');
            }
        }
    }
}
