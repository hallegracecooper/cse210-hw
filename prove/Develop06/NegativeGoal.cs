public class NegativeGoal : Goal
{
    public NegativeGoal(string name, string description, int penalty)
        : base(name, description, penalty) { }

    public override void RecordEvent()
    {
        Console.WriteLine($"{Name} penalty! You lost {Score} points.");
    }

    public override void DisplayStatus()
    {
        Console.WriteLine($"{Name}: [ ] - {Description} (Penalty: {Score} points)");
    }
}
