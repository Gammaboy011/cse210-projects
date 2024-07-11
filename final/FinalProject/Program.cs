/* Header
    Final, WK#
    --Isaac Madrid--
    Assignment name
    00/00/24
    */
using System;
using System.Collections.Generic;
using System.IO;
class Program   {
    private static Profile _currentProfile; // The current user profile.
    private static List<Creature> _creatureList = new List<Creature>(); // List of created creatures.
    private static List<Move> _moveList = new List<Move>(); // List of available moves.
    private static bool _isGameRunning; // Flag to indicate if the game is running.
    private static Battle _currentBattle; // The current battle.
    static void Main(string[] args) { // Main entry point of the program. 
        _isGameRunning = true; // Initialize game running flag.
        Console.WriteLine("Welcome to the Creature Battle Simulator!");
        while (_isGameRunning) {
            DisplayMenu(); // Display the main menu.
        }
        static void DisplayMenu() { // Method to display the main menu.
            Console.WriteLine("Main Menu");
            Console.WriteLine("1. Create Profile");
            Console.WriteLine("2. Load Profile");
            Console.WriteLine("3. Create Creature");
            Console.WriteLine("4. Battle");
            Console.WriteLine("5. Exit!");
            Console.Write("Choose an option: ");
            string input = Console.ReadLine(); // Read user choice.
            Console.Clear(); // Clear the console screen.
            int choice;
            if (int.TryParse(input, out choice)) { // Call the method to handle the chosen activity.
                // Process the choice.
                switch (choice) { // If the input is a valid integer (int.TryParse returns true).
                    case 1: // Create a new profile.
                        CreateProfile();
                        break;
                    case 2: // Load an existing profile.
                        LoadProfile();
                        break;
                    case 3: // Create a new creature.
                        CreateCreature();
                        break;
                    // case 4: // View all creatures saved to a global file.
                    //     ViewAllCreatures(); 
                    //     break;
                    case 5: // Start a battle.
                        StartBattle();
                        break;
                    case 6: // Exit the game.
                        Console.Clear();
                        _isGameRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please choose a valid option.");
                        break;
                }
            } else { // If the input is not a valid integer. (int.TryParse returns false)
            Console.WriteLine("Invalid input. Please enter a number.");
            }
        }
    }

    static void CreateProfile() { // Method to create a new profile.
        Console.Write("Enter username: ");
        var userName = Console.ReadLine();
        Console.Write("Enter level: "); // Needs to be revised so it updates after each code.
        var level = int.Parse(Console.ReadLine());
        // Create a new profile
        _currentProfile = new Profile(userName, level);
        var filePath = $"{userName}.json";
        _currentProfile.SaveProfile(filePath);
        Console.WriteLine($"Profile saved to {filePath}");
    }

    static void LoadProfile() { // Method to load an existing profile.
        Console.Write("Enter username to load: ");
        var userName = Console.ReadLine(); // Read the username.
        var filePath = $"{userName}.json";  // Set the file path for loading the profile.
        _currentProfile = Profile.LoadProfile(filePath); // Load the profile from the file.
        Console.WriteLine($"Profile loaded for {_currentProfile}");
    } // *A name needs to be assigned to profile created.

    static void CreateCreature() { // Method to create a new creature.
        Console.Write("Enter creature name: ");
        var name = Console.ReadLine();
        Console.Write("Enter description: ");
        var description = Console.ReadLine();
        Console.Write("Enter health: ");
        var health = float.Parse(Console.ReadLine());
        Console.Write("Enter stamina: ");
        var stamina = float.Parse(Console.ReadLine());
        Console.Write("Enter responsibility type: ");
        var responsibilityType = Console.ReadLine();

        var creature = new Creature(name, description, health, stamina, responsibilityType); // Create a new creature.
        var filePath = $"{creature.GetName()}.json"; // Set the file path for saving the creature. 
        // *A name needs to be assigned to creature.
        creature.SaveCreature(filePath); // Save the creature to a file.
        Console.WriteLine($"Creature saved to {filePath}");

        _creatureList.Add(creature); // Add the creature to the list.
    }

    static void StartBattle() {  // Method to start a battle.
        if (_currentProfile == null) {
            Console.WriteLine("Please create or load a profile first.");
            return;
        }

        // For simplicity, using the same profile as both players.
        _currentBattle = new Battle(_currentProfile, _currentProfile);
        _currentBattle.StartBattle();
    }
}