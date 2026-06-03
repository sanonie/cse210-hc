using System;
using System.Threading;
using System.Diagnostics;

namespace Mindfulness
{
    public class BreathingActivity : Activity
    {
        public BreathingActivity() : base("Breathing Activity",
            "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
        {
        }

        protected override void Run()
        {
            Console.WriteLine();
            var sw = Stopwatch.StartNew();
            bool inhale = true;
            while (sw.Elapsed.TotalSeconds < _durationSeconds)
            {
                if (inhale)
                {
                    Console.WriteLine("Breathe in...");
                    Countdown(4);
                }
                else
                {
                    Console.WriteLine("Breathe out...");
                    Countdown(6);
                }
                inhale = !inhale;
                Console.WriteLine();
            }
            // log the session
            ActivityLogger.Log(_name);
        }
    }
}
