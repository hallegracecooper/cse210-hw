using System;
using System.Collections.Generic;
using System.Threading;

abstract class MindfulnessActivity
{
    protected int duration;

    public void StartActivity()
    {
        Console.WriteLine($"This activity will take {duration} seconds.");
        Thread.Sleep(2000);
        Prepare();
        ExecuteActivity();
        EndActivity();
    }

    protected abstract void Prepare();
    protected abstract void ExecuteActivity();
    protected abstract void EndActivity();
}

class BreathingActivity : MindfulnessActivity
{
    public BreathingActivity(int duration)
    {
        this.duration = duration;
    }

    protected override void Prepare()
    {
        Console.WriteLine("This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.");
        Thread.Sleep(2000);
    }

    protected override void ExecuteActivity()
    {
        for (int i = 0; i < duration / 10; i++)
        {
            Console.WriteLine("Breathe in...");
            Countdown(5);
            Console.WriteLine("Breathe out...");
            Countdown(5);
        }
    }

    protected override void EndActivity()
    {
        Console.WriteLine("Good job! You have completed the breathing activity.");
        Thread.Sleep(2000);
    }

    private void Countdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"{i} ");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }
}

class ReflectionActivity : MindfulnessActivity
{
    private List<string> prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectionActivity(int duration)
    {
        this.duration = duration;
    }

    protected override void Prepare()
    {
        Console.WriteLine("This activity will help you reflect on times in your life when you have shown strength and resilience.");
        Thread.Sleep(2000);
    }

    protected override void ExecuteActivity()
    {
        Random rand = new Random();
        string prompt = prompts[rand.Next(prompts.Count)];
        Console.WriteLine(prompt);
        Thread.Sleep(2000);

        int timeElapsed = 0;
        while (timeElapsed < duration)
        {
            string question = questions[rand.Next(questions.Count)];
            Console.WriteLine(question);
            Countdown(5);
            timeElapsed += 5;
        }
    }

    protected override void EndActivity()
    {
        Console.WriteLine("Good job! You have completed the reflection activity.");
        Thread.Sleep(2000);
    }

    private void Countdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"{i} ");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }
}

class ListingActivity : MindfulnessActivity
{
    private List<string> prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity(int duration)
    {
        this.duration = duration;
    }

    protected override void Prepare()
    {
        Console.WriteLine("This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");
        Thread.Sleep(2000);
    }

    protected override void ExecuteActivity()
    {
        Random rand = new Random();
        string prompt = prompts[rand.Next(prompts.Count)];
        Console.WriteLine(prompt);
        Thread.Sleep(2000);

        Console.WriteLine("You may now start listing your answers. Press Enter after each item.");
        Thread.Sleep(2000);

        List<string> list = new List<string>();
        int timeElapsed = 0;

        while (timeElapsed < duration)
        {
            Console.Write("Enter an item: ");
            string item = Console.ReadLine();
            list.Add(item);
            timeElapsed += 5;
        }

        Console.WriteLine($"You listed {list.Count} items.");
    }

    protected override void EndActivity()
    {
        Console.WriteLine("Good job! You have completed the listing activity.");
        Thread.Sleep(2000);
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Welcome to the mindfulness program!");
        Thread.Sleep(2000);
        int duration;

        Console.Write("Enter the duration for the activity in seconds: ");
        duration = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("\nChoose an activity:");
        Console.WriteLine("1. Breathing Activity");
        Console.WriteLine("2. Reflection Activity");
        Console.WriteLine("3. Listing Activity");
        Console.Write("Select the activity (1-3): ");
        int choice = Convert.ToInt32(Console.ReadLine());

        MindfulnessActivity activity = choice switch
        {
            1 => new BreathingActivity(duration),
            2 => new ReflectionActivity(duration),
            3 => new ListingActivity(duration),
            _ => null
        };

        activity?.StartActivity();
    }
}