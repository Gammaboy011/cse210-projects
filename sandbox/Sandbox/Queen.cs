namespace Sandbox;
public class Queen : Piece {
    private static int _numPieces = 1; // Static attribute to keep track of the number of queens
    public int GetNumPieces() {return _numPieces;}
    public void SetNumPieces(int numPieces) { _numPieces = numPieces;}

    public Queen(string color, string position) : base(color, position, 5) { } // Constructor for the Queen class

    // Override method to validate queen-specific movement
    public override bool IsValidMove(string newPosition) { // Implement Queen-specific movement logic
        int currentRow = _position[1] - '1'; // Convert row from char to int (0-7)
        int currentCol = _position[0] - 'a'; // Convert column from char to int (0-7)
        int newRow = newPosition[1] - '1';
        int newCol = newPosition[0] - 'a';
        // Check if the move is in the same row, column, or diagonal
        bool isSameRow = currentRow == newRow;
        bool isSameCol = currentCol == newCol;
        bool isSameDiagonal = Math.Abs(currentRow - newRow) == Math.Abs(currentCol - newCol);

        return isSameRow || isSameCol || isSameDiagonal;
    }

    // Override method to move the queen
    public override void Move(string newPosition)
    {
        if (IsValidMove(newPosition))
        {
            _position = newPosition;
        }
        else
        {
            Console.WriteLine("Invalid move for a Queen.");
        }
    }
}
