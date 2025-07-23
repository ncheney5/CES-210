using System.ComponentModel;
using System.Diagnostics.SymbolStore;
using System.Formats.Asn1;
using System.Text.RegularExpressions;

class Dict
{
    private Dictionary<string, string> words;
    private string FileName;
    private string lang;
    private bool neww;
    private string[] rule_names;
    public Dict()
    {
        words = new Dictionary<string, string>();
        Console.WriteLine("Which lang would you like to work on today?");
        Console.Write("If you want to work on a new language, type 'new': ");
        string input = Console.ReadLine().Trim();
        if (input.ToLower() == "new")
        {
            Console.Write("Enter the name of the new language: ");
            lang = Console.ReadLine();
            FileName = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"..\..\..\data", $"{lang}.txt"));

            neww = true;
        }
        else
        {
            lang = input;
            FileName = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"..\..\..\data", $"{lang}.txt"));   
            neww = false;
        }
        readfile();
    }
    public void addword()
    {
        Console.Clear();
        Console.Write("Please enter the word you would like to add: ");
        string word = Console.ReadLine();
        if (words.ContainsKey(word))
        {
            Console.WriteLine("This word is already in the Dictionary");
            return;
        }
        else
        {
            words[word] = "";
            Console.WriteLine($"{word} Has been added to the dictionary");
        }
        Console.WriteLine("press any key to continue...");
        Console.ReadKey();
    }
    public void removeword()
    {
        Console.Write("what word would you like to remove, to exit type 1 : ");
        string word = Console.ReadLine();
        if (word == "1")
        {
            return;
        }
        else
        {
            words.Remove(word);
        }
    }
    public void readfile()
    {
        if (neww)
        {
            using (StreamReader reader = new StreamReader(Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"..\..\..\data", "master.txt"))))
           {
                string line;
                while ((line = reader.ReadLine()) !=null)
                {
                    words[line.ToLower()] = "";
                }
            }
        }
        else
        {
            if (File.Exists(FileName))
            {
                using (StreamReader reader = new StreamReader(FileName))
                {
                    string line;
                    int i = 1;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (i == 1)
                        {
                            rule_names = line.Split(",");
                            i++;
                        }
                        if (i == 2)
                        {
                            string[] parts = line.Split("=");
                            if (parts.Length == 2)
                            {
                                words[parts[0].Trim().ToLower()] = parts[1].Trim().ToLower();
                            }
                            if (parts.Length == 1)
                            {
                                words[parts[0].Trim()] = ""; // Handle case where no translation is provided
                            }
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("File not found. Starting with an empty dictionary.");
            }
        }
    }
    public void writefile()
    {
        if (neww)
        {
            using (StreamWriter writer = new StreamWriter(FileName))
            {
                writer.WriteLine(rule_names);
                foreach (var entry in words)
                {

                    writer.WriteLine($"{entry.Key}={entry.Value}");
                }
            }
            Console.WriteLine($"New dictionary file '{FileName}' created.");
        }
        else
        {
            using (StreamWriter writer = new StreamWriter(FileName, true))
            {
                writer.WriteLine(rule_names);
                foreach (var entry in words)
                {
                    writer.WriteLine($"{entry.Key}={entry.Value}");
                }
            }
            Console.WriteLine($"Dictionary file '{FileName}' updated.");
        }
    }
    public void searchdict()
    {
        Console.Clear();
        Console.Write("what word would you like to find: ");
        string answer = Console.ReadLine();
        answer.ToLower();
        if (words.ContainsKey(answer))
        {
            string new_wrod = words[answer];
            Console.WriteLine($"{answer} in the new lang is {new_wrod}");
            Console.WriteLine("to exit press any key...");
            Console.ReadKey();
        }
        else
        {
            Console.WriteLine($"{answer} is not in the dictionary, please check the spelling and try again");
            Console.WriteLine("press any key to continue...");
            Console.ReadLine();
        }
    }
    public void printdict()
    {
        foreach (string word in words.Keys)
        {
            Console.WriteLine($"{word} : {words[word]}");
        }
    }
    public Dictionary<string, string> GetWords()
    {
        return words;
    }
    public void WriteDictionary(List<Regex> regexs, List<string> replaces)
    {
        foreach (string word in words.Keys)
        {
            string translatedWord = word;
            for (int i = 0; i < regexs.Count; i++)
            {
                translatedWord = regexs[i].Replace(translatedWord, replaces[i]);
            }
            words[word] = translatedWord;
        }
    }
    public string[] getnames()
    {
        return rule_names;
    }
    public bool getneww()
    {
        return neww;
    }
}