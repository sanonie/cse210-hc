using System;

namespace Exercise02
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("What is your grade percentage? ");
            string gradeInput = Console.ReadLine() ?? string.Empty;
            int gradePercentage = int.Parse(gradeInput);

            // Determine letter grade
            string letter;

            if (gradePercentage >= 90)
            {
                letter = "A";
            }
            else if (gradePercentage >= 80)
            {
                letter = "B";
            }
            else if (gradePercentage >= 70)
            {
                letter = "C";
            }
            else if (gradePercentage >= 60)
            {
                letter = "D";
            }
            else
            {
                letter = "F";
            }

            Console.WriteLine($"Your grade: {letter}");

            // Determine if passed
            if (gradePercentage >= 70)
            {
                Console.WriteLine("Congratulations! You passed the course!");
            }
            else
            {
                Console.WriteLine("Keep trying! You'll do better next time.");
            }
        }
    }
}
