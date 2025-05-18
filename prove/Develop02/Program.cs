using System;


class Program
{
    public void WriteToFile(string filename)
    {
        using (StreamWriter outputfile = new StreamWriter(filename))
        {

        }
    }
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to your Journal!");
        Console.Write("Please enter the name of your journal file or type new to create one: ");
        string filename = Console.ReadLine();
        if (filename.ToLower() == "new")
        {
            Console.Write("Please enter a name for your new journal file: ");
            filename = Console.ReadLine();
        }
        else
        {
            Console.WriteLine($"Loading journal from {filename}...");
            // Load existing journal entries from the file
        }
        bool run = true;
        Journal journal = new Journal(filename);

        while (run)
        {
            Console.WriteLine("Welcome to your Journal!");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. View entries");
            Console.WriteLine("3. Save entries to file");
            Console.WriteLine("4. delete entries");
            Console.WriteLine("5. Exit");
            Console.Write("Please select an option: ");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.WriteLine("would you like to answer random questions or make your own?");
                    Console.WriteLine("1. Random questions");
                    Console.WriteLine("2. Make your own entry");
                    Console.Write("Please select an option: ");
                    string questionChoice = Console.ReadLine();
                    JournalEntry journalEntry = new JournalEntry();
                    switch (questionChoice)
                    {
                        case "1":
                            Console.Write("How many questions would you like to answer?: ");
                            int numQuestions = int.Parse(Console.ReadLine());
                            journalEntry.GetQuestions(numQuestions);
                            journalEntry.GetAnswers();
                            break;
                        case "2":
                            journalEntry.ownEntry();
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                    string entry = journalEntry.createEntry();
                    journal.addEntry(entry);
                    break;
                case "2":
                    Console.WriteLine("Viewing entries...");
                    journal.readjournal();
                    break;
                case "3":
                    Console.WriteLine("Saving entries to file...");
                    journal.WriteToFile();
                    break;
                case "4":
                    journal.deleteEntry();
                    break;
                case "5":
                    Console.WriteLine("Exiting the program...");
                    run = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
                    
            }
        }
    }
}

