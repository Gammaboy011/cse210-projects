public abstract class Piece
{
    protected string _color;
    public string GetColor() {return _color;}
    public void SetColor(string color) { _color = color;}
    protected string _position;
    public string GetPosition() {return _position;}
    public void SetPosition(string position) { _position = position;}
    protected int _pointVal;

    public Piece(string color, string position, int pointVal) {
        _color = color;
        _position = position;
        _pointVal = pointVal;
    }

    public abstract bool IsValidMove(string newPosition);

    public virtual void Move(string newPosition) {
        if (IsValidMove(newPosition)) {
            _position = newPosition;
        }
    }

    public void Capture(Player capturingPlayer) {
        // Logic for capturing the piece
        // Add the captured piece to the capturing player's list.
        capturingPlayer.AddCapturedPiece(this);
        _position = null;
    }
}
