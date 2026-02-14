using System;

public class ChecklistGoal : Goal
{
    private int _current;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int target, int bonus)
        : base(name, description, points)
    {
        _target = target;
        _bonus = bonus;
        _current = 0;
    }

    public override int RecordEvent()
    {
        _current++;
        if (_current >= _target)
        {
            return GetPoints() + _bonus;
        }
        return GetPoints();
    }

    public override bool IsComplete() => _current >= _target;

    public override string GetStatus() => $"[{(IsComplete() ? "X" : " ")}] Completed {_current}/{_target}";

    public override string GetStringRepresentation() =>
        $"ChecklistGoal|{GetName()}|{GetDescription()}|{_current}|{_target}|{GetPoints()}|{_bonus}";
}
