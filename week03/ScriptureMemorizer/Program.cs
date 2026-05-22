using System;

class Program
{
    static void Main()
    {
        // Create a scripture with reference and text
        Reference reference = new Reference("John", 3, 16);
        Scripture scripture = new Scripture(reference,
            "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.");

        // Main program loop
        while (!scripture.IsCompletelyHidden())
        {
            scripture.Display();
            Console.Write("Press Enter to continue or type 'quit' to exit: ");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                break;
            }

            scripture.HideRandomWords();
        }

        // Display final state with all words hidden
        if (scripture.IsCompletelyHidden())
        {
            scripture.Display();
            Console.WriteLine("Congratulations! You've completed the scripture memorization challenge.");
        }
    }
}
