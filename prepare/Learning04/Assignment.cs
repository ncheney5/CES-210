class Assignment
{
    private string _StudentName;
    private string _Topic;

    public Assignment(string studentName, string topic)
    {
        _StudentName = studentName;
        _Topic = topic;
    }

    public string GetSummary()
    {
        return $"{_StudentName} - {_Topic}";
    }
        
}