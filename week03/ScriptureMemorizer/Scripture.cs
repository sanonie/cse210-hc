using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();

        // Split the text into words and create Word objects
        string[] wordTexts = text.Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
        foreach (string wordText in wordTexts)
        {
            _words.Add(new Word(wordText));
        }
    }

    public void Display()
    {
        Console.Clear();
        Console.WriteLine(_reference.ToString());
        Console.WriteLine();

        string displayText = string.Empty;
        foreach (var word in _words)
        {
            displayText += word.GetDisplayText() + " ";
        }

        Console.WriteLine(displayText.Trim());
        Console.WriteLine();
    }

    public void HideRandomWords()
    {
        Random rand = new Random();
        int wordsToHide = Math.Max(1, _words.Count / 5); // Hide approximately 20% of words

        for (int i = 0; i < wordsToHide; i++)
        {
            int randomIndex = rand.Next(_words.Count);
            _words[randomIndex].Hide();
        }
    }

    public bool IsCompletelyHidden()
    {
        return _words.All(w => w.IsHidden());
    }

    public int GetHiddenWordCount()
    {
        return _words.Count(w => w.IsHidden());
    }

    public int GetTotalWordCount()
    {
        return _words.Count;
    }
}
