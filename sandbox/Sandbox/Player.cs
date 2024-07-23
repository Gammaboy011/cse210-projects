public class Player
{
    private string _name; 
    public string GetName() {return _name;}
    public void SetName(string name) { _name = name;}
    private string _color;
    public string GetColor() {return _color;}
    public void SetColor(string color) { _color = color;}
    private int _score;
    public int GetScore() {return _score;}
    public void SetScore(int score) { _score = score;}
    private int _timeRemaining;
    public int GetTimeRemaining() {return _timeRemaining;}
    public void SetTimeRemaining(int timeRemaining) { _timeRemaining = timeRemaining;}

// List to store captured pieces.
    private List<Piece> _capturedPieces = new List<Piece>();

    public Player(string name, string color) { // Constructor to initialize a player with a name and color.
        _name = name;
        _color = color;
        _score = 0; // Sets initial score to 0
        _timeRemaining = 300; // 5 minutes
    }

    public void MakeMove(Piece piece, string newPosition) { // Make a move
        // Call the Move method on the piece.
        piece.Move(newPosition);
    }

    public void UpdateScore(int points) { // Method to update player's score.
        _score += points;
    }


    public void AddCapturedPiece(Piece piece) { // Method to add a captured piece to list.
        _capturedPieces.Add(piece);
    }

    
    public List<Piece> GetCapturedPieces() { // Method to get the list of captured pieces.
        return _capturedPieces;
    }
}
