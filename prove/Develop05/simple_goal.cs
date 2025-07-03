class Simple : Goal
{
    public Simple(string name, string description,  int points,bool _isComplete, string type)
        : base(name, description, points, isComplete:false, type)
    {
    }
    public override void Record(Rewards r)
    {
        _isComplete = true;
        r.AddPoints(_points);
        Console.WriteLine($"Goal '{_name}' has been marked as complete.");
    }
}