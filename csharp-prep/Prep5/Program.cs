using System;
using System.Globalization;
using System.Runtime.CompilerServices;

class Program
{
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the program!");
    }
    static string GetUserName()
    {
        Console.Write("Please enter your name: ");
        string name=Console.ReadLine();
        return name;
    }
    static int GetUserNumber()
    {
        Console.Write("Please enter your number: ");
        int num=int.Parse(Console.ReadLine());
        return num;
    }
    static int GetSquareNumber(int num)
    {
        int n=num;
        return n;
    }
    static void Main(string[] args)
    {
        DisplayWelcome();
        string name=GetUserName();
        int num=GetUserNumber();
        int square=GetSquareNumber(num);
        Console.WriteLine($"{name}, your fave number ({num}) squared is {square}");
    }
}