using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        ScriptureLibrary scriptureLibrary = new ScriptureLibrary();

        do
        {
            Console.Clear();
            Scripture scripture = scriptureLibrary.GetRandomScripture();
            scripture.Display();

            Console.WriteLine("\nPress Enter to continue, type 'quit' to exit, or type 'reveal' to show all words:");
            string userInput = Console.ReadLine().ToLower();

            if (userInput == "quit")
            {
                break;
            }
            else if (userInput == "reveal")
            {
                // Reveal all words and wait for user input
                scripture.Display();
                Console.WriteLine("\nPress Enter to continue or type 'quit' to exit:");
                userInput = Console.ReadLine().ToLower();
                if (userInput == "quit")
                {
                    break;
                }
            }
            else
            {
                // Hide words progressively until all are hidden
                while (scripture.HideRandomWord())
                {
                    Console.Clear();
                    scripture.Display();
                    Console.WriteLine("\nPress Enter to continue, type 'quit' to exit, or type 'reveal' to show all words:");
                    userInput = Console.ReadLine().ToLower();

                    if (userInput == "quit")
                    {
                        return;
                    }
                    else if (userInput == "reveal")
                    {
                        // Reveal all words and wait for user input
                        scripture.Display();
                        Console.WriteLine("\nPress Enter to continue or type 'quit' to exit:");
                        userInput = Console.ReadLine().ToLower();
                        if (userInput == "quit")
                        {
                            return;
                        }
                    }
                }

                // All words are hidden, wait for user input
                Console.WriteLine("\nAll words are hidden. Press Enter to continue, type 'quit' to exit, or type 'reveal' to show all words:");
                userInput = Console.ReadLine().ToLower();
                if (userInput == "quit")
                {
                    break;
                }
                else if (userInput == "reveal")
                {
                    // Reveal all words and wait for user input
                    scripture.Display();
                    Console.WriteLine("\nPress Enter to continue or type 'quit' to exit:");
                    userInput = Console.ReadLine().ToLower();
                    if (userInput == "quit")
                    {
                        break;
                    }
                }
            }

        } while (true);
    }
}
