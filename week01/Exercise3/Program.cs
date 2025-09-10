using System;

class Program
{
    static void Main(string[] args)
    {
        string playAgain = "yes";

        while (playAgain.ToLower() == "yes")
        {
            // --- Core requirement: Generate a random magic number ---
            Random randomGenerator = new Random();
            int magicNumber = randomGenerator.Next(1, 101); // 1 to 100

            // For testing/debugging (optional): uncomment this line
            // Console.WriteLine($"[DEBUG] Magic number is: {magicNumber}");

            int guess = -1; // Initialize guess to something not equal to magicNumber
            int guessCount = 0; // Stretch challenge: count guesses

            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());
            guessCount++;

            // Loop until the user guesses it
            while (guess != magicNumber)
            {
                if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else
                {
                    Console.WriteLine("Lower");
                }

                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());
                guessCount++;
            }

            // When the loop ends, they got it right
            Console.WriteLine("You guessed it!");
            Console.WriteLine($"It took you {guessCount} guesses.");

            // Ask if they want to play again
            Console.Write("Do you want to play again? (yes/no): ");
            playAgain = Console.ReadLine();
            Console.WriteLine();
        }

        Console.WriteLine("Thanks for playing Guess My Number!");
    }
}
