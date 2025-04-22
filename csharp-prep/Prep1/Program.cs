using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Prep1 World!");
        Console.Write("what is your first name?" );
        string name = Console.ReadLine();
        Console.Write("what is your last name?" );
        String last = Console.ReadLine();
        Console.WriteLine($"your name is {last}, {name} {last}");
    }
}