public class Rook : Piece  {
    private static int _numPieces = 2; // Static attribute to keep track of the number of rooks
    public int GetNumPieces() {return _numPieces;}
    public void SetNumPieces(int numPieces) { _numPieces = numPieces;}
    
    public Rook(string color, string position) : base(color, position, 2) {  // Constructor for the Rook class

    }

    public override bool IsValidMove(string newPosition) { // Implement Rook-specific movement logic
        int currentRow = _position[1] - '1'; // Convert row from char to int (0-7)
        int currentCol = _position[0] - 'a'; // Convert column from char to int (0-7)
        int newRow = newPosition[1] - '1';
        int newCol = newPosition[0] - 'a';

        // Rook can move any number of squares along a row or column, but not diagonally
        bool isSameRow = currentRow == newRow;
        bool isSameCol = currentCol == newCol;
        return isSameRow || isSameCol;
    }

    public override void Move(string newPosition) { // Override method to move the Rook
        if (IsValidMove(newPosition)) {
            _position = newPosition;
        } else {
            Console.WriteLine("Invalid move for a Rook.");
        }
    }
}