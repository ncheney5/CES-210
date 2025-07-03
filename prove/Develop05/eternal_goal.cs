class Eternal_Goal : goal
{
    private int _numberoftimesCompleted;

    public Eternal_Goal(string name, string description, int points, string type)
        : base(name, description, points, false, type)
    {
        _numberoftimesCompleted = 0;

    }
    public Eternal_Goal(string name, string description, int points, string type, int numberoftimesCompleted)
        : base(name, description, points, false, type)
    {
        _numberoftimesCompleted = numberoftimesCompleted;
    }
    public override void Display(int i)
    {
        Console.WriteLine($"{i}. {_type}: {_name} - {_description} - Points: {_points} - status: {_isComplete} - Completed: {_numberoftimesCompleted} times");
    }
    public override void Record(rewards r)
    {
        _numberoftimesCompleted++;
        r.AddPoints(_points);
    }
    public override string save_string()
    {
        string saver = $"{_name}|{_description}|{_points}|{_isComplete}|{_type}|{_numberoftimesCompleted}";
        return saver;
    }
}