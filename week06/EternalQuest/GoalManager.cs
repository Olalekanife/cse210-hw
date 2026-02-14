using System;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;
    private int _level = 1;
    private List<string> _badges = new List<string>();

    public void AddGoal(Goal goal) => _goals.Add(goal);

    public void DisplayGoals()
    {
        Console.WriteLine("Your Goals:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetStatus()} {_goals[i].GetName()} - {_goals[i].GetDescription()}");
        }
    }

    public void DisplayScore()
    {
        Console.WriteLine($"Current Score: {_score}");
        Console.WriteLine($"Level: {_level}");
        if (_badges.Count > 0)
        {
            Console.WriteLine("Badges Unlocked:");
            foreach (var badge in _badges)
            {
                Console.WriteLine($"- {badge}");
            }
        }
    }

    public void RecordEvent(int index)
    {
        if (index < 0 || index >= _goals.Count) return;

        int points = _goals[index].RecordEvent();
        _score += points;

        if (points >= 0)
            Console.WriteLine($"You earned {points} points");
        else
            Console.WriteLine($"You lost {-points} points");

        CheckLevelUp();
        CheckBadges(_goals[index]);
    }

    private void CheckLevelUp()
    {
        int newLevel = (_score / 1000) + 1;
        if (newLevel > _level)
        {
            _level = newLevel;
            Console.WriteLine("🎉 LEVEL UP! You reached Level " + _level);
        }
    }

    private void CheckBadges(Goal goal)
    {
        if (!_badges.Contains("First Step Badge") && goal.IsComplete())
        {
            _badges.Add("First Step Badge");
            Console.WriteLine("🏅 Unlocked Badge: First Step Badge");
        }
        if (_score >= 500 && !_badges.Contains("500 Points Badge"))
        {
            _badges.Add("500 Points Badge");
            Console.WriteLine("🏅 Unlocked Badge: 500 Points Badge");
        }
        if (_score >= 1000 && !_badges.Contains("1000 Points Badge"))
        {
            _badges.Add("1000 Points Badge");
            Console.WriteLine("🏅 Unlocked Badge: 1000 Points Badge");
        }
        if (_score >= 5000 && !_badges.Contains("5000 Points Badge"))
        {
            _badges.Add("5000 Points Badge");
            Console.WriteLine("🏅 Unlocked Badge: 5000 Points Badge");
        }
    }

    public void SaveGoals(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(_score);
            writer.WriteLine(_level);
            writer.WriteLine(string.Join(",", _badges));
            foreach (var goal in _goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }
        Console.WriteLine("Goals saved successfully");
    }

    public void LoadGoals(string filename)
    {
        if (!File.Exists(filename)) return;

        _goals.Clear();
        string[] lines = File.ReadAllLines(filename);
        _score = int.Parse(lines[0]);
        _level = int.Parse(lines[1]);
        _badges = new List<string>(lines[2].Split(',', StringSplitOptions.RemoveEmptyEntries));

        for (int i = 3; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split('|');
            string type = parts[0];
            switch (type)
            {
                case "SimpleGoal":
                    _goals.Add(new SimpleGoal(parts[1], parts[2], int.Parse(parts[4])));
                    break;
                case "EternalGoal":
                    _goals.Add(new EternalGoal(parts[1], parts[2], int.Parse(parts[3])));
                    break;
                case "ChecklistGoal":
                    _goals.Add(new ChecklistGoal(parts[1], parts[2], int.Parse(parts[5]), int.Parse(parts[4]), int.Parse(parts[6])));
                    break;
                case "NegativeGoal":
                    _goals.Add(new NegativeGoal(parts[1], parts[2], int.Parse(parts[4])));
                    break;
            }
        }
        Console.WriteLine("Goals loaded successfully!");
    }

    public int GetGoalCount() => _goals.Count;
}
