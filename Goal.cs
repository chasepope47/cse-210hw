abstract class Goal
{
    public string Title { get; protected set; }
    public string Description { get; protected set; }
    public int Points { get; protected set; }
    public bool Completed { get; protected set; }

    // Parameterless constructor
    protected Goal()
    {
    }

    public Goal(string title, string description, int points)
    {
        Title = title;
        Description = description;
        Points = points;
        Completed = false;
    }

    public virtual void Complete()
    {
        Completed = true;
    }

    public virtual string DisplayStatus()
    {
        return $"{Title}: {(Completed ? "Completed" : "Not Completed")} ({Points} points)";
    }

    public virtual string DisplayDetails()
    {
        return $"{Title}: {(Completed ? "Completed" : "Not Completed")} - {Description} ({Points} points)";
    }

    public virtual int GetPoints()
    {
        return Completed ? Points : 0;
    }
}
