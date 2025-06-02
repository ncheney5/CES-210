using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment assignment = new Assignment("John Doe", "Math Homework");
        Console.WriteLine(assignment.GetSummary());
        Math mathAssignment = new Math("John Doe", "Math Homework", "Section 5.2", "1-10");
        Console.WriteLine(mathAssignment.GetHomeworkList());
        Console.WriteLine(mathAssignment.GetSummary());
        EnglishAssignment englishAssignment = new EnglishAssignment("Jane Doe", "Essay Writing", "The Great Gatsby Analysis");
        Console.WriteLine(englishAssignment.GetWritingInformation());
        Console.WriteLine(englishAssignment.GetSummary());
    }
}