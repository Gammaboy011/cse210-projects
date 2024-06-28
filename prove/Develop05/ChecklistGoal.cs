using System;
public class ChecklistGoal : Goal {
    private int _targetCount;
    private int _currentCount;
    private int _bonusPoints;
    private bool _isComplete;

    public ChecklistGoal(int id, string title, string descript, int points, int targetCount, int bonusPoints)
        : base(id, title, descript, points) {
        _targetCount = targetCount;
        _currentCount = 0;
        _bonusPoints = bonusPoints;
        _isComplete = false; // If _isComplete = false: Display [ ]
    }

    public override int MarkComplete() {
        _currentCount++;
        if (_currentCount >= _targetCount && !_isComplete) { // If _isComplete = true: Display [X] *This should only display true ONCE the current count is equal to target count.
            _isComplete = true; // If _currentCount == _targetCount; reward user _bonusPoints.
            Console.WriteLine($"Checklist goal completed! Bonus points: {_bonusPoints}");
            return _points + _bonusPoints;
        } else if (!_isComplete) { // If _currentCount =< 1 < _targetCount; reward the user _points.
            return _points;
        }
        return 0;
    }
    
    public override string ToString() {
        return $"(ID:{_id}) [{_isComplete}] {_title} ({_descript}) ({_currentCount}/{_targetCount})";
    }
    
}