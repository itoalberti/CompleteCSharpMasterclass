namespace Quiz_App;

internal class Question // internal → only Quiz consumes Question
{
    private static int _nextID = 1;
    public int QuestionID { get; }
    public string QuestionText { get; set; }
    public string[] Answers { get; set; }
    public int CorrectAnswerIndex { get; set; }

    public Question(string questionText, string[] answers, int correctAnswerIndex)
    {
        QuestionID = _nextID++;
        QuestionText = questionText;
        Answers = answers;
        CorrectAnswerIndex = correctAnswerIndex;
    }

    public bool IsCorrect(int choice)
    {
        return choice - 1 == CorrectAnswerIndex;
    }
}
