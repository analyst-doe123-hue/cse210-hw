using System;

class Program
{
    static void Main(string[] args)
    {
        // Ask the user for their grade percentage
        Console.Write("Enter your grade percentage: ");
        string input = Console.ReadLine();
        int grade = int.Parse(input);

        // Variable to store the letter grade
        string letter = "";

        // Determine the letter grade
        if (grade >= 90)
        {
            letter = "A";
        }
        else if (grade >= 80)
        {
            letter = "B";
        }
        else if (grade >= 70)
        {
            letter = "C";
        }
        else if (grade >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        // Core requirement: print letter grade once
        Console.WriteLine($"Your grade is: {letter}");

        // Check if the student passed
        if (grade >= 70)
        {
            Console.WriteLine("Congratulations! You passed the class.");
        }
        else
        {
            Console.WriteLine("Don't give up, keep working hard for next time!");
        }

        // --------- Stretch Challenge ---------
        // Add + or - to the grade if applicable
        int lastDigit = grade % 10;
        string sign = "";

        if (letter != "A" && letter != "F") // no A+ or F+/F-
        {
            if (lastDigit >= 7)
            {
                sign = "+";
            }
            else if (lastDigit < 3)
            {
                sign = "-";
            }
        }
        else if (letter == "A" && grade < 94) // allow only A-
        {
            if (lastDigit < 3)
            {
                sign = "-";
            }
        }

        // Final grade with sign (if any)
        Console.WriteLine($"Your final letter grade is: {letter}{sign}");
    }
}
