using System.Security;

class Translator
{
    private string Sentence;
    private Dict dictionary;
    private List<string> translation;
    public Translator(string sentence, Dict dict)
    {
        Sentence = sentence.ToLower();
        dictionary = dict;
        translation = new List<string>();
        Translate();
    }
    public void Translate()
    {
        string[] parts = Sentence.Split(" ");
        Dictionary<string, string> words = dictionary.GetWords();
        foreach (string part in parts)
        {
            string newPart = part;
            string peice = "";
            char[] puncuuation = ['.', ',', '!', '?', ';', ':', '-', '(', ')', '"'];
            foreach (char mark in puncuuation)
            {
                if (part.Contains(mark))
                {
                    newPart = part.Replace(mark.ToString(), "");
                    peice = mark.ToString();
                }
            }
            if (words.ContainsKey(newPart))
                {
                    translation.Add(words[newPart]+peice);
                }
                else
                {
                    translation.Add(newPart);
                }
            
        }
        foreach (string morph in translation)
        {
            Console.Write($"{morph} ");
        }
        Console.WriteLine("");
        Console.WriteLine("press any key to continue...");
        Console.ReadKey();
    }
}