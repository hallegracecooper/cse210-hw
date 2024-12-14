using System;
using System.IO;

public class SaveLoadManager
{
    public void SaveGoals(List<Goal> goals)
    {
        using (StreamWriter writer = new StreamWriter("goals.txt"))
        {
            foreach (Goal goal in goals)
            {
                writer.WriteLine($"{goal.Name},{goal.Description},{goal.Score}");
            }
        }
    }

    public List<Goal> LoadGoals()
    {
        List<Goal> goals = new List<Goal>();
        if (File.Exists("goals.txt"))
        {
            using (StreamReader reader = new StreamReader("goals.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    goals.Add(new SimpleGoal(parts[0], parts[1], int.Parse(parts[2])));
                }
            }
        }
        return goals;
    }
}
