using System;

class Program
{
    static void Main(string[] args)
    {
        Reference scriptureRef = new Reference("Proverbs", 3, 5);
        string text = "Trust in the Lord with all your heart and lean not on your own understanding";

        Scripture scripture = new Scripture(scriptureRef, text);

        scripture.Display();
        while (true)
        {
            Console.WriteLine("\nPress Enter to continue or type 'quit' to exit.");
            string input = Console.ReadLine();
            if (input.ToLower() == "quit") break;

            if (!scripture.HideRandomWords(3))
            {
                scripture.Display();
                Console.WriteLine("All words are hidden. Memorization complete!");
                break;
            }

            scripture.Display();
        }
    }
}