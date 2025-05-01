using System;
using System.Text.Json;

class Program
{
    static void Main(string[] args)
    {
        List<int> num= new List<int>();
        bool run= true;
        Console.WriteLine ("what numbers do you want to add?");
        while (run)
        {
            Console.Write("num: ");
            int car= int.Parse(Console.ReadLine());
            if (car==0)
            {
                run=false;
            }
            else
            {
                num.Add(car);
            }
        }
        int z=0;
        foreach (int why in num)
        {
            z=z+why;
        }
        Console.WriteLine($"the total is: {z}");
        int t=num.Count;
        z=z/t;
        Console.WriteLine($"the average is: {z}");
        int high=0;
        int low=1000000000;
        foreach (int why in num)
        {
            if (why>high)
            {
                high=why;
            }
            if (why<low)
            {
                low=why;
            }
        }
        Console.WriteLine($"the high is: {high}");
        Console.WriteLine($"the low is: {low}");
    }
}