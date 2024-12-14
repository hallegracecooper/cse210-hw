public class LevelingUp
{
    public int Experience { get; private set; }
    public int Level { get; private set; }

    public LevelingUp()
    {
        Experience = 0;
        Level = 1;
    }

    public void AddExperience(int points)
    {
        Experience += points;
        if (Experience >= 1000)
        {
            Level++;
            Experience = 0;
            Console.WriteLine("Congratulations! You leveled up!");
        }
    }

    public void DisplayLevel()
    {
        Console.WriteLine($"Current Level: {Level} (XP: {Experience})");
    }
}
