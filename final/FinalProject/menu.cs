class Menu
{
    private bool run = true;
    private Rules rules;
    private Dict dictionary;
    private string[] names;
    public Menu()
    {
        dictionary = new Dict();
        names = dictionary.getnames();
        bool neww = dictionary.getneww();
        rules = new Rules(names,neww);
        mainMenu();
    }
    private void mainMenu()
    {
        while (run)
        {
            Console.Clear();
            Console.WriteLine("welcome to conlanging");
            Console.WriteLine("what would you like to work on?");
            Console.WriteLine("1. select rules \n 2. add a new rule \n 3. order the rules \n 4. compile the dictionary \n 5. search the dictionray \n 6. translate sentences \n 7. add word to the dictionary \n 8.remove words from the dictionay \n 9. exit");
            Console.Write("what is your selection?: ");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    rules.SelectRule();
                    break;
                case "2":
                    rules.NewRule();
                    break;
                case "3":
                    rules.orderRules();
                    break;
                case "4":
                    rules.ApplyChanges(dictionary);
                    break;
                case "5":
                    dictionary.searchdict();
                    break;
                case "6":
                    Console.Write("Please enter the sentence you would like to translate: ");
                    string sentence = Console.ReadLine();
                    Translator translator = new Translator(sentence, dictionary);
                    break;
                case "7":
                    dictionary.addword();
                    break;
                case "8":
                    dictionary.removeword();
                    break;
                case "9":
                    run = false;
                    dictionary.writefile();
                    break;
                default:
                    Console.WriteLine("Invalid selection, please try again.");
                    break;
            }
        }
    }
}