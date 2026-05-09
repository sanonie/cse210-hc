using System;

namespace Exercise01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("What is your first name? ");
            string firstName = Console.ReadLine() ?? string.Empty;
            Console.Write("What is your last name? ");
            string lastName = Console.ReadLine() ?? string.Empty;
            Console.WriteLine();
            Console.WriteLine($"Your name is {lastName}, {firstName} {lastName}.");
        }
    }
}

