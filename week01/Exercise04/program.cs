using System;
using System.Collections.Generic;

namespace Exercise04
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();

            Console.WriteLine("Enter a list of numbers, type 0 when finished.");

            int number = -1;
            while (number != 0)
            {
                Console.Write("Enter number: ");
                string input = Console.ReadLine() ?? string.Empty;
                number = int.Parse(input);

                if (number != 0)
                {
                    numbers.Add(number);
                }
            }

            // Compute sum
            int sum = 0;
            foreach (int num in numbers)
            {
                sum += num;
            }

            // Compute average
            double average = (double)sum / numbers.Count;

            // Find maximum
            int max = numbers[0];
            foreach (int num in numbers)
            {
                if (num > max)
                {
                    max = num;
                }
            }

            Console.WriteLine($"The sum is: {sum}");
            Console.WriteLine($"The average is: {average}");
            Console.WriteLine($"The largest number is: {max}");
        }
    }
}
