public class King : Piece {
    private static int _numPieces = 1; // Static attribute to keep track of the number of kings
    public int GetNumPieces() {return _numPieces;}
    public void SetNumPieces(int numPieces) { _numPieces = numPieces;}

    // Additional attributes for the King
    public bool _inCheck { get; set; }
    public bool _isCheckmate { get; set; }

    public King(string color, string position) : base(color, position, 0) { // Constructor for the King class
        _inCheck = false;
        _isCheckmate = false;
    }

    public override bool IsValidMove(string newPosition) { 
        // Implement King-specific movement logic
        int currentRow = _position[1] - '1'; // Convert row from char to int (0-7)
        int currentCol = _position[0] - 'a'; // Convert column from char to int (0-7)
        int newRow = newPosition[1] - '1';
        int newCol = newPosition[0] - 'a';
        // King can move one square in any direction
        bool isValid = Math.Abs(newRow - currentRow) <= 1 && Math.Abs(newCol - currentCol) <= 1;

        // Additional logic to ensure the move doesn't put the king in check
        // For now, we'll just return the basic valid move check
        return isValid;
    }
        
    public override void Move(string newPosition) { // Override method to move the king
        if (IsValidMove(newPosition)) {
            _position = newPosition;
            // After moving, check if the king is in check
            _inCheck = CheckIfInCheck();
        } else {
            Console.WriteLine("Invalid move for a King.");
        }
    }

    
    public bool CheckIfInCheck() { // Method to check if the king is in check
        // Logic to determine if the king is in check
        // For simplicity, we'll return false here
        return false;
    }

    // Method to check if the king is in checkmate
    public bool CheckIfCheckmate()
    {
        // Logic to determine if the king is in checkmate
        // For simplicity, we'll return false here
        return false;
    }
}
