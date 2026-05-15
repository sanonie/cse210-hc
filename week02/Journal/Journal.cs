using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry e)
    {
        _entries.Add(e);
    }

    public void Display()
    {
        Console.WriteLine("--- Journal Entries ---");
        foreach (var e in _entries)
        {
            Console.WriteLine(e.ToString());
        }
    }

    public void Save(string filename)
    {
        using (var writer = new StreamWriter(filename))
        {
            foreach (var e in _entries)
            {
                writer.WriteLine(e.ToString());
            }
        }
    }

    public void Load(string filename)
    {
        _entries.Clear();
        if (!File.Exists(filename)) return;

        var lines = File.ReadAllLines(filename);
        foreach (var line in lines)
        {
            var parts = line.Split(new string[] { " | " }, StringSplitOptions.None);
            if (parts.Length >= 3)
            {
                _entries.Add(new Entry(parts[0], parts[1], parts[2]));
            }
        }
    }
}
