class Job
{
    private string _company;
    private string _jobTitle;
    private int _startDate;
    private int _endDate;

    public Job(string company, string jobTitle, int startDate, int endDate)
    {
        _company = company;
        _jobTitle = jobTitle;
        _startDate = startDate;
        _endDate = endDate;
    }
    public void Show()
    {
        Console.WriteLine($"{_jobTitle} at {_company} from {_startDate} to {_endDate}");
    }
}