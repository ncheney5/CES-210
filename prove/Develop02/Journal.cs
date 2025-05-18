using System.Diagnostics;

class Journal
{
    private string _filename;
    private List<string> _NewEntries = new List<string>();

    public Journal(string filename)
    {
        _filename = filename+".txt";
        openfile();
   }
    
    public void readjournal()
    {
        if (File.Exists(_filename))
        {
            using (StreamReader inputfile = new StreamReader(_filename))
            {
                int i=1;
                foreach (string line in File.ReadLines(_filename))
                {
                    string[] parts = line.Split('#');
                    string date = parts[0];
                    Console.WriteLine($"Entry {i}: {date}");
                    i++;
                }
                Console.WriteLine("Please select an entry to view: ");
                int entryNumber = int.Parse(Console.ReadLine());
                i=1;
                foreach (string line in File.ReadLines(_filename))
                {
                    string[] parts = line.Split('#');
                    if (i == entryNumber)
                    {
                        foreach (string part in parts)
                        {
                            Console.WriteLine(part);
                        }
                        break;
                    }
                    i++;
                }
            }
        
        }
    }
   private void openfile()
   {
       if (File.Exists(_filename))
       {
        Console.WriteLine("Loading journal from file...");
       }
       else
       {
           Console.WriteLine($"File {_filename} does not exist. Creating a new file.");
           using (StreamWriter outputfile = new StreamWriter(_filename))
           {
               
           }
       }
   }
    public void addEntry(string entry)
    {
         _NewEntries.Add(entry);
    }
   public void WriteToFile()
   {
         if (_NewEntries.Count == 0)
         {
              Console.WriteLine("No new entries to write to file.");
              return;
         }
        if (File.Exists(_filename))
        {
            Console.WriteLine("Writing to existing file...");
            using (StreamWriter outputfile = new StreamWriter(_filename, true))
            {
                foreach (string entry in _NewEntries)
                {
                    outputfile.WriteLine(entry);
                }
                Console.WriteLine(Directory.GetCurrentDirectory());
            }
        }
        else
        {
            Console.WriteLine($"Creating new file {_filename}...");
            using (FileStream fs = File.Create(_filename))
            {
                using (StreamWriter outputfile = new StreamWriter(_filename, true))
                {
                    foreach (string entry in _NewEntries)
                    {
                        outputfile.WriteLine(entry);
                    }
                    Console.WriteLine(Directory.GetCurrentDirectory());
                }
            }
        }
        _NewEntries.Clear();
        Console.WriteLine("Entries saved successfully.");
       
   }

    public void deleteEntry()
    {
        int i=1;
        foreach (string line in File.ReadLines(_filename))
        {
            string[] parts = line.Split('#');
            string date = parts[0];
            Console.WriteLine($"{i}: {date}");
            i++;
        }
        Console.Write("Please select an entry to delete: ");
        int entryNumber = int.Parse(Console.ReadLine());
        List<string> lines = File.ReadAllLines(_filename).ToList();
        lines.RemoveAt(entryNumber - 1);
        File.WriteAllLines(_filename, lines);
    }
}