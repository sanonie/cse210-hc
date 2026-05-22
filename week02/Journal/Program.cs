using System;

// Journal Application - Advanced Features
// 
// CORE REQUIREMENTS MET:
// - Contains 3 classes (Entry, Journal, PromptGenerator) each in its own file.
// - Menu-driven interface for writing, displaying, saving, and loading entries.
// - Each entry stores: Date (as string), Prompt (randomly selected), Response (user input).
// - PromptGenerator provides random prompt selection from a list.
// - Journal saves/loads entries using " | " separator in text files.
// 
// EXCEEDING REQUIREMENTS - CREATIVITY FEATURES:
// 1. WORD COUNT TRACKING: Each entry automatically tracks the number of words written.
//    This helps users see their writing progress and effort over time.
// 2. ENTRY STATISTICS: When displaying entries, the program shows:
//    - Entry numbering (Entry 1, Entry 2, etc.) for easy reference.
//    - Word count for each individual entry.
//    - Total entry count and total words written across all entries.
//    These statistics help users visualize their journaling habits.
// 3. FILENAME VALIDATION: The program validates user input for filenames to prevent
//    null/empty entries and provide clear error messages.
// 4. PROFESSIONAL CLASS DESIGN: Private fields use _underscoreCamelCase naming convention
//    per C# style guidelines. Methods use PascalCase. Classes demonstrate proper abstraction.

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
            Console.WriteLine($"(Currently: {journal.GetEntryCount()} entries)");
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
