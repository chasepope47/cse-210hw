using System;

class ChecklistGoal : Goal
{
    private int totalTimes;
    private int completedTimes;

    public ChecklistGoal(string title, string description, int totalTimes, int points) : base(title, description, points)
    {
        this.totalTimes = totalTimes;
        completedTimes = 0;
    }

    public override void Complete()
    {
        completedTimes++;
        if (completedTimes >= totalTimes)
            base.Complete();
    }

    public override string DisplayStatus()
    {
        return $"{Title}: {DisplayCompletionStatus()}";
    }

    private string DisplayCompletionStatus()
    {
        return Completed ? $"Completed {completedTimes}/{totalTimes} times" : $"Not Completed {completedTimes}/{totalTimes} times";
    }

    public override int GetPoints()
    {
        return Completed ? Points : 0;
    }
}
