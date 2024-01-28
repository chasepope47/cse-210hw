using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    private List<Word> words;

    public Reference Reference { get; }
    public string Text { get; }

    public Scripture(Reference reference, string text)
    {
        Reference = reference;
        Text = text;
        words = text.Split(' ').Select(word => new Word(word)).ToList();
    }

    public void Display()
    {
        Console.WriteLine($"{Reference} - {Text}");
        Console.WriteLine(string.Join(" ", words));
    }

    public bool HideRandomWord()
    {
        List<Word> visibleWords = words.FindAll(w => !w.IsHidden);
        if (visibleWords.Count == 0)
        {
            return false; // All words are hidden
        }

        Random random = new Random();
        int index = random.Next(visibleWords.Count);
        visibleWords[index].Hide();
        return true;
    }
}
