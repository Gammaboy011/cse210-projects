public class Game
{
    public Player _player1 { get; set; }
    public Player _player2 { get; set; }
    public Board _board { get; set; }
    public int _timer { get; set; } // 5 minutes in seconds
    private bool _isGameOver;

    public Game(Player player1, Player player2)
    {
        _player1 = player1;
        _player2 = player2;
        _board = new Board();
        _timer = 300; // 5 minutes
        _isGameOver = false;
    }

    public void StartGame() { // Start the game loop
        // Game loop logic
        while (_timer > 0 && !_isGameOver) {
            _board.DisplayBoard();
            // Simulate player moves (in reality, you would handle player input here)
            Player currentPlayer = _timer % 2 == 0 ? _player1 : _player2;
            /*
            // white player moves first
            MakeMove(Player player1)
            // Black player moves after.
            MakeMove(Player player2)
            */
            _isGameOver = _board.CheckCheckmate();
            _timer--;
        }
        EndGame();
        CalculateScore();
    }

    public void EndGame() { // End the game and determine the winner
        Console.WriteLine("Game Over!");
        // Logic to determine the winner
    }


    public void MakeMove(Player player) // Switch the turn between players
    {
        // Logic to handle player moves
        // For now, we'll simulate a move
        Piece piece = _board._grid[0, 4]; // Example piece
        string newPosition = "e2"; // Example new position
        _board.UpdateBoard(piece, newPosition);
    }

    public void CalculateScore()
    {
        // Calculate the score based on captured pieces
    }
}
