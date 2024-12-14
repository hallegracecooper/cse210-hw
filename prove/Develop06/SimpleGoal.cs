public class SimpleGoal : Goal
{
    public bool IsCompleted { get; private set; }

    public SimpleGoal(string name, string description, int score) 
        : base(name, description, score)
    {
        IsCompleted = false;
    }

    public override void RecordEvent()
    {
        if (!IsCompleted)
        {
            IsCompleted = true;
            Console.WriteLine($"{Name} completed! You earned {Score} points.");
        }
        else
        {
            Console.WriteLine($"{Name} is already completed.");
        }
    }

    public override void DisplayStatus()
    {
        Console.WriteLine($"{Name}: {(IsCompleted ? "[X]" : "[ ]")} - {Description}");
    }
}