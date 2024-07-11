using System;
using System.Runtime;
public class Battle
{
    private Profile Player1;
    private Profile Player2;

    public Battle(Profile player1, Profile player2) {
        Player1 = player1;
        Player2 = player2;
    }

    public void StartBattle() {
        // Implement battle logic
        Console.WriteLine("battle logic Here.");
    }

    public void ExecuteTurn() {
        // Implement turn logic
        Console.WriteLine("turn logic Here.");
    }

    public void CheckWinner() {
        // Implement winner determination logic
            Console.WriteLine("winner determination logic Here.");
    }
}