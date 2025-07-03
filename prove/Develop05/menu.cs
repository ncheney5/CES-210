using System.IO.Enumeration;

class menu
{
    private bool _isRunning;
    private string _fileName;
    private Goal_list _goalList;
    private rewards rewards;
    public menu(string fileName)
    {
        _fileName = fileName;
        _isRunning = true;
        _goalList = new Goal_list(_fileName);
        rewards = new rewards(fileName);

        mainmenu();

    }
    private void mainmenu()
    {
        while (_isRunning)
        {
            Console.Clear();
            Console.WriteLine("Welcome to goal quest!!");
            Console.WriteLine("1. Create a new goal");
            Console.WriteLine("2. display / mark goals as complete");
            Console.WriteLine("3. redeem rewards");
            Console.WriteLine("4. Exit");
            Console.Write("Please select an option (1-5): ");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    _goalList.addnewgoal(); // Call method to add a new goal
                    break;
                case "2":
                    _goalList.display(rewards); // Call method to display all goals
                    break;
                case "3":
                    Console.Clear();
                    rewards.spendpoints(); // Call method to redeem rewards
                    break;
                case "4":
                    _isRunning = false;
                    _goalList.save(_fileName, rewards.getpoints); // Save goals before exiting
                    Console.WriteLine("Goals saved successfully.");
                    Console.WriteLine("Exiting the program. Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid option, please try again.");
                    break;
            }
        }
    }
}