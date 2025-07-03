using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


class Scriptures
{
    private Refrence _reference;
    private string _versesText;

    private List<string> _SplitVerses;

    public Scriptures(Refrence reference)
    {
        _reference = reference;
        LoadVersesFromJson();
        Split();

        if (string.IsNullOrEmpty(_versesText))
        {
            throw new InvalidOperationException($"No verses found for the given reference: {string.Join(" ", _reference.GetReferance())}");
        }
    }

    private void LoadVersesFromJson()
    {
        string jsonFilePath = @"C:\Users\Nate\Desktop\CES-210\prove\Develop03\bin\Debug\net8.0\book-of-mormon.json";

        if (!File.Exists(jsonFilePath))
        {
            throw new FileNotFoundException("The JSON file containing scripture verses was not found.", jsonFilePath);
        }

        try
        {
            string jsonContent = File.ReadAllText(jsonFilePath);
            var scriptureData = JsonSerializer.Deserialize<ScriptureData>(jsonContent);

            string book = _reference.GetReferance()[0];
            int chapter = int.Parse(_reference.GetReferance()[1]);
            int verse = int.Parse(_reference.GetReferance()[2]);

            var match = scriptureData.books
                .FirstOrDefault(b => b.book.Equals(book, StringComparison.OrdinalIgnoreCase))?
                .chapters.FirstOrDefault(c => c.chapter == chapter)?
                .verses.FirstOrDefault(v => v.verse == verse);

            if (match != null)
            {
                _versesText = match.text;
            }
            else
            {
                _versesText = null;
            }
        }
        catch (JsonException ex)
        {
            throw new InvalidOperationException("Error reading the JSON file.", ex);
        }
    }
    public void DisplayScripture(List<string> hiddenWords = null)
    {
        if (hiddenWords == null || !hiddenWords.Any())
        {
            Console.WriteLine($"Reference: {string.Join(" ", _reference.GetReferance())}");
            Console.WriteLine($"Text: {_versesText}");
        }
        else
        {
            string displayedText = _versesText;

            foreach (var word in hiddenWords)
            {
                displayedText = Regex.Replace(
                    displayedText,
                    $@"\b{Regex.Escape(word)}\b",
                    new string('_', word.Length),
                    RegexOptions.IgnoreCase
                );
            }

            Console.WriteLine($"Reference: {string.Join(" ", _reference.GetReferance())}");
            Console.WriteLine($"Text: {displayedText}");
        }
    }

    public void Split()
    {
        if (string.IsNullOrEmpty(_versesText))
        {
            throw new InvalidOperationException("No verses text available to split.");
        }

        // _SplitVerses = _versesText.Split(new[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).ToList()
        _SplitVerses = _versesText.Split(' ').ToList();
    }
    public string GetText()
    {
        if (string.IsNullOrEmpty(_versesText))
        {
            throw new InvalidOperationException("No verses text available.");
        }
        return _versesText;
    }

    public List<string> GetSplitVerses()
    {
        if (_SplitVerses == null || !_SplitVerses.Any())
        {
            throw new InvalidOperationException("No split verses available. Please call Split() first.");
        }
        return _SplitVerses;
    }
}