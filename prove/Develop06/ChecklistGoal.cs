public class ChecklistGoal : Goal
{
    public int TimesCompleted { get; private set; }
    public int TimesRequired { get; private set; }
    public int Bonus { get; set; }

    public ChecklistGoal(string name, string description, int score, int timesRequired)
        : base(name, description, score)
    {
        TimesCompleted = 0;
        TimesRequired = timesRequired;
        Bonus = 500;
    }

    public override void RecordEvent()
    {
        TimesCompleted++;
        int pointsEarned = Score;
        if (TimesCompleted == TimesRequired)
        {
            pointsEarned += Bonus;
            Console.WriteLine($"{Name} completed all {TimesRequired} times! You earned {pointsEarned} points.");
        }
        else
        {
            Console.WriteLine($"{Name} recorded! You earned {pointsEarned} points.");
        }
    }

    public override void DisplayStatus()
    {
        Console.WriteLine($"{Name}: [{TimesCompleted}/{TimesRequired}] - {Description}");
    }
}