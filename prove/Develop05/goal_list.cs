using System.Security.Cryptography.X509Certificates;

class Goal_List
{
    private List<Goal> _goals;

    public Goal_List(string fileName)
    {
        _goals = new List<Goal>();
        if (System.IO.File.Exists(fileName))
        {
            Load(fileName);
        }
        else
        {
            Console.WriteLine("File does not exist. Please create the file first.");
        }
    }
    public void display(Rewards r)
    {
        Console.Clear();
        Console.WriteLine("Here are your goals:");
        int i = 1;
        foreach (Goal g in _goals)
        {
            g.Display(i);
            i++;
        }
        Console.Write("Please select a goal to mark as complete or peress q to return to the main menu: ");
        string input = Console.ReadLine();
        if (input.ToLower() == "q")
        {
            return; // Return to the main menu
        }
        else
        {
            int num = int.Parse(input);
            num--; // Adjust for zero-based index
            if (num >= 0 && num <= _goals.Count)
            {
                _goals[num].Record(r); // Call the Record method on the selected goal
                Console.WriteLine("Goal marked as complete.");
                Console.WriteLine("you now have " + r.GetPoints + " points.");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Invalid selection. Please try again.");
            }
        }

    }
    public void Save(string fileName, int _points)
    {
        for (int i = _goals.Count - 1; i >= 0; i--)
        {
            if (_goals[i].GetStatus())
            {
            _goals.RemoveAt(i);
            }
        }

        System.IO.File.Delete(fileName); // Delete the file before writing
        System.IO.File.Create(fileName).Close(); // Create a new empty file
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            writer.WriteLine(_points); // Write the total points at the top of the file
            // empty the file before writing
            foreach (Goal g in _goals)
            {
                writer.WriteLine(g.Save_String());
            }
        }
    }
    private void Load(string fileName)
    {
        if (System.IO.File.Exists(fileName))
        {
            using (StreamReader reader = new StreamReader(fileName))
            {
                string line;
                int i = 0;
                while ((line = reader.ReadLine()) != null)
                {
                    if (i == 0)
                    {
                        // Skip the first line which contains points
                        i++;
                    }
                    else
                    {
                        string[] parts = line.Split('|');
                        if (parts.Length < 5) continue; // Skip invalid lines
                        string name = parts[0];
                        string description = parts[1];
                        int points = int.Parse(parts[2]);
                        bool isComplete = bool.Parse(parts[3]);
                        string type = parts[4];

                        Goal g;
                        if (type == "Eternal")
                        {
                            int numberOfTimesCompleted = int.Parse(parts[5]);
                            g = new Eternal_Goal(name, description, points, type, numberOfTimesCompleted);
                            // Set numberOfTimesCompleted here
                        }
                        else if (type == "Check")
                        {
                            int numberOfTimesCompleted = int.Parse(parts[5]);
                            int targetCount = int.Parse(parts[6]);
                            g = new Check_List(name, description, points, type, targetCount, numberOfTimesCompleted);
                            // Set numberOfTimesCompleted and targetCount here
                        }
                        else
                        {
                            g = new Simple(name, description, points, isComplete, type);
                        }

                        _goals.Add(g);
                    }
                }
            }
        }
        else
        {
            Console.WriteLine("File does not exist. Please create the file first.");
        }
    }
    public void AddNewGoal()
    {
        Console.WriteLine("What type of goal would you like to create?");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Recurring Goal");
        Console.Write("Please select an option (1-3): ");
        string input = Console.ReadLine();
        Console.Write("Enter the name of the goal: ");
        string name = Console.ReadLine();
        Console.Write("Enter the description of the goal: ");
        string description = Console.ReadLine();
        Console.Write("Enter the points for the goal: ");
        int points = int.Parse(Console.ReadLine());
        if (input == "1")
        {
            Simple newGoal = new Simple(name, description, points, false, "Simple");
            _goals.Add(newGoal);
        }
        else if (input == "2")
        {
            Eternal_Goal newGoal = new Eternal_Goal(name, description, points, "Eternal");
            _goals.Add(newGoal);
        }
        else if (input == "3")
        {
            Console.Write("Enter the target count for the goal: ");
            int targetCount = int.Parse(Console.ReadLine());
            Check_List newGoal = new Check_List(name, description, points, "Check", targetCount);
            _goals.Add(newGoal);
        }
        else
        {
            Console.WriteLine("Invalid option. Please try again.");
        }
        Console.WriteLine($"Goal '{name}' has been added successfully.");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
}