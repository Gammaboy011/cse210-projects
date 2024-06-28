using System;
public class SimpleGoal : Goal {
    private bool _isComplete;
    public SimpleGoal(int id, string title, string descript, int points)
        : base(id, title, descript, points) {
        _isComplete = false;
    }

    public override int MarkComplete() {
        if (!_isComplete) {
            _isComplete = true;
            return _points;
        }
        return 0;
    }
    
    public override string ToString() {
        return $"(ID:{_id}) [{_isComplete}] {_title} ({_descript})"; 
        // If _isComplete = false: Display [ ]
        // If _isComplete = true: Display [X]
    }
}