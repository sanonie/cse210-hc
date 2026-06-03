using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace Mindfulness
{
    public class ReflectionActivity : Activity
    {
        private readonly PromptPool<string> _promptPool = new PromptPool<string>(new[]
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        });

        private readonly PromptPool<string> _questionPool = new PromptPool<string>(new[]
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        });

        public ReflectionActivity() : base("Reflection Activity",
            "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
        {
        }

        protected override void Run()
        {
            var prompt = _promptPool.GetNext();
            Console.WriteLine();
            Console.WriteLine("Consider the following prompt:");
            Console.WriteLine($" --- {prompt} ---");
            Console.WriteLine();
            Console.WriteLine("When you're ready, reflect on the following questions:");

            var sw = Stopwatch.StartNew();
            while (sw.Elapsed.TotalSeconds < _durationSeconds)
            {
                var question = _questionPool.GetNext();
                Console.WriteLine($"-> {question}");
                Spinner(5);
                Console.WriteLine();
            }

            ActivityLogger.Log(_name);
        }
    }
}
