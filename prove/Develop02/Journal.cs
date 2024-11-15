using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class Journal
{
    private List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries in the journal.");
            return;
        }
        foreach (var entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToCsv(string file)
    {
        using (StreamWriter writer = new StreamWriter(file))
        {
            writer.WriteLine("Date,Prompt,Response,Mood"); // Header row
            foreach (var entry in _entries)
            {
                string csvRow = $"\"{entry.Date}\",\"{entry.PromptText}\",\"{entry.EntryText.Replace("\"", "\"\"")}\",\"{entry.Mood}\"";
                writer.WriteLine(csvRow);
            }
        }
        Console.WriteLine($"Journal saved to {file} (CSV format)");
    }

    public void LoadFromCsv(string file)
    {
        if (File.Exists(file))
        {
            _entries.Clear();
            string[] lines = File.ReadAllLines(file);
            for (int i = 1; i < lines.Length; i++) // Skip header row
            {
                string[] parts = ParseCsvLine(lines[i]);
                if (parts.Length == 4)
                {
                    _entries.Add(new Entry(parts[0], parts[1], parts[2], parts[3]));
                }
            }
            Console.WriteLine($"Journal loaded from {file} (CSV format)");
        }
        else
        {
            Console.WriteLine($"File {file} not found.");
        }
    }

    private string[] ParseCsvLine(string line)
    {
        // Simple CSV parsing with quotes support
        var parts = new List<string>();
        bool inQuotes = false;
        string currentPart = "";

        foreach (var c in line)
        {
            if (c == '"' && (currentPart == "" || inQuotes))
            {
                inQuotes = !inQuotes;
            }
            else if (c == ',' && !inQuotes)
            {
                parts.Add(currentPart);
                currentPart = "";
            }
            else
            {
                currentPart += c;
            }
        }
        parts.Add(currentPart); // Add the last part
        return parts.ToArray();
    }

    public void SaveToJson(string file)
    {
        string json = JsonSerializer.Serialize(_entries);
        File.WriteAllText(file, json);
        Console.WriteLine($"Journal saved to {file} (JSON format)");
    }

    public void LoadFromJson(string file)
    {
        if (File.Exists(file))
        {
            string json = File.ReadAllText(file);
            _entries = JsonSerializer.Deserialize<List<Entry>>(json);
            Console.WriteLine($"Journal loaded from {file} (JSON format)");
        }
        else
        {
            Console.WriteLine($"File {file} not found.");
        }
    }
}