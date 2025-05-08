using System;
using System.ComponentModel.DataAnnotations;

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


class Resume
{
private string _name;
private List<Job> _jobs = new List<Job>();

    public Resume(string name)
    {
        _name = name;
    }
    public void AddJob(Job job)
    {
        _jobs.Add(job);
    }
    public void Show()
    {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine("Jobs:");
        foreach (Job job in _jobs)
        {
            job.Show();
        }
    }

}
class Program
{
    static void Main(string[] args)
    {
        Resume myResume = new Resume("John Doe");
        Job job1 = new Job("Company A", "Software Engineer", 2015, 2018);
        Job job2 = new Job("Company B", "Senior Developer", 2018, 2021);
        myResume.AddJob(job1);
        myResume.AddJob(job2);
        myResume.Show();
        
    }
}