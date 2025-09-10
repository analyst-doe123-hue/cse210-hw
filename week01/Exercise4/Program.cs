using System;
using System.Collections.Generic;
using System.Linq; // for helpful LINQ methods

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        int input = -1;
        while (input != 0)
        {
            Console.Write("Enter number: ");
            input = int.Parse(Console.ReadLine());

            if (input != 0)
            {
                numbers.Add(input);
            }
        }

        // Core requirements
        int sum = numbers.Sum();
        double average = numbers.Average();
        int max = numbers.Max();

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {max}");

        // Stretch challenge: smallest positive number
        int? smallestPositive = numbers.Where(n => n > 0).DefaultIfEmpty().Min();
        if (smallestPositive > 0)
        {
            Console.WriteLine($"The smallest positive number is: {smallestPositive}");
        }

        // Stretch challenge: sort list and display
        numbers.Sort();
        Console.WriteLine("The sorted list is:");
        foreach (int num in numbers)
        {
            Console.WriteLine(num);
        }
    }
}
