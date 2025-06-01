public class ScriptureVerse
{
    public string reference { get; set; }
    public string text { get; set; }
    public int verse { get; set; }
}

public class Chapter
{
    public int chapter { get; set; }
    public string reference { get; set; }
    public List<ScriptureVerse> verses { get; set; }
}

public class Book
{
    public string book { get; set; }
    public List<Chapter> chapters { get; set; }
}

public class ScriptureData
{
    public List<Book> books { get; set; }
}
