abstract class SoundChangeParent
{
    protected string name;
    private string[] rule;
    private bool start;
    private bool fin;
    private bool mid;

    public SoundChangeParent(string name, string[] rule, bool start, bool fin, bool middle)
    {
        this.name = name;
        this.rule = rule;
        this.start = start;
        this.fin = fin;
        this.mid = middle;
    }
    abstract public void ApplyChange(Dict lang_name);

    public string GetName()
    {
        return name;
    }
    public bool get_Start()
    {
        return start;
    }
    public bool get_Fin()
    {
        return fin;
    }
    public bool get_Mid()
    {
        return mid;
    }
    public string[] GetRule()
    {
        return rule;
    }
}