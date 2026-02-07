using System;
using System.Linq;

class ReflectionActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different?",
        "What did you learn about yourself?",
        "How can you use this experience in the future?"
    };

    private Queue<string> _shuffledQuestions;

    public ReflectionActivity()
        : base(
            "Reflection Activity",
            "This activity will help you reflect on times in your life when you have shown strength and resilience."
        )
    {
        ShuffleQuestions();
    }

    protected override void PerformActivity()
    {
        Random rand = new Random();
        Console.WriteLine("\n" + _prompts[rand.Next(_prompts.Count)]);
        ShowSpinner(5);

        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            if (_shuffledQuestions.Count == 0)
            {
                ShuffleQuestions();
            }

            string question = _shuffledQuestions.Dequeue();
            Console.WriteLine("\n" + question);
            ShowSpinner(4);
        }
    }

    private void ShuffleQuestions()
    {
        Random rand = new Random();
        _shuffledQuestions = new Queue<string>(
            _questions.OrderBy(q => rand.Next())
        );
    }
}
