using System.Globalization;

class rewards
{
    private string _fileName;
    private int _points;
    private Dictionary<string, int> rewardlist;
    public rewards(string fileName)
    {
        _fileName = fileName;
        _points = 0; // Initialize points to zero
        LoadPoints();
        LoadRewardList();
    }
    private void LoadRewardList()
    {
        // Logic to load the reward list from a file or database
        rewardlist = new Dictionary<string, int>();
        if (System.IO.File.Exists("rewartlist.txt"))
        {
            using (StreamReader reader = new StreamReader("rewartlist.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split('|');
                    if (parts.Length == 2 && int.TryParse(parts[1], out int points))
                    {
                        rewardlist[parts[0]] = points; // Add reward to the list
                    }
                    else
                    {
                        Console.WriteLine($"Invalid reward format in the file: {line}");
                    }
                }
            }
        }
        else
        {
            Console.WriteLine("Reward file does not exist. Starting with an empty reward list.");
        }
    }
    private void LoadPoints()
    {
        // Logic to load points from the file
        if (System.IO.File.Exists(_fileName))
        {
            using (StreamReader reader = new StreamReader(_fileName))
            {
                // load the points from the first line of the file
                string line = reader.ReadLine();
                if (int.TryParse(line, out int loadedPoints))
                {
                    _points = loadedPoints;
                }
                else
                {
                    Console.WriteLine("Invalid points format in the file. Starting with 0 points.");
                    _points = 0;
                }
            }
        }
    }
    public int getpoints
    {
        get { return _points; }
    }
    public void AddPoints(int points)
    {
        // Logic to add points to the user's total
        Console.WriteLine($"You have earned {points} points!");
        _points += points;
    }
    public void spendpoints()
    {
        // Logic to spend points on rewards
        Console.WriteLine($"Available rewards: {_points}");
        Console.WriteLine("Please select a reward to redeem:");
        int i = 1;
        foreach (var reward in rewardlist)
        {
            Console.WriteLine($"{i}. {reward.Value} - {reward.Key} points");
            i++;
        }
        Console.Write("Enter the number of the reward you want to redeem: ");
        string input = Console.ReadLine();
        int num = int.Parse(input);
        num--; // Adjust for zero-based index
        if (num >= 0 && num <= rewardlist.Count)
        {
            var reward = rewardlist.ElementAt(num);
            if (_points >= reward.Value)
            {
                _points -= reward.Value;
                Console.WriteLine($"You have redeemed {reward.Key} for {reward.Value} points.");
                Console.WriteLine($"You now have {_points} points left.");
                Console.Write("Press any key to continue...");
                Console.ReadKey();
                // Logic to give the user the reward
            }
            else
            {
                Console.WriteLine("You do not have enough points to redeem this reward.");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
        else
        {
            Console.WriteLine("Invalid selection. Please try again.");
        }

    }
    
}