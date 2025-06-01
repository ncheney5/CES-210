using Microsoft.VisualBasic;

class Refrence
{
    private string _refrence;
    private List<string> _verses = new List<string>();
    private string _book;
    private string _chapter;
    public Refrence(string refrance)
    {
        _refrence = refrance;
        string[] parts = refrance.Split(" ");
        if (parts.Length > 1)
        {
            if (parts.Length < 3)
            {
                _book = parts[0];
            }
            else
            {
                _book = parts[0] + " " + parts[1];
            }
        }
        multiple(refrance);
        
    }
    private void multiple(string refrence)
    {
        string[] parts = refrence.Split(" ");
        string useful = parts[1];
        parts = useful.Split(":");
        _chapter = parts[0];
        if (parts[1].Contains("-"))
        {
            string[] verses = parts[1].Split("-");
            for (int i = int.Parse(verses[0]); i <= int.Parse(verses[1]); i++)
            {
                _verses.Add(i.ToString());
            }
        }
        else
        {
            _verses.Add(parts[1]);
        }
    }
    public List<string> GetReferance()
    {
        List<string> refrence = new List<string>();
        refrence.Add(_book);
        refrence.Add(_chapter);
        refrence.AddRange(_verses);
        return refrence;
    }


}