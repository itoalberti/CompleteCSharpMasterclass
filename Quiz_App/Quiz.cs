using System.Xml.Serialization;

namespace Quiz_App;

internal class Quiz // internal → only Program consumes Quiz
{
    private Question[] _questions;
    private int _score = 0;

    public Quiz(Question[] questions)
    {
        this._questions = questions;
    }

    public void StartQuiz()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("╔════════════════════════════════════════╗");
        Console.WriteLine("║          WELCOME TO OUR QUIZ!          ║");
        Console.WriteLine("╚════════════════════════════════════════╝");
        Console.ResetColor();
        foreach (Question question in _questions)
        {
            DisplayQuestion(question);
            int userChoice = GetUserChoice();
            if (question.IsCorrect(userChoice))
            {
                Console.WriteLine($"What a nerd! You're correct!");
                _score++;
            }
            else
                Console.WriteLine(
                    $"YOU'RE WROOOOOOOONG! The correct answer was \"{question.Answers[question.CorrectAnswerIndex]}\""
                );
            Thread.Sleep(500);
        }
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write(
            $"===============You got {_score} correct answers out of {_questions.Length}!==============="
        );
        Console.ResetColor();
    }

    private void DisplayQuestion(Question question)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        // formatting the question box so its items don't misalign even after question 10, 100 etc
        // ╔═══════════════╗
        // ║   QUESTION N  ║
        // ╚═══════════════╝

        int questionBoxWidth = 60;
        string title = $"QUESTION {question.QuestionID}";
        Console.WriteLine($"╔{new string('═', questionBoxWidth)}╗");
        Console.WriteLine(
            $"║{title.PadLeft((questionBoxWidth + title.Length) / 2).PadRight(questionBoxWidth)}║"
        );
        Console.WriteLine($"╚{new string('═', questionBoxWidth)}╝");

        Console.WriteLine(question.QuestionText);
        for (int i = 0; i < question.Answers.Length; i++)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write($"{i + 1}) ");
            Console.ResetColor();
            Console.WriteLine($"{question.Answers[i]}");
        }
        // if (GetUserChoice() == question.CorrectAnswerIndex)
        //     Console.WriteLine($"Correct!");
        // else
        //     Console.WriteLine($"Incorrect");
    }

    private int GetUserChoice()
    {
        Console.Write($"Your answer: ");
        int choice = 0;
        while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 4)
        {
            Console.WriteLine($"Invalid option. Please enter a number between 1 and 4.");
        }
        return choice;
    }
}
