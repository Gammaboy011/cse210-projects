public class Battle {
    private Profile _player1;
    private Profile _player2;

    public Battle(Profile player1, Profile player2) {
        _player1 = player1;
        _player2 = player2;
    }

    public void StartBattle() {
        Console.WriteLine("battle logic Here.");
        // Implement battle logic
        while (_player1.HasUsableCreatures() && _player2.HasUsableCreatures()) {
            ExecuteTurn(_player1, _player2);
            if (!_player2.HasUsableCreatures()) break;
            ExecuteTurn(_player2, _player1);
        }

        Profile winner = DetermineWinner();
        if (winner != null) {
            UpdateWinnerProfile(winner);
        }

        // After the battle logic, determine the winner
         CheckWinner();
    }

    public void ExecuteTurn(Profile attacker, Profile defender) {
        // // Implement turn logic
        // Console.WriteLine("turn logic Here.");
        // Console.WriteLine($"{_player1} turn now!"); // cycle through each player's turns.
        // // Player one goes first.
        // Console.WriteLine($"{_player2} turn now!"); 
        // // Player two goes next.

        Console.WriteLine($"{attacker.GetUserName()} is attacking {defender.GetUserName()}!");

        Creature attackingCreature = attacker.GetUsableCreature();
        Creature defendingCreature = defender.GetUsableCreature();
        
        if (attackingCreature != null && defendingCreature != null) {
            Move move = attackingCreature.Moves.FirstOrDefault();
            if (move != null && attackingCreature.Stamina >= move.StaminaCost) {
                defendingCreature.SetHealth(defendingCreature.GetHealth() - move.GetPower());
                attackingCreature.SetStamina(attackingCreature.GetHealth()- move.GetStaminaCost());
                if (defendingCreature.Health <= 0) {
                    defender.RemoveCreature(defendingCreature);
                    Console.WriteLine($"{defendingCreature.Name} has been defeated!");
                }
            }
        } else if (attackingCreature != null) {
            Console.WriteLine($"{attacker.GetUserName()} has no valid moves!");
        } else {
            Console.WriteLine($"{attacker.GetUserName()} has no usable creatures!");
        }
    }

    public void CheckWinner() {
        // Implement winner determination logic
        Console.WriteLine("Winner determination logic here.");

        // Placeholder for actual winner determination logic
        Profile winner = DetermineWinner();
        
        if (winner != null) {
            UpdateWinnerProfile(winner);
        }
    }

    private Profile DetermineWinner() {
        // This is a placeholder for the actual logic to determine the winner.
        // Let's assume Player1 is the winner for now.
        return _player1;
    }

    private void UpdateWinnerProfile(Profile winner) {   
        // Increment the winner's level
        winner.IncreaseLevel(); // Increases the players profile level by +1 according to IncreaseLevel() in Profile Class
        string filePath = $"CSE210/All_Players/{winner.GetUserName()}.json";
        winner.SaveProfile(filePath); 
        Console.WriteLine($"Winner's profile updated. New level: {winner.SetLevel}");
    }
}