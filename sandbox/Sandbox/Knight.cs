public class Knight : Piece {
    private static int _numPieces = 2; // Static attribute to keep track of the number of knights
    public int GetNumPieces() {return _numPieces;}
    public void SetNumPieces(int numPieces) { _numPieces = numPieces;}

    public Knight(string color, string position) : base(color, position, 4) { // Constructor for the Knight class
        
    }

    // Override method to validate knight-specific movement
    public override bool IsValidMove(string newPosition) { // Implement Bishop-specific movement logic
        int currentRow = _position[1] - '1'; // Convert row from char to int (0-7)
        int currentCol = _position[0] - 'a'; // Convert column from char to int (0-7)
        int newRow = newPosition[1] - '1';
        int newCol = newPosition[0] - 'a';
        
        int rowDiff = Math.Abs(currentRow - newRow);
        int colDiff = Math.Abs(currentCol - newCol);

        // Knight moves in an "L" shape: 2 squares in one direction and 1 square perpendicular
        return (rowDiff == 2 && colDiff == 1) || (rowDiff == 1 && colDiff == 2);
    }

    
    public override void Move(string newPosition) { // Override method to move the knight
        if (IsValidMove(newPosition)) {
            _position = newPosition;
        } else {
            Console.WriteLine("Invalid move for a Knight.");
        }
    }
}
