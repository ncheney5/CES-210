using System.ComponentModel;

class JournalEntry
{
    private string[] _questions = {"What did you learn today?", "What was the best part of your day?", "What are you grateful for?",
        "What was the most challenging part of your day?", "What are your goals for tomorrow?", "What made you smile today?",
        "What is something you wish you could change about today?", "What is something you are proud of?", "What is something you want to improve on?",
        "What is something you want to learn more about?", "What is something you want to do more of?",
        "What is something you want to do less of?", "What is something you want to try?", "What is something you want to stop doing?",
        "What is something you want to start doing?", "What is something you want to continue doing?",
        "What is something you want to let go of?", "What is something you want to hold on to?", "who was the most important person in your life today?",
        "who was the most intersting person you met today?"};  
    private string _date=DateTime.Now.ToString("MM/dd/yyyy");
    public List<string> _answer;
    private List<string> _WorkingQuestions; 

    public void GetQuestions(int numQuestions)
    {
        _WorkingQuestions = new List<string>();
        Random random = new Random();
        for (int i = 0; i < numQuestions; i++)
        {
            int index = random.Next(_questions.Length);
            _WorkingQuestions.Add(_questions[index]);
            _questions[index] = _questions[_questions.Length - 1]; // Swap with last element
            Array.Resize(ref _questions, _questions.Length - 1); // Remove last element
        }
    }

    public void GetAnswers()
    {
        _answer = new List<string>();
        foreach (string question in _WorkingQuestions)
        {
            Console.WriteLine(question);
            string answer = Console.ReadLine();
            _answer.Add(answer);
        }
    }

    public void ownEntry()
    {
        Console.Write("What would you like to title your entry? ");
        string title = Console.ReadLine();
        _WorkingQuestions = new List<string>();
        _WorkingQuestions.Add(title);
        Console.WriteLine("Please enter your entry: ");
        string entry = Console.ReadLine();
        _answer.Add(entry);
    }
    
    public string createEntry()
    {
        string entry = _date + "#" + _WorkingQuestions[0] + "#" + _answer[0] + "#";
        for (int i = 1; i < _WorkingQuestions.Count; i++)
        {
            entry += _WorkingQuestions[i] + "#" + _answer[i] + "#";
        }
        return entry;
    }
}