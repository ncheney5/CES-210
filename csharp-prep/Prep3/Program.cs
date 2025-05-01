using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator= new Random();
        int over=randomGenerator.Next(1,11);
        bool run= true;
        while (run)
        {
            string Guess="";
            Console.Write("Guess the Number: ");
            Guess=Console.ReadLine();
            int num= int.Parse(Guess);
            if (num== over)
            {
                Console.WriteLine("good work you got it");
                run=false;
            }
            else if (num>over)
            {
                Console.WriteLine("Too high, try again");
            }
            else if (num<over)
            {
                Console.WriteLine("too low, tray again");
            }
        }
    }
}