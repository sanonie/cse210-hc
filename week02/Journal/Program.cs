using System;

// Journal application
// Requirements met:
// - Contains classes: Entry, Journal, PromptGenerator (each in its own file).
// - Presents a menu to write, display, save, and load journal entries.
// - Uses a simple separator " | " when saving to a text file.
// Notes on exceeding requirements and style choices:
// - Added extra prompts and a `PromptGenerator` class for extensibility.
// - Validates filenames before saving/loading to avoid null/empty input.
// - Private fields in classes use `_underscoreCamelCase` to match style requirements.
// - The program stores date as a string per instructions.

class Program
{
    static void Main()
    {
        var journal = new Journal();
        var prompts = new PromptGenerator();

        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("Journal Menu");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Quit");
            Console.Write("Choose an option: ");
            var choice = Console.ReadLine();

            if (choice == "1")
            {
                var prompt = prompts.GetRandomPrompt();
                Console.WriteLine($"Prompt: {prompt}");
                Console.Write("Your response: ");
                var response = Console.ReadLine() ?? string.Empty;
                var date = DateTime.Now.ToShortDateString();
                journal.AddEntry(new Entry(date, prompt, response));
            }
            else if (choice == "2")
            {
                journal.Display();
            }
            else if (choice == "3")
            {
                Console.Write("Filename to save to: ");
                var fname = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(fname))
                {
                    Console.WriteLine("Invalid filename. Save cancelled.");
                }
                else
                {
                    journal.Save(fname);
                    Console.WriteLine("Saved.");
                }
            }
            else if (choice == "4")
            {
                Console.Write("Filename to load from: ");
                var fname = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(fname))
                {
                    Console.WriteLine("Invalid filename. Load cancelled.");
                }
                else
                {
                    journal.Load(fname);
                    Console.WriteLine("Loaded.");
                }
            }
            else if (choice == "5")
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid option.");
            }
        }
    }
}
