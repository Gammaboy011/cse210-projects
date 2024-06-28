using System;
public class SimpleGoal : Goal  {    // SimpleGoal class inherits from the abstract Goal class
    private bool _isComplete;   // Flag to indicate if the goal is complete
    private string _checkMark;  // String to represent the checkmark in the goal display

    public SimpleGoal(int id, string title, string descript, int points)    // Constructor to initialize the SimpleGoal with the specified parameters
        : base(id, title, descript, points) {
        _isComplete = false;// Initialize as incomplete
        _checkMark = " ";   // Initialize checkmark as empty
    }

    public override int MarkComplete() {    // Override the abstract MarkComplete method from the Goal class
        if (!_isComplete) { // If the goal is not already complete
            _isComplete = true; // Mark the goal as complete
            _checkMark = "X";   // Set the checkmark to 'X' indicating completion
            return _points;     // Return the points for completing the goal
        }
        return 0; // If already complete, return 0 points
    }
    
    public override string ToString() { // Override the ToString method to provide a string representation of the goal
        return $"(ID:{_id}) [{_checkMark}] {_title} ({_descript})"; 
        // If _isComplete = false: Display [ ]
        // If _isComplete = true: Display [X]
    }
}
