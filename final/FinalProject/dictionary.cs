using System.ComponentModel;

class Dict
{
    private Dictionary<string, string> words;
    private string FileName;
    private string lang;
    public Dict()
    {
        words = new Dictionary<string, string>();
        Console.WriteLine("Which lang would you like to work on today?");
        Console.Write("If you want to work on a new language, type 'new': ");
        string input = Console.ReadLine();
        if (input.ToLower() == "new")
        {
            Console.Write("Enter the name of the new language: ");
            lang = Console.ReadLine();
            FileName = "master.txt";
        }
        else
        {
            lang = input;
            FileName = lang + ".txt";
        }
            readfile();
    }
    public void addword()
    {

    }
    public void removeword()
    {

    }
    public void readfile()
    {
        if (File.Exists(FileName))
        {
            using (StreamReader reader = new StreamReader(FileName))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split('=');
                    if (parts.Length == 2)
                    {
                        words[parts[0].Trim()] = parts[1].Trim();
                    }
                    if (parts.Length == 1)
                    {
                        words[parts[0].Trim()] = ""; // Handle case where no translation is provided
                    }
                    else
                    {
                        Console.WriteLine($"Invalid line format: {line}");
                    }
                }
            }
        }
        else
        {
            Console.WriteLine("File not found. Starting with an empty dictionary.");
        }
    }
    public void writefile()
    {
        // Logic to write the words dictionary to a file
    }
    public void searchdict()
    {

    }
    public void printdict()
    {

    }
}