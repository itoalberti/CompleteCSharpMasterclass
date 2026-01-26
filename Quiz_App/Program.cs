namespace Quiz_App;

class Program
{
    static void Main(string[] args)
    {
        Question[] question = new Question[]
        {
            new Question(
                "What is the capital of Estonia?", // QuestionText
                new string[] { "Paris", "Karnataka", "Tallinn", "Paramaribo" }, // Answers
                2 // CorrectAnswerIndex
            ),
            new Question(
                "Who let the dogs out?",
                new string[] { "Who?", "Who?", "Who?", "Jebediah!" },
                3
            ),
            new Question(
                "Why did the chicken cross the road?",
                new string[]
                {
                    "Because it wanted to buy cigarrettes on the other side of the road",
                    "You're wrong, it didn't",
                    "Because it could and it wanted",
                    "The voices told her to do so",
                },
                0
            ),
            new Question(
                "Why did man first land on the moon?",
                new string[] { "1969", "Man never went to the moon", "Today", "2021" },
                0
            ),
        };

        Quiz myQuiz = new Quiz(question);
        myQuiz.StartQuiz();
        Console.ReadLine();
    }
}
