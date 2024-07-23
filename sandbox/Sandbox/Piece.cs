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

    public virtual void Move(string newPosition)
    {
        if (IsValidMove(newPosition))
        {
            _position = newPosition;
        }
    }

    public void Capture()
    {
        // Logic for capturing the piece
    }
}
