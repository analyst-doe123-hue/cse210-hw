using System;
using System.Collections.Generic;
using System.IO;
using ScriptureMemorizer;

class Program
{
    private const int MaxHidePerPress = 3;

    static void Main(string[] args)
    {
        // Load scripture library from file
        var scriptures = LoadScriptureLibrary();

        Scripture scripture;

        if (scriptures.Count == 0)
        {
            // Default scripture if no file is found
            var r = ScriptureReference.Parse("John 3:16");
            var text = "For God so loved the world that he gave his one and only Son, " +
                       "that whoever believes in him shall not perish but have eternal life.";
            scripture = new Scripture(r, text);
        }
        else
        {
            var rnd = new Random();
            scripture = scriptures[rnd.Next(scriptures.Count)];
        }

        RunMemorizerLoop(scripture);
    }

    private static List<Scripture> LoadScriptureLibrary()
    {
        var list = new List<Scripture>();
        const string fileName = "scriptures.txt";

        if (!File.Exists(fileName)) return list;

        foreach (var line in File.ReadAllLines(fileName))
        {
            if (string.IsNullOrWhiteSpace(line)) continue;
            var parts = line.Split('|', 2);
            if (parts.Length < 2) continue;

            try
            {
                var reference = ScriptureReference.Parse(parts[0].Trim());
                var text = parts[1].Trim();
                list.Add(new Scripture(reference, text));
            }
            catch
            {
                // Ignore bad lines
            }
        }

        return list;
    }

    private static void RunMemorizerLoop(Scripture scripture)
    {
        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());

        var rnd = new Random();

        while (true)
        {
            if (scripture.AllHidden)
            {
                Console.WriteLine("\nAll words are hidden. Press ENTER to exit.");
                Console.ReadLine();
                break;
            }

            Console.WriteLine("\nPress ENTER to hide some words (or type 'quit' to exit):");
            var input = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(input) &&
                input.Trim().Equals("quit", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Goodbye!");
                break;
            }

            int toHide = rnd.Next(1, MaxHidePerPress + 1);
            scripture.HideRandomWords(toHide, avoidAlreadyHidden: true);

            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
        }
    }
}
