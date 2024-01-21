using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> entries = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        entries.Add(entry);
    }

    public void AddResponse(Entry parentEntry, Entry response)
    {
        if (entries.Contains(parentEntry))
        {
            parentEntry.UserResponse = response;
        }
        else
        {
            throw new ArgumentException("Parent entry not found in the journal.");
        }
    }

    public void DisplayEntries()
    {
        foreach (var entry in entries)
        {
            Console.WriteLine($"Entry: {entry.Text} (Created: {entry.Created})");
            DisplayResponse(entry);
        }
    }

    private void DisplayResponse(Entry entry)
    {
        if (entry.UserResponse != null)
        {
            Console.WriteLine($"\tResponse: {entry.UserResponse.Text} (Created: {entry.UserResponse.Created})");
            DisplayResponse(entry.UserResponse);
        }
    }

    public void Load(string filename)
    {
        entries.Clear();
        using (var reader = new StreamReader(filename))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                var parts = line.Split("|");
                var text = parts[0].Trim();
                var created = DateTime.Parse(parts[1].Trim());
                var userResponse = parts[2].Trim();
                entries.Add(new Entry(text, created) { UserResponse = new Entry(userResponse, created) });
            }
        }
    }

    public void Save(string filename)
    {
        using (var streamWriter = new StreamWriter(filename))
        {
            foreach (var entry in entries)
            {
                streamWriter.WriteLine($"{entry.Text}|{entry.Created:yyyy-MM-dd HH:mm:ss}|{entry.UserResponse?.Text}");
            }
        }
    }
}
