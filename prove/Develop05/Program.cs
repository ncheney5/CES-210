using System;
using System.ComponentModel.Design;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Develop05 World!");
        Console.WriteLine("which goal file do you wish to run?");
        Console.Write("file name: ");
        string fileName = Console.ReadLine();
        fileName = fileName.Trim();
        fileName = fileName + ".txt";
        string content;
        if (System.IO.File.Exists(fileName))
        { }
        else
        {
            Console.Write("a file with that name does not exist, would you like to create it? (y/n): ");
            string response = Console.ReadLine();
            if (response.ToLower() == "y")
            {
                try
                {
                    using (System.IO.File.Create(fileName))
                    {
                        Console.WriteLine("File created successfully.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred while creating the file: " + ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Exiting without creating a file.");
            }

        }
        Menu mainMenu = new Menu(fileName);
    }
}