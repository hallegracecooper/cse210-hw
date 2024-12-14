using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        GoalManager goalManager = new GoalManager();

        goalManager.AddGoal(new SimpleGoal("Run Marathon", "Complete a marathon", 1000));
        goalManager.AddGoal(new EternalGoal("Read Scriptures", "Read scriptures daily", 100));
        goalManager.AddGoal(new ChecklistGoal("Attend Temple", "Attend the temple 10 times", 50, 10));
        goalManager.AddGoal(new NegativeGoal("Skip Workout", "Skipping workout causes a penalty", -10));

        goalManager.RecordEvent("Read Scriptures");
        goalManager.RecordEvent("Read Scriptures");
        goalManager.RecordEvent("Attend Temple");
        goalManager.RecordEvent("Skip Workout");  // This should cause a loss of points

        goalManager.DisplayGoals();
        goalManager.DisplayScore();
    }
}