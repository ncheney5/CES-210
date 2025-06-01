using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter a reference (e.g., 'John 3:16-18' — add a space between the book and chapter): ");
        string input = Console.ReadLine();
        Console.WriteLine("stop 1");
        Refrence refrence = new Refrence(input);
        Console.WriteLine("stop 2");
        Scriptures scriptures = new Scriptures(refrence);
        Console.WriteLine("stop 3");
        HiddenScrptureWords hiddenWords = new HiddenScrptureWords(scriptures);
        Console.WriteLine("stop 4");
        // Consolidated word count: total number of words across all verses
        int totalWords = scriptures.GetSplitVerses().Sum(verse => verse.Split(' ').Length);
        Console.WriteLine("stop 5");
        bool run = true;

        while (run)
        {
            Console.Clear();
            Console.WriteLine("stop 6");
            scriptures.DisplayScripture(hiddenWords.GetHiddenWords());

            if (hiddenWords.GetHiddenWords().Count >= totalWords)
            {
                Console.WriteLine("\nAll words are hidden! Press Enter to exit.");
                Console.ReadLine();
                break;
            }

            Console.WriteLine("\nPress Enter to hide more words, or type 'q' to quit.");
            string command = Console.ReadLine()?.ToLowerInvariant();

            if (command == "q")
            {
                run = false;
            }
            else
            {
                Console.WriteLine("stop 7");
                hiddenWords.HideWords();
            }
        }
    }
}
