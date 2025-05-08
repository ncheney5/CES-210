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
        bool done = false;
        Console.Write("Enter your name: ");
        string name = Console.ReadLine();
        Resume resume = new Resume(name);
        while (!done)
        {
            Console.Write("Enter job title (or 'done' to finish): ");
            string jobTitle = Console.ReadLine();
            if (jobTitle.ToLower() == "done")
            {
                done = true;
                continue;
            }
            Console.Write("Enter company name: ");
            string company = Console.ReadLine();
            Console.Write("Enter start date (YYYY): ");
            int startDate = int.Parse(Console.ReadLine());
            Console.Write("Enter end date (YYYY): ");
            int endDate = int.Parse(Console.ReadLine());

            Job job = new Job(company, jobTitle, startDate, endDate);
            resume.AddJob(job);
        }
        Console.WriteLine("Resume created:");
        resume.Show();
        
    }
}