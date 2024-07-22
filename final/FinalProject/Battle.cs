public class Battle {
    private Profile _player1;
    private Profile _player2;
    // Constructor to initialize a Battle with two player profiles.
    public Battle(Profile player1, Profile player2) {
        _player1 = player1;
        _player2 = player2;
    }

    public void StartBattle() {  // Method to start the battle.
        Console.WriteLine("Starting the battle...");
        // Implement battle logic
        while (_player1.HasUsableCreatures() && _player2.HasUsableCreatures()) { // both players start off with usable creatures.
            ExecuteTurn(_player1, _player2); // Player 1 attacks Player 2.
            if (!_player2.HasUsableCreatures()) break; // Check if Player 2 has usable creatures left.
            ExecuteTurn(_player2, _player1);  // Player 2 attacks Player 1.
            if (!_player1.HasUsableCreatures()) break; // Check if Player 1 has usable creatures left.
        }

        Profile winner = DetermineWinner(); // Determine the winner if the battle ends.
        if (winner != null) { // Update the winner's profile if there's a winner.
            UpdateWinnerProfile(winner);
        }
        // After the battle logic, determine the winner.
         CheckWinner();
    }

    public void ExecuteTurn(Profile attacker, Profile defender) {
        // Implement turn logic.
        Console.WriteLine($"{attacker.GetUserName()} is attacking {defender.GetUserName()}!");
        // Get the attacking and defending creatures.
        Creature attackingCreature = attacker.GetUsableCreature();
        Creature defendingCreature = defender.GetUsableCreature();
        
        if (attackingCreature != null && defendingCreature != null) {
            Move move = attackingCreature.Moves.FirstOrDefault(); // Get the first available move of the attacking creature.
            if (move != null && attackingCreature.Stamina >= move.StaminaCost) {
                defendingCreature.SetHealth(defendingCreature.GetHealth() - move.GetPower()); // Apply the move's effect on the defending creature.
                attackingCreature.SetStamina(attackingCreature.GetHealth()- move.GetStaminaCost()); // Deduct stamina from the attacking creature.
                if (defendingCreature.Health <= 0) { // Check if the defending creature is defeated.
                    defender.RemoveCreature(defendingCreature);
                    Console.WriteLine($"{defendingCreature.Name} has been defeated!");
                }
            }
        } else if (attackingCreature != null) { // If the attacker has no valid moves.
            Console.WriteLine($"{attacker.GetUserName()} has no valid moves!");
        } else { // If the attacker has no usable creatures.
            Console.WriteLine($"{attacker.GetUserName()} has no usable creatures!");
        }
    }

    public void CheckWinner() {  // Method to check and print the winner.
        // Implement winner determination logic.
        Console.WriteLine("Winner determination logic here.");

        // Determine the winner.
        Profile winner = DetermineWinner();
        
        if (winner != null) { // Update the winner's profile if there's a winner.
            UpdateWinnerProfile(winner);
        }
    }

    private Profile DetermineWinner() {
        // This is a placeholder for the actual logic to determine the winner.
        // Let's assume Player1 is the winner for now.
        return _player1;
    }

    private void UpdateWinnerProfile(Profile winner) {   // Method to update the winner's profile.
        // Increment the winner's level.
        winner.IncreaseLevel(); // Increases the players profile level by +1 according to IncreaseLevel() in Profile Class.
        string filePath = $"CSE210/All_Players/{winner.GetUserName()}.json";
        winner.SaveProfile(filePath);  // Save the updated profile to a file.
        Console.WriteLine($"Winner's profile updated. New level: {winner.SetLevel}");
    }
}