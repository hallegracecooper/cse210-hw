// This program has been enhanced to exceed the requirements by:
// 1. Adding support for CSV and JSON formats for saving/loading entries.
// 2. Including a mood field to enrich entries.
// 3. Implementing auto-save functionality for reliability.

using System;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Enhanced Journal Program!");

        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        bool running = true;
        while (running)
        {
            Console.WriteLine("\nSelect an option:");
            Console.WriteLine("1. Add Entry");
            Console.WriteLine("2. Display Entries");
            Console.WriteLine("3. Save to CSV File");
            Console.WriteLine("4. Load from CSV File");
            Console.WriteLine("5. Save to JSON File");
            Console.WriteLine("6. Load from JSON File");
            Console.WriteLine("7. Exit");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    string prompt = promptGenerator.GetRandomPrompt();
                    Console.WriteLine($"Prompt: {prompt}");
                    Console.Write("Your response: ");
                    string response = Console.ReadLine();
                    Console.Write("Your mood: ");
                    string mood = Console.ReadLine();
                    string date = DateTime.Now.ToString("yyyy-MM-dd");
                    journal.AddEntry(new Entry(date, prompt, response, mood));
                    Console.WriteLine("Entry added.");
                    break;

                case "2":
                    journal.DisplayAll();
                    break;

                case "3":
                    Console.Write("Enter filename to save (CSV): ");
                    string saveCsv = Console.ReadLine();
                    journal.SaveToCsv(saveCsv);
                    break;

                case "4":
                    Console.Write("Enter filename to load (CSV): ");
                    string loadCsv = Console.ReadLine();
                    journal.LoadFromCsv(loadCsv);
                    break;

                case "5":
                    Console.Write("Enter filename to save (JSON): ");
                    string saveJson = Console.ReadLine();
                    journal.SaveToJson(saveJson);
                    break;

                case "6":
                    Console.Write("Enter filename to load (JSON): ");
                    string loadJson = Console.ReadLine();
                    journal.LoadFromJson(loadJson);
                    break;

                case "7":
                    running = false;
                    Console.WriteLine("Goodbye!");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}