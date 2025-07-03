abstract class goal
{
    protected string _name;
    protected string _description;
    protected int _points;
    protected bool _isComplete;
    protected string _type;

    protected goal(string name, string description, int points, bool isComplete, string type)
    {
        _name = name;
        _description = description;
        _points = points;
        _isComplete = isComplete;
        _type = type;
    }

    abstract public void Record(rewards r);
    public virtual void Display(int i)
    {
        Console.WriteLine($"{i}. {_type}: {_name} - {_description} - Points: {_points} - status: {_isComplete}");
    }
    public virtual string save_string()
    {
        string saver = $"{_name}|{_description}|{_points}|{_isComplete}|{_type}";
        return saver;
    }
    public bool getstatus()
    {
        return _isComplete;
    }
}