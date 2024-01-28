using System;
using System.Collections.Generic;
using System.Linq;

public class Reference
{
    public string Book { get; }
    public int Chapter { get; }
    public int StartVerse { get; }
    public int EndVerse { get; }

    public Reference(string reference)
    {
        string[] parts = reference.Split(' ');

        if (parts.Length > 2 && parts[1].All(char.IsDigit))
        {
            Book = $"{parts[0]} {parts[1]}";
            Chapter = int.Parse(parts[2]);
            StartVerse = 1;
            EndVerse = 1;
        }
        else
        {
            Book = string.Join(" ", parts.TakeWhile(part => !part.All(char.IsDigit)));
            string[] chapterVerse = parts.Last().Split(':');
            Chapter = int.Parse(chapterVerse[0]);

            if (chapterVerse[1].Contains("-"))
            {
                string[] verses = chapterVerse[1].Split('-');
                StartVerse = int.Parse(verses[0]);
                EndVerse = int.Parse(verses[1]);
            }
            else
            {
                StartVerse = int.Parse(chapterVerse[1]);
                EndVerse = StartVerse;
            }
        }
    }

    public override string ToString()
    {
        return $"{Book} {Chapter}:{StartVerse}-{EndVerse}";
    }
}
