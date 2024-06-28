using System;
public class EternalGoal : Goal {
    private int _completionCount;
    public EternalGoal(int id, string title, string descript, int points)
        : base(id, title, descript, points) {
            _completionCount = 0;
        }

    public override int MarkComplete() {
        _completionCount++;
        return _points;
    } 
    
    public override string ToString() {
        return $"(ID:{_id}) [{_completionCount}] {_title} ({_descript})"; // Since Eternal goal never is fully completed.
        // "_completionCount" in the string displays the number of times this goal has been completed.
    }
}