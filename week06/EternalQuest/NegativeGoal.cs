using System;

public class NegativeGoal : Goal
{
    private bool _isTriggered;

    public NegativeGoal(string name, string description, int points)
        : base(name, description, points)
    {
        _isTriggered = false;
    }

    public override int RecordEvent()
    {
        if (!_isTriggered)
        {
            _isTriggered = true;
            return -GetPoints();
        }
        return 0;
    }

    public override bool IsComplete() => false;

    public override string GetStatus() => "[!]";

    public override string GetStringRepresentation() =>
        $"NegativeGoal|{GetName()}|{GetDescription()}|{_isTriggered}|{GetPoints()}";
}
