using System;
public class SimpleGoal : Goal {
    private bool _isComplete;
    private string _checkMark;
    public SimpleGoal(int id, string title, string descript, int points)
        : base(id, title, descript, points) {
        _isComplete = false;
        _checkMark = " ";
    }

    public override int MarkComplete() {
        if (!_isComplete) {
            _isComplete = true;
            _checkMark = "X";
            return _points;
        }
        return 0;
    }
    
    public override string ToString() {
        return $"(ID:{_id}) [{_checkMark}] {_title} ({_descript})"; 
        // If _isComplete = false: Display [ ]
        // If _isComplete = true: Display [X]
    }
}