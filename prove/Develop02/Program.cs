using System;

class Program
{
    static void Main(string[] args)
    {
       Journal theJournal = new Journal();
       Entry anEntry = new Entry();
       anEntry.Display();

       theJournal.AddEntry(anEntry);      
       
        Console.WriteLine("Hello Develop02 World!");
    }
}