public class EternalGoal : Goal
{
    public int TotalPoints { get; private set; }

    public EternalGoal(string name, string description, int score) 
        : base(name, description, score)
    {
        TotalPoints = 0;
    }

    public override void RecordEvent()
    {
        TotalPoints += Score;
        Console.WriteLine($"{Name} recorded! You earned {Score} points.");
    }

    public override void DisplayStatus()
    {
        Console.WriteLine($"{Name}: [ ] - {Description} (Total points: {TotalPoints})");
    }
}
