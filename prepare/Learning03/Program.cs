using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction1 f1 = new Fraction1();
        Console.WriteLine(f1.ToString());
        Console.WriteLine(f1.ToDouble());

        Fraction1 f2 = new Fraction1(5);
        Console.WriteLine(f2.ToString());
        Console.WriteLine(f2.ToDouble());

        Fraction1 f3 = new Fraction1(3, 4);
        Console.WriteLine(f3.ToString());
        Console.WriteLine(f3.ToDouble());

        Fraction1 f4 = new Fraction1(1, 3);
        Console.WriteLine(f4.ToString());
        Console.WriteLine(f4.ToDouble());
    }
}