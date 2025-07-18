using System.Net.Http.Headers;
using System.Security;
using System.Security.Authentication.ExtendedProtection;
using System.Text.RegularExpressions;

class Rules
{
    private List<SoundChangeParent> soundChanges;
    private List<string> presetrules;
    private List<SoundChangeParent> presetChanges;
    private string[] rule_names;
    private List<Regex> regexs;
    private List<string> replaces;
    public Rules(string[] names, bool neww)
    {
        this.rule_names = names;
        soundChanges = new List<SoundChangeParent>();
        presetrules = new List<string>();
        presetChanges = new List<SoundChangeParent>();
        regexs = new List<Regex>();
        replaces = new List<string>();

        // Vowels
        string[] rule1 = { "e/i", "a/e", "o/u" }; // General Indo-European vowel raising
        presetrules.Add($"Vowel, Indo-European Vowel Raising, {string.Join(";", rule1)}, true, true, true");

        string[] rule2 = { "o/u", "e/i" }; // Proto-Germanic influence
        presetrules.Add($"Vowel, Germanic Vowel Raising, {string.Join(";", rule2)}, false, true, true");

        string[] rule3 = { "a/e", "e/i", "o/u" }; // Latin to Romance fronting
        presetrules.Add($"Vowel, Latin to Romance Fronting, {string.Join(";", rule3)}, false, true, true");

        string[] rule4 = { "æ/e", "e/i", "o/u" }; // Old English to Middle English changes
        presetrules.Add($"Vowel, Old English Raising, {string.Join(";", rule4)}, true, true, false");

        string[] rule5 = { "u/ü", "ü/i", "a/ä" }; // German umlaut
        presetrules.Add($"Vowel, German Umlaut, {string.Join(";", rule5)}, false, true, true");

        string[] rule6 = { "i/e", "u/o" }; // Vowel lowering (Middle English)
        presetrules.Add($"Vowel, Middle English Lowering, {string.Join(";", rule6)}, false, true, false");

        string[] rule7 = { "e/i", "o/u", "a/e" }; // Latin to Spanish
        presetrules.Add($"Vowel, Latin to Spanish Raising, {string.Join(";", rule7)}, false, true, true");

        string[] rule8 = { "i/ai", "u/au", "e/i", "o/u" }; // Great Vowel Shift
        presetrules.Add($"Vowel, Great Vowel Shift, {string.Join(";", rule8)}, false, true, false");

        string[] rule9 = { "e/i", "o/u" }; // Latin unstressed reduction
        presetrules.Add($"Vowel, Latin Vowel Reduction, {string.Join(";", rule9)}, false, true, true");

        string[] rule10 = { "an/ã", "en/ẽ", "on/õ" }; // French nasalization
        presetrules.Add($"Vowel, Old French Nasalization, {string.Join(";", rule10)}, false, true, true");

        // Consonants
        string[] rule11 = { "p/f", "t/θ", "k/x" };
        presetrules.Add($"Consants, Grimm's Law Part 1 (Voiceless Stops > Fricatives), {string.Join(";", rule11)}, true, true, true");

        string[] rule12 = { "b/p", "d/t", "g/k" };
        presetrules.Add($"Consants, Grimm's Law Part 2 (Voiced Stops > Voiceless Stops), {string.Join(";", rule12)}, true, true, true");

        string[] rule13 = { "bh/b", "dh/d", "gh/g" };
        presetrules.Add($"Consants, Grimm's Law Part 3 (Voiced Aspirates > Voiced Stops), {string.Join(";", rule13)}, true, true, true");

        string[] rule14 = { "f/v", "θ/ð", "s/z", "ʃ/ʒ" };
        presetrules.Add($"Consants, Verner's Law (Voicing After Unstressed Syllables), {string.Join(";", rule14)}, false, true, true");

        string[] rule15 = { "b/β", "d/ð", "g/ɣ" };
        presetrules.Add($"Consants, Latin to Spanish Intervocalic Lenition, {string.Join(";", rule15)}, false, true, false");

        string[] rule16 = { "sc/ʃ", "cg/dʒ", "ġ/j", "c/ʃ" };
        presetrules.Add($"Consants, Old to Middle English Palatalization, {string.Join(";", rule16)}, true, true, false");

        string[] rule17 = { "p/f", "t/ts", "k/kx", "tt/ss" };
        presetrules.Add($"Consants, High German Consonant Shift, {string.Join(";", rule17)}, true, true, true");

        string[] rule18 = { "d/t", "b/p", "g/k", "v/f", "z/s" };
        presetrules.Add($"Consants, Old French Final Devoicing, {string.Join(";", rule18)}, false, false, true");

        string[] rule19 = { "ct/tt", "gn/ñ", "pt/tt", "mn/n" };
        presetrules.Add($"Consants, Latin Cluster Simplification, {string.Join(";", rule19)}, false, true, true");

        string[] rule20 = { "kn/n", "gn/n", "wr/r", "hl/l", "hr/r" };
        presetrules.Add($"Consants, English Initial Cluster Simplification, {string.Join(";", rule20)}, true, false, false");


        presetMaker();
        if (!neww)
        {
            loadrules();
        }
    }
    public void presetMaker()
    {
        foreach (string rule in presetrules)
        {
            string[] parts = rule.Split(',');
            string type = parts[0].Trim();
            string name = parts[1].Trim();
            string[] rules = parts[2].Trim().Split(';');
            bool start = bool.Parse(parts[3].Trim());
            bool fin = bool.Parse(parts[4].Trim());
            bool middle = bool.Parse(parts[5].Trim());

            if (type == "Vowel")
            {
                presetChanges.Add(new Vowel(name, rules, start, fin, middle));
            }
            else if (type == "Consants")
            {
                presetChanges.Add(new Consants(name, rules, start, fin, middle));
            }
        }
    }
    public void NewRule()
    {
        Console.Clear();
        Console.WriteLine("Welcome to the rule maker!");
        Console.Write("would you like to make a new rule for consonants or vowels? (c/v): ");
        string choice = Console.ReadLine().ToLower();
        Console.Write("Please enter the name of the rule:");
        string name = Console.ReadLine();
        Console.WriteLine("Please enter the rules, separated by semicolons (;) exsample (a/e;i/u)");
        Console.Write("In this example, 'a' changes to 'e' and 'i' changes to 'u': ");
        string input = Console.ReadLine();
        string[] rules = input.Split(';');
        Console.Write("Does this rule apply at the start of a word? (true/false): ");
        bool start = bool.Parse(Console.ReadLine());
        Console.Write("Does this rule apply at the end of a word? (true/false): ");
        bool fin = bool.Parse(Console.ReadLine());
        Console.Write("Does this rule apply in the middle of a word? (true/false): ");
        bool middle = bool.Parse(Console.ReadLine());
        if (choice == "c")
            presetChanges.Add(new Consants(name, rules, start, fin, middle));
        else if (choice == "v")
            presetChanges.Add(new Vowel(name, rules, start, fin, middle));
        Console.WriteLine("Rule added successfully!");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
    public void SelectRule()
    {
        Console.Clear();
        Console.WriteLine("select which rules you would like to apply to you lang");
        int index = 1;
        foreach (SoundChangeParent change in presetChanges)
        {
            Console.WriteLine($"{index}. {change.GetName()}");
            index++;
        }
        Console.WriteLine("0. Exit");
        Console.Write("Enter the numbers of the rules you would like to use. seperate with commas (0 to exit): ");
        string input = Console.ReadLine();
        if (input == "0")
        {
            Console.WriteLine("Exiting rule selection.");
            return;
        }
        string[] selectedIndices = input.Split(',');
        foreach (string indexStr in selectedIndices)
        {
            if (int.TryParse(indexStr.Trim(), out int indexNum) && indexNum > 0 && indexNum <= presetChanges.Count)
            {
                soundChanges.Add(presetChanges[indexNum - 1]);
            }
            else
            {
                Console.WriteLine($"Invalid selection: {indexStr}. Please enter a valid number.");
            }
        }
        Console.WriteLine("Selected rules have been added.");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    public void orderRules()
    {
        Console.Clear();
        Console.WriteLine("Here are the rules you have selected:");
        int index = 1;
        foreach (SoundChangeParent change in soundChanges)
        {
            Console.WriteLine($"{index}. {change.GetName()}");
            index++;
        }
        Console.WriteLine("You can reorder the rules by entering the numbers in the order \n you want them to be applied, separated by commas.");
        Console.Write("Enter the order of the rules (e.g., 2,1,3): ");
        string input = Console.ReadLine();
        string[] order = input.Split(',');
        List<SoundChangeParent> orderedChanges = new List<SoundChangeParent>();
        foreach (string indexStr in order)
        {
            if (int.TryParse(indexStr.Trim(), out int indexNum) && indexNum > 0 && indexNum <= soundChanges.Count)
            {
                orderedChanges.Add(soundChanges[indexNum - 1]);
            }
            else
            {
                Console.WriteLine($"Invalid selection: {indexStr}. Please enter a valid number.");
            }
        }
        soundChanges = orderedChanges;
        Console.WriteLine("Rules have been reordered successfully.");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
    public void ApplyChanges(Dict lang_name)
    {
        Dictionary<string, string> words = lang_name.GetWords();
        foreach (SoundChangeParent change in soundChanges)
        {
            string[] rules = change.GetRule();
            foreach (var rule in rules)
            {
                string[] parts = rule.Split('/');
                if (change.get_Start())
                {
                    if (change.get_Mid())
                    {
                        if (change.get_Fin())//ttt
                        {
                            regexs.Add(new Regex($"{parts[0]}"));
                            replaces.Add(parts[1]);
                        }
                        else//ttf
                        {
                            regexs.Add(new Regex($"({parts[0]})."));
                            replaces.Add(parts[1]);
                        }
                    }
                    else
                    {
                        if (change.get_Fin())//tft
                        {
                            regexs.Add(new Regex($"(^({parts[0]})|({parts[0]})$)"));
                            replaces.Add(parts[1]);
                        }
                        else// tff
                        {
                            regexs.Add(new Regex($"^({parts[0]})."));
                            replaces.Add(parts[1]);
                        }
                    }
                }
                else
                {
                    if (change.get_Mid())
                    {
                        if (change.get_Fin())//ftt
                        {
                            regexs.Add(new Regex($".({parts[0]})"));
                            replaces.Add(parts[1]);
                        }
                        else//ftf
                        {
                            regexs.Add(new Regex($".({parts[0]})."));
                            replaces.Add(parts[1]);
                        }
                    }
                    else
                    {
                        if (change.get_Fin())// fft
                        {
                            regexs.Add(new Regex($".({parts[0]})$"));
                            replaces.Add(parts[1]);
                        }
                        else// fff
                        {
                            return;
                        }
                    }
                }
            }
        }
        lang_name.WriteDictionary(regexs, replaces);
    }
    private void loadrules()
    {
        foreach (string rule in rule_names)
        {
            foreach (SoundChangeParent change in presetChanges)
            {
                if (rule == change.GetName())
                {
                    soundChanges.Add(change);
                }
            }
        }
    }

}