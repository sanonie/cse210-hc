using System;

public class Comment
{
    private string _name;
    private string _text;

    public Comment(string name, string text)
    {
        _name = name;
        _text = text;
    }

    public string Name => _name;
    public string Text => _text;

    public void DisplayComment()
    {
        Console.WriteLine($"  {Name}: {Text}");
    }
}