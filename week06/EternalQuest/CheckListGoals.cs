using System;

public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _targetCount;
    private int _bonus;

    public ChecklistGoal(string shortName, string description, int points, int targetCount, int bonus)
        : base(shortName, description, points)
    {
        _targetCount = targetCount;
        _bonus = bonus;
        _amountCompleted = 0;
    }

    public override int RecordEvent()
    {
        if (_amountCompleted < _targetCount)
        {
            _amountCompleted++;

            if (_amountCompleted == _targetCount)
            {
                return GetPoints() + _bonus;  // Final time, give points + bonus
            }
            else
            {
                return GetPoints();  // Just regular points
            }
        }

        return 0;  // Already fully complete
    }

    public override bool IsComplete()
    {
        return _amountCompleted >= _targetCount;
    }

    public override string GetDetailsString()
    {
        return $"[{(IsComplete() ? "X" : " ")}] {GetName()} ({GetDescription()}) -- Currently completed: {_amountCompleted}/{_targetCount}";
    }

    public override string GetStringRepresentation()
    {
        // Format: ChecklistGoal|Name|Description|Points|Bonus|TargetCount|AmountCompleted
        return $"ChecklistGoal|{GetName()}|{GetDescription()}|{GetPoints()}|{_bonus}|{_targetCount}|{_amountCompleted}";
    }
}