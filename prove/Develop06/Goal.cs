using System;

public abstract class Goal
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Score { get; set; }

    public Goal(string name, string description, int score)
    {
        Name = name;
        Description = description;
        Score = score;
    }

    public abstract void RecordEvent();
    public abstract void DisplayStatus();
}
