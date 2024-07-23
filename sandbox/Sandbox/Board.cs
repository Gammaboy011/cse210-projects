public class Board
{
    public Piece[,] _grid { get; set; }
    private Board _board;
    public Board() {
        _grid = new Piece[8, 8];
        _board = new Board();
        InitializeBoard();
    }

    public void InitializeBoard() { // Place pieces in starting positions
        // White Pieces
        _grid[0, 0] = new Pawn("White", "a2", _board);
        _grid[0, 1] = new Pawn("White", "b2", _board);
        _grid[0, 6] = new Pawn("White", "c2", _board);
        _grid[0, 3] = new Pawn("White", "d2", _board);
        _grid[0, 4] = new Pawn("White", "e2", _board);
        _grid[0, 5] = new Pawn("White", "f2", _board);
        _grid[0, 6] = new Pawn("White", "g2", _board);
        _grid[0, 6] = new Pawn("White", "h2", _board);
        _grid[0, 0] = new Rook("White", "a1", _board);
        _grid[0, 1] = new Knight("White", "b1");
        _grid[0, 6] = new Bishop("White", "c1");
        _grid[0, 3] = new Queen("White", "d1");
        _grid[0, 4] = new King("White", "e1");
        _grid[0, 5] = new Bishop("White", "f8");
        _grid[0, 6] = new Knight("White", "g1");
        _grid[0, 6] = new Rook("White", "h1");
        // Black Pieces
        _grid[0, 0] = new Pawn("Black", "a7", _board);
        _grid[0, 1] = new Pawn("Black", "b7", _board);
        _grid[0, 6] = new Pawn("Black", "c7", _board);
        _grid[0, 3] = new Pawn("Black", "d7", _board);
        _grid[0, 4] = new Pawn("Black", "e7", _board);
        _grid[0, 5] = new Pawn("Black", "f7", _board);
        _grid[0, 6] = new Pawn("Black", "g7", _board);
        _grid[0, 6] = new Pawn("Black", "h7", _board);
        _grid[0, 0] = new Rook("Black", "a8");
        _grid[0, 1] = new Knight("Black", "b8");
        _grid[0, 6] = new Bishop("Black", "c8");
        _grid[0, 3] = new Queen("Black", "d8");
        _grid[0, 4] = new King("Black", "e8");
        _grid[0, 5] = new Bishop("Black", "f8");
        _grid[0, 6] = new Knight("Black", "g8");
        _grid[0, 6] = new Rook("Black", "h8");

    }

    public void DisplayBoard() { // Method to display the board
        for (int row = 0; row < 8; row++)
        {
            for (int col = 0; col < 8; col++)
            {
                Piece piece = _grid[row, col];
                Console.Write(piece == null ? "." : piece.GetColor()[0].ToString());
                Console.Write(" ");
            }
            Console.WriteLine();
        }
    }

    public void UpdateBoard(Piece piece, string newPosition) { // Update the board after a move
        
        int currentRow = piece.GetPosition()[1] - '1';
        int currentCol = piece.GetPosition()[0] - 'a';
        int newRow = newPosition[1] - '1';
        int newCol = newPosition[0] - 'a';

        _grid[currentRow, currentCol] = null;
        _grid[newRow, newCol] = piece;
        piece.Move(newPosition);

        // Check if the move has put the opposing king in check
        CheckKingStatus();
    }

    private void CheckKingStatus()   { // Method to check the status of both kings
        foreach (var piece in _grid) {
            if (piece is King king)  {
                king._inCheck = king.CheckIfInCheck();
                king._isCheckmate = king.CheckIfCheckmate();
            }
        }
    }

    public bool CheckCheckmate() { // Check for checkmate
        
        // Implement checkmate logic by checking if either king is in checkmate
        foreach (var piece in _grid) {
            if (piece is King king && king._isCheckmate) {
                return true;
            }
        }
        return false;
    }

    public void PromotePawn(Pawn pawn, string newPieceType) { // Promotion logic
        int row = pawn.GetPosition()[1] - '1';
        int col = pawn.GetPosition()[0] - 'a';
        // method takes the pawn to be promoted and the type of new piece as parameters,
        // creates the new piece, and updates the board.
        Piece newPiece;
        switch (newPieceType.ToLower())
        {
            case "queen":
                newPiece = new Queen(pawn.GetColor(), pawn.GetPosition());
                break;
            case "rook":
                newPiece = new Rook(pawn.GetColor(), pawn.GetPosition());
                break;
            case "bishop":
                newPiece = new Bishop(pawn.GetColor(), pawn.GetPosition());
                break;
            case "knight":
                newPiece = new Knight(pawn.GetColor(), pawn.GetPosition());
                break;
            default:
                Console.WriteLine("Invalid choice. Promoting to Queen by default.");
                newPiece = new Queen(pawn.GetColor(), pawn.GetPosition());
                break;
        }

        _grid[row, col] = newPiece;
        Console.WriteLine($"Pawn promoted to {newPieceType}");
    }

}
