abstract class Goal
{
    protected string _name;
    protected string _description;
    protected int _points;
    protected bool _isComplete;
    protected string _type;

    protected Goal(string name, string description, int points, bool isComplete, string type)
    {
        _name = name;
        _description = description;
        _points = points;
        _isComplete = isComplete;
        _type = type;
    }

    abstract public void Record(Rewards r);
    public virtual void Display(int i)
    {
        Console.WriteLine($"{i}. {_type}: {_name} - {_description} - Points: {_points} - status: {_isComplete}");
    }
    public virtual string Save_String()
    {
        string saver = $"{_name}|{_description}|{_points}|{_isComplete}|{_type}";
        return saver;
    }
    public bool GetStatus()
    {
        return _isComplete;
    }
}