using System;

class Program
{
    static void Main(string[] args)
    {
        bool playAgain = true;
        Random randomGenerator = new Random();

        while (playAgain)
        {
            int magicNumber = randomGenerator.Next(1, 101);
            int guess = -1;

            Console.WriteLine("I've selected a magic number between 1 and 100. Try to guess it!");

            while (guess != magicNumber)
            {
                Console.Write("What is your guess? ");

                while (!int.TryParse(Console.ReadLine(), out guess))
                {
                    Console.WriteLine("Please enter a valid integer.");
                }

                if (magicNumber > guess)
                {
                    Console.WriteLine("Higher");
                }
                else if (magicNumber < guess)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("Congratulations! You guessed the right number!");
                    Console.Write("Do you want to play again? (yes/no): ");
                    
                    string playAgainResponse = Console.ReadLine().ToLower();
                    playAgain = playAgainResponse == "yes";
                    
                    if (playAgain)
                    {
                        break; // Break the inner loop and generate a new magic number
                    }
                }
            }
        }
    }
}
