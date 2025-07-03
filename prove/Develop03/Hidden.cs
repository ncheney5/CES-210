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
        List<string> words = _scriptures.GetSplitVerses(); // This is actually a flat word list
        Random random = new Random();

        int wordsToHide = random.Next(1, 4); // 1 to 3 words

        int attempts = 0;
        while (_hiddenWords.Count < words.Count && wordsToHide > 0 && attempts < 100)
        {
            int indexToHide = random.Next(words.Count);
            string wordToHide = words[indexToHide];

            // Make sure the word isn’t already hidden and is not just punctuation
            if (!_hiddenWords.Contains(wordToHide) )//&& !string.IsNullOrWhiteSpace(wordToHide))
            {
                _hiddenWords.Add(wordToHide);
                Console.WriteLine($"Hiding word: {wordToHide}");
                wordsToHide--;
            }

            attempts++;    
        }
    }

    public List<string> GetHiddenWords()
    {
        return _hiddenWords;
    }
}
