using System;
/* Header
    Sandbox, WK#
    --Isaac Madrid--
    Assignment name
    00/00/24
    */
namespace Sandbox;
class Program {
    public static Game _chessGame;
        static void Main(string[] args) {
            Console.WriteLine("Welcome to Chess Game!");

            // Create players
            Console.Write("Player 1 enter your name: ");
            var user1 = Console.ReadLine(); // Read the username.
            Player player1 = new Player($"{user1}", "White");
            Console.WriteLine($"{user1} is set ");

            Console.Write("Player 2 enter your name: ");
            var user2 = Console.ReadLine(); // Read the username.
            Player player2 = new Player($"{user1}", "Black");
            Console.WriteLine($"{user2} is set ");

            // Initialize the game
            _chessGame = new Game(player1, player2);

            // Start the game
            _chessGame.StartGame();

            Console.WriteLine("Game Over!");
        }
    }


/*
        while (true) {
            int delay = 150;
            Console.WriteLine(".");
            Thread.Sleep(delay);
            Console.Clear();
            Console.WriteLine("..");
            Thread.Sleep(delay);
            Console.Clear();
            Console.WriteLine("...");
            Thread.Sleep(delay);
            Console.Clear();
            Console.WriteLine(" ");
            Thread.Sleep(delay);
            Console.Clear();
            
        }*/
/*
        Blind kitchen = new Blind();
        kitchen._width = 60;
        kitchen._height = 48;
        kitchen._color = "white";
        double materialAmount = kitchen.GetArea();
        Blind livingRoom = new Blind();
        livingRoom._width = 72;
        livingRoom._height = 52;
        livingRoom._color = "white";
        materialAmount = livingRoom.GetArea();
        Console.Write($"{livingRoom._width} {livingRoom._height} {livingRoom._color}");
        string input = Console.ReadLine();
        House johnsonHome = new House();
        johnsonHome._owner = "Johnson Family";
        johnsonHome._kitchen._width = 60;
        johnsonHome._kitchen._height = 48;
        johnsonHome._kitchen._color = "white";
        materialAmount = kitchen.GetArea();
        johnsonHome._livingRoom._width = 72;
        johnsonHome._livingRoom._height = 52;
        johnsonHome._livingRoom._color = "white";
        materialAmount = livingRoom.GetArea();
        */
    