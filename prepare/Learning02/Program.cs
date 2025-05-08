using System;
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