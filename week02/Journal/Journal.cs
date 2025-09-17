using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void DisplayJournal()
    {
        foreach (Entry e in _entries)
        {
            Console.WriteLine(e.ToString());
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter output = new StreamWriter(filename))
        {
            foreach (Entry e in _entries)
            {
                output.WriteLine($"{e.Date}~|~{e.Prompt}~|~{e.Response}");
            }
        }
    }

    public void LoadFromFile(string filename)
    {
        _entries.Clear();
        string[] lines = File.ReadAllLines(filename);

        foreach (string line in lines)
        {
            string[] parts = line.Split("~|~");
            Entry e = new Entry(parts[0], parts[1], parts[2]);
            _entries.Add(e);
        }
    }
}
