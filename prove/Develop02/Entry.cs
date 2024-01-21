using System;

public class Entry
{
    public string Text { get; private set; }
    public DateTime Created { get; private set; }
    public Entry UserResponse { get; set; }
    public string Prompt { get; set; }

    // Constructor for entries with a prompt
    public Entry(string text, DateTime created, string prompt)
    {
        Text = text;
        Created = created;
        Prompt = prompt;
    }

    // Constructor for entries without a prompt (responses)
    public Entry(string text, DateTime created)
    {
        Text = text;
        Created = created;
    }
}
