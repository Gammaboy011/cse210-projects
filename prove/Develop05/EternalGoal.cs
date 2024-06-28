using System;

public class EternalGoal : Goal { // Derived class representing an eternal goal
    private int _completionCount; // Field to track the number of times the goal has been completed

    public EternalGoal(int id, string title, string descript, int points)
        : base(id, title, descript, points) { // Constructor to initialize an eternal goal with specific details
        _completionCount = 0; // Initial completion count is set to 0
    }

    public override int MarkComplete() { // Method to mark the goal as complete and return the points earned
        _completionCount++; // Increment the completion count each time the goal is completed
        return _points;     // Return the points associated with this goal
    }

    public override string ToString() {// Override the ToString method to provide a string representation of the eternal goal
        return $"(ID:{_id}) [{_completionCount}] {_title} ({_descript})"; 
        // The "_completionCount" in the string displays the number of times this goal has been completed.
    }
}