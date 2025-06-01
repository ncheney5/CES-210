class HiddenScrptureWords
{
    private List<string> _hiddenWords = new List<string>();
    Scriptures _scriptures;

    public HiddenScrptureWords(Scriptures scriptures)
    {
        _scriptures = scriptures;
    }

    public void HideWords()
    {
        List<string> verses = _scriptures.GetSplitVerses();
        Console.WriteLine("why 1");
        
        Random random = new Random();
        
        foreach (string verse in verses)
        {
            Console.WriteLine("why 2");
            string[] words = verse.Split(' ');
            int wordsToHide = random.Next(1, 4); // Hide 1 to 3 words
            Console.WriteLine("why 3");
            for (int i = 0; i < wordsToHide && words.Length > 0; i++)
            {
                int indexToHide = random.Next(words.Length);
                string wordToHide = words[indexToHide];

                // Ensure the word is not already hidden
                if (!_hiddenWords.Contains(wordToHide))
                {
                    _hiddenWords.Add(wordToHide);
                    Console.WriteLine($"Hiding word: {wordToHide}");
                }

                // Remove the hidden word from the array to avoid hiding it again
                words = words.Where((w, index) => index != indexToHide).ToArray();
            }

        }
    }

    public List<string> GetHiddenWords()
    {
        return _hiddenWords;
    }
}
