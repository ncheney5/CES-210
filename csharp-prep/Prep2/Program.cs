using System;
using System.Formats.Asn1;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("what is the grade percentage? ");
        string percentage = Console.ReadLine();
        int percent= int.Parse(percentage);
        string letter;
        if (percent>90)
        {  
            letter ="A";
        }
        else if (percent>80)
        {
            letter="B";
        }
        else if (percent>70)
        {
            letter="C";
        }
        else if (percent>60)
        {
            letter="D";
        }
        else
        {
            letter="F";
        }
        if (percent>70)
        {
            Console.WriteLine($"You got a {letter}");
            Console.WriteLine("You passed the class! Congradualtions");
        }
        else
        {
            Console.WriteLine($"You got a {letter}");
            Console.WriteLine("you did not pass");
        }
    }
}