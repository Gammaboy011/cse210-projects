public class Pawn : Piece {
    private Board _board; // Reference to the Board instance

    private string _swapPiece;
    public string GetSwapPiece() {return _swapPiece;}
    public void SetSwapPiece(string swapPiece) { _swapPiece = swapPiece;}
    private static int _numPieces = 8; // Static attribute to keep track of the number of pawns
    public int GetNumPieces() {return _numPieces;}
    public void setNumPieces(int numPieces) { _numPieces = numPieces;}

    public Pawn(string color, string position, Board board) : base(color, position, 1) {
        _board = board;
     }

    public override bool IsValidMove(string newPosition) {
        // Implement pawn-specific movement logic
        int currentRow = _position[1] - '1'; // Convert row from char to int (0-7)
        int currentCol = _position[0] - 'a'; // Convert column from char to int (0-7)
        int newRow = newPosition[1] - '1';
        int newCol = newPosition[0] - 'a';

        if (_color == "White") { // White moves foward
            if (newRow == currentRow + 1 && newCol == currentCol) { // Regular move once
                return true;
            }
            if (currentRow == 1 && newRow == currentRow + 2 && newCol == currentCol) { // Initial double step move
                return true;
            }
            if (newRow == currentRow + 1 && (newCol == currentCol + 1 || newCol == currentCol - 1)) { // Capturing move diagnal
                return true;
            }
            if (currentRow == 4 && newRow == 5 && (newCol == currentCol + 1 || newCol == currentCol - 1)) { // En passant
                return true; // Additional logic required to verify en passant conditions
            }
        } else { // Black moves backward
            if (newRow == currentRow - 1 && newCol == currentCol) { // Regular move once
                return true;
            }
            if (currentRow == 6 && newRow == currentRow - 2 && newCol == currentCol) {// Initial double step move
                return true;
            }
            if (newRow == currentRow - 1 && (newCol == currentCol + 1 || newCol == currentCol - 1)) { // Capturing move diagnal
                return true;
            }
            if (currentRow == 3 && newRow == 2 && (newCol == currentCol + 1 || newCol == currentCol - 1)) { // En passant
                return true; // Additional logic required to verify en passant conditions
            }
        }
        return false;
    }
    
    public override void Move(string newPosition) { // Override method to move the pawn
        if (IsValidMove(newPosition)) {
            _position = newPosition;
        } else {
            Console.WriteLine("Invalid move for a Pawn.");
        }
    }

    private void CheckPromotion() { // Method to handle pawn promotion
        int row = _position[1] - '1';
        if ((_color == "White" && row == 7) || (_color == "Black" && row == 0)) {
            Promote();
        }
    }

    private void Promote() { 
        Console.WriteLine("Pawn promotion! Choose a piece (Queen, Rook, Bishop, Knight):");
        string newPieceType = Console.ReadLine(); //
        // Assuming the board object is accessible here. Replace `board` with the actual board instance.
        _board.PromotePawn(this, newPieceType); // Calls the PromotePawn method on the board instance.
    } // The board is updated with the new piece.
}

// Implement other pieces (Rook, Knight, Bishop, Queen, King) similarly
