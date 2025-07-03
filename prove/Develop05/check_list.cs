class Check_list : goal
{
    private int _numberOfTimesCompleted;
    private int _targetCount;

    public Check_list(string name, string description, int points, string type, int targetCount)
        : base(name, description, points, false, type)
    {
        _numberOfTimesCompleted = 0;
        _targetCount = targetCount;
    }
    public Check_list(string name, string description, int points, string type, int targetCount, int numberOfTimesCompleted)
        : base(name, description, points, false, type)
    {
        _numberOfTimesCompleted = numberOfTimesCompleted;
        _targetCount = targetCount;
    }
    public override void Display(int i)
    {
        Console.WriteLine($"{i}. {_type}: {_name} - {_description} - Points: {_points} - status: {_isComplete} \n - Completed: {_numberOfTimesCompleted}/{_targetCount}");
    }
    public override void Record(rewards r)
    {
        if (_numberOfTimesCompleted < _targetCount)
        {
            _numberOfTimesCompleted++;
            r.AddPoints(_points);
            if (_numberOfTimesCompleted == _targetCount)
            {
                r.AddPoints(50 * _targetCount);
                _isComplete = true;
            }
        }
        else
        {
            Console.WriteLine("Goal already completed.");
        }
    }
    public override string save_string()
    {
        string saver = $"{_name}|{_description}|{_points}|{_isComplete}|{_type}|{_numberOfTimesCompleted}|{_targetCount}";
        return saver;
        // Logic to save the string to a file or database
    }
}