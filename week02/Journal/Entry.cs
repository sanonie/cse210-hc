using System;

public class Entry
{
    public string Date { get; set; } = string.Empty;
    public string Prompt { get; set; } = string.Empty;
    public string Response { get; set; } = string.Empty;

    public Entry() { }

    public Entry(string date, string prompt, string response)
    {
        Date = date;
        Prompt = prompt;
        Response = response;
    }

    public int GetWordCount()
    {
        if (string.IsNullOrWhiteSpace(Response))
            return 0;
        return Response.Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).Length;
    }

    public string GetDisplayFormat()
    {
        int wordCount = GetWordCount();
        return $"[Date: {Date}]\n  [Prompt: {Prompt}]\n  [Response: {Response}]\n  [Word Count: {wordCount}]";
    }

    public override string ToString()
    {
        return $"{Date} | {Prompt} | {Response}";
    }
}
