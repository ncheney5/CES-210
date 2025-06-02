class Math : Assignment
{
    private string _textbookSection;
    private string _QuestionNumbers;

    public Math(string studentName, string topic, string textbookSection, string questionNumbers)
        : base(studentName, topic)
    {
        _textbookSection = textbookSection;
        _QuestionNumbers = questionNumbers;
    }

    public string GetHomeworkList()
    {
        return $"{_textbookSection} {_QuestionNumbers}";
    }
    

}