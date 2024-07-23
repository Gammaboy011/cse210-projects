public class Bishop : Piece {
    private static int _numPieces = 2; // Static attribute to keep track of the number of bishops
    public int GetNumPieces() {return _numPieces;}
    public void SetNumPieces(int numPieces) { _numPieces = numPieces;}
    
    public Bishop(string color, string position) : base(color, position, 3) { // Constructor for the Bishop class
    
    }

    public override bool IsValidMove(string newPosition) { // Implement Bishop-specific movement logic
        int currentRow = _position[1] - '1'; // Convert row from char to int (0-7)
        int currentCol = _position[0] - 'a'; // Convert column from char to int (0-7)
        int newRow = newPosition[1] - '1';
        int newCol = newPosition[0] - 'a';

        // Check if the move is in the same diagonal color
        bool isSameDiagonal = Math.Abs(currentRow - newRow) == Math.Abs(currentCol - newCol);
        return isSameDiagonal;
    }
    
    public override void Move(string newPosition) { // Override method to move the Bishop
        if (IsValidMove(newPosition)) {
            _position = newPosition;
        } else {
            Console.WriteLine("Invalid move for a Bishop.");
        }
    }

}