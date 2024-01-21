using System;

class Program
{
    static void Main()
    {
        PromptGenerator promptGenerator = new PromptGenerator();
        Journal journal = new Journal();
        string userResponse;
        DateTime created;
        Entry entry;
        int choice;
        bool quit = false;
        string fileName = "";
        string loadFileName = "";

        do
        {
            Console.Clear();
            Console.WriteLine("Journal App");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save ");
            Console.WriteLine("5. Quit");
            Console.Write("Enter your choice: ");
            choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Clear();
                    string prompt = promptGenerator.GeneratePrompt();
                    Console.WriteLine($"Prompt: {prompt}");
                    userResponse = Console.ReadLine();
                    created = DateTime.Now;
                    entry = new Entry(userResponse, created, prompt);
                    journal.AddEntry(entry);
                    break;

                case 2:
                    journal.DisplayEntries();
                    Console.ReadLine();
                    break;

                case 3:
                    string filename;
                    do
                    {
                        Console.Write("Enter the filename to load (enter 'exit' to cancel): ");
                        filename = Console.ReadLine();
                        if (filename.ToLower() == "exit")
                            break;

                        if (System.IO.File.Exists(filename))
                            break;
                        else
                        {
                            Console.WriteLine("File not found, please try again");
                            continue;
                        }
                    }
                    while (true);

                    if (filename.ToLower() != "exit")
                    {
                        loadFileName = filename;
                        Console.WriteLine($"File loaded: {loadFileName}");
                        Console.WriteLine($"Content of the file '{loadFileName}':");
                        journal.Load(loadFileName);
                        journal.DisplayEntries();
                        Console.ReadLine();
                    }
                    break;

                case 4:
                    do
                    {
                        Console.Write("Enter the filename to save: ");
                        fileName = Console.ReadLine();
                        if (!System.IO.File.Exists(fileName))
                            break;
                        else
                        {
                            Console.WriteLine("File exists, overwrite? (y/n) ");
                            if (Console.ReadLine().ToLower() == "y")
                                break;
                        }
                    }
                    while (true);
                    journal.Save(fileName);
                    loadFileName = fileName; // Save the filename for later use
                    Console.WriteLine($"File saved: {loadFileName}");
                    break;

                case 5:
                    quit = true;
                    break;

                default:
                    Console.WriteLine("Invalid choice, please try again");
                    break;
            }
        }
        while (!quit);
    }
}
