using System;
using System.Collections.Generic;

public class GoalManager
{
    private List<Goal> goals;
    private int totalScore;

    public GoalManager()
    {
        goals = new List<Goal>();
        totalScore = 0;
    }

    public void AddGoal(Goal goal)
    {
        goals.Add(goal);
    }

    public void RecordEvent(string goalName)
    {
        foreach (Goal goal in goals)
        {
            if (goal.Name == goalName)
            {
                goal.RecordEvent();
                totalScore += goal.Score;
            }
        }
    }

    public void DisplayGoals()
    {
        foreach (Goal goal in goals)
        {
            goal.DisplayStatus();
        }
    }

    public void DisplayScore()
    {
        Console.WriteLine($"Total Score: {totalScore}");
    }
}
