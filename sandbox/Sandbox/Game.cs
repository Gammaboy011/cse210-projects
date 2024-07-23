
public class Game {
    // Attributes for the two players and the game board 
    public Player _player1 { get; set; }
    public Player _player2 { get; set; }
    public Board _board { get; set; }
    // Attributes to track the turn, timer, game status, and score
    private bool _isWhiteTurn;
    public int _timer { get; set; } // 5 minutes in seconds
    private bool _isGameOver;
    private int _score { get; set; }

    public Game(Player player1, Player player2) { // Constructor
        _player1 = player1;
        _player2 = player2;
        _board = new Board();
        _isWhiteTurn = true; // White starts
        _timer = 300; // 5 minutes
        _isGameOver = false;
    }

    public void StartGame() { // Start the game loop
        // Game loop logic
        while (_timer > 0 && !_isGameOver) {
            Console.Clear();
            _board.DisplayBoard(); // Display the current state of the board
            // Simulate player moves (in reality, you would handle player input here)
            Console.WriteLine($"{(_isWhiteTurn ? _player1.GetName() : _player2.GetName())}'s turn.");
             string input; // Handle player move input
            do {
                Console.WriteLine("Enter your move (e.g., Pawn to C3):");
                input = Console.ReadLine();
            } while (!TryMakeMove(input)); // Continue prompting until a valid move is made
            _isWhiteTurn = !_isWhiteTurn; // Switch turns and check for checkmate
            _isGameOver = _board.CheckCheckmate();
            _timer--; // Decrement the timer
        } // End the game and calculate the score
        EndGame();
        CalculateScore();
    }

    public void EndGame() { // End the game and determine the winner
        Console.WriteLine("Game Over!");
        // Logic to determine the winner
        Player winningPlayer = _isWhiteTurn? _player2 : _player1;
        int winnerScore = Player.GetScore(); // An object reference is required for the non-static field, method, or property 'Player.UpdateScore(int)'
        Console.WriteLine($"{winningPlayer.GetName()} wins! Score:{winnerScore}");
    }

    // public void MakeMove(Player player) {// Switch the turn between players
    //     // Logic to handle player moves
    //     // For now, we'll simulate a move
    //     Piece piece = _board._grid[0, 4]; // Example piece
    //     string newPosition = "e2"; // Example new position
    //     _board.UpdateBoard(piece, newPosition);
    // }

    public bool TryMakeMove(string input) { // Method to attempt a move based on player input
        string[] parts = input.Split(' ');
        if (parts.Length != 3 || parts[1].ToLower() != "to") {
            Console.WriteLine("Invalid input format. Please use 'ChessPiece to C3'.");
            return false;
        }

        string pieceName = parts[0];
        string newPosition = parts[2].ToLower();
        // Validate the new position
        if (newPosition.Length != 2 || newPosition[0] < 'a' || newPosition[0] > 'h' || newPosition[1] < '1' || newPosition[1] > '8') {
            Console.WriteLine("Invalid position. Please use a valid position like 'C3'.");
            return false;
        } // Find the piece to move
        Piece pieceToMove = null;
        for (int row = 0; row < 8; row++)     {
            for (int col = 0; col < 8; col++) {
                Piece piece = _board._grid[row, col];
                if (piece != null && piece.GetType().Name.ToLower() == pieceName.ToLower() && piece.GetColor() == (_isWhiteTurn ? "White" : "Black")) {
                    pieceToMove = piece;
                    break;
                }
            }
            if (pieceToMove != null) break;
        } // Validate the move
        if (pieceToMove == null) {
            Console.WriteLine($"No {(_isWhiteTurn ? "White" : "Black")} {pieceName} found on the board.");
            return false;
        }
        if (!pieceToMove.IsValidMove(newPosition)) {
            Console.WriteLine($"{pieceName} cannot move to {newPosition}.");
            return false;
        } // Update the board with the new move
        _board.UpdateBoard(pieceToMove, newPosition);
        return true;
    }
    public void CalculateScore() { // Method to calculate the score based on captured pieces
        // Calculate the score based on captured pieces
    }
}
