public class Player
{
    private string _name { get; set; }
    public string GetName() {return _name;}
    public void SetName(string name) { _name = name;}
    private string _color { get; set; }
    public string GetColor() {return _color;}
    public void SetColor(string color) { _color = color;}
    private int _score { get; set; }
    public int GetScore() {return _score;}
    public void SetScore(int score) { _score = score;}
    private int _timeRemaining { get; set; }
    public int GetTimeRemaining() {return _timeRemaining;}
    public void SetTimeRemaining(int timeRemaining) { _timeRemaining = timeRemaining;}

    public Player(string name, string color)
    {
        _name = name;
        _color = color;
        _score = 0;
        _timeRemaining = 300; // 5 minutes
    }

    public void MakeMove(Piece piece, string newPosition)
    {
        // Make a move
        piece.Move(newPosition);
    }

    public void UpdateScore(int points)
    {
        _score += points;
    }
}
