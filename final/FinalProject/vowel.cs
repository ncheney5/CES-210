using System.Text.RegularExpressions;

class Vowel : SoundChangeParent
{
    public Vowel(string name, string[] rule, bool start, bool fin, bool middle) : base(name, rule, start, fin, middle)
    {
    }
    override public void ApplyChange(Dict lang_name)
    {
        //this is now useless due to it being more conviante in the dictionary
    }
}