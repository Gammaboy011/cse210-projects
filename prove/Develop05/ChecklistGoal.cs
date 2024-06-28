using System;

public class ChecklistGoal : Goal {
    private int _targetCount;   // The target number of times the goal must be completed
    private int _currentCount;  // The current number of times the goal has been completed
    private int _bonusPoints;   // The bonus points awarded when the goal is fully completed
    private bool _isComplete;   // Whether the goal has been fully completed
    private string _checkMark;  // Mark to indicate completion status

    public ChecklistGoal(int id, string title, string descript, int points, int targetCount, int bonusPoints)
        : base(id, title, descript, points) {   // Constructor to initialize the checklist goal
        _targetCount = targetCount; // Set the target count
        _currentCount = 0;          // Initialize the current count to 0
        _bonusPoints = bonusPoints; // Set the bonus points
        _isComplete = false;        // Set the initial completion status to false
        _checkMark = " ";           // Set the initial check mark to an empty space
    }
    public override int MarkComplete() {    // Method to mark the goal as complete and return the points earned
        _currentCount++;    // Increment the current count
        // Check if the current count has reached the target count and the goal is not already marked as complete
        if (_currentCount >= _targetCount && !_isComplete) {
            _isComplete = true; // Mark the goal as complete
            _checkMark = "X";   // Set the check mark to "X"
            Console.WriteLine($"{_title} goal completed! Bonus points: {_bonusPoints}");
            return _points + _bonusPoints;  // Return the total points including bonus points
        } else if (!_isComplete) {
            return _points;  // Return the points if the goal is not yet fully complete
        }
        return 0;  // Return 0 if the goal is already complete
    }

    public override string ToString() { // Method to return a string representation of the goal
        return $"(ID:{_id}) [{_checkMark}] {_title} ({_descript}) ({_currentCount}/{_targetCount})";
    }
}