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
            Console.WriteLine("4. Load Creature");
            Console.WriteLine("5. Battle");
            Console.WriteLine("6. Exit!");
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
                    case 4: // View all creatures saved to a global file.
                        // Console.WriteLine("Currently Under Construction!!!.");
                        Thread.Sleep(2000);
                        LoadCreature(); // Once .Json can store data in file, have the program 'list' 
                            // the Creaters and allow the user to choose a creature they want to learn more about.
                         break;
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

    static void CreateProfile() { // *Method to create a new profile.
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
        Console.WriteLine($"Profile loaded for {userName}");
    } // *A name needs to be assigned to profile created.

    static void CreateCreature() { // *Method to create a new creature.
        Console.Write("Enter creature name: ");
        var name = Console.ReadLine();
        Console.Write("Enter description: ");
        var description = Console.ReadLine();
        Console.Write("Enter health: ");
        var health = float.Parse(Console.ReadLine());
        Console.Write("Enter stamina: ");
        var stamina = float.Parse(Console.ReadLine());
        Console.Write("Enter responsibility type: ");
        var responsibilityType = Console.ReadLine().ToLower();
        
        string[] validTypes = { "heavy", "melee", "mystic", "ranged", "support" };
        if (!Array.Exists(validTypes, type => type == responsibilityType))
        {
            Console.WriteLine("Invalid type. Valid types are: heavy, melee, mystic, ranged, support.");
            return; // ensures that even if the user misspells a responsibility type, they will receive a 
            // clear message about valid types, prompting them to enter a correct one.
        }

        Creature creature = null;

        // Dynamically create the appropriate creature type using reflection
        switch (responsibilityType) { // ensures the user has typed a word in lower case
            case "heavy":
                Console.Write("Enter defense: ");
                var defense = int.Parse(Console.ReadLine());
                creature = (Creature)Activator.CreateInstance(typeof(Heavy), name, description, health, stamina, responsibilityType, defense);
                break;
            case "mystic":
                Console.Write("Enter mana: ");
                var mana = int.Parse(Console.ReadLine());
                creature = (Creature)Activator.CreateInstance(typeof(Mystic), name, description, health, stamina, responsibilityType, mana);
                break;
            case "ranged":
                Console.Write("Enter agility: ");
                var agility = int.Parse(Console.ReadLine());
                Console.Write("Enter dexterity: ");
                var dexterity = int.Parse(Console.ReadLine());
                creature = (Creature)Activator.CreateInstance(typeof(Ranged), name, description, health, stamina, responsibilityType, agility, dexterity);
                break;
            case "support":
                Console.Write("Enter healing: ");
                var healing = int.Parse(Console.ReadLine());
                creature = (Creature)Activator.CreateInstance(typeof(Support), name, description, health, stamina, responsibilityType, healing);
                break;
            case "melee":
                Console.Write("Enter agility: ");
                var meleeAgility = int.Parse(Console.ReadLine());
                Console.Write("Enter strength: ");
                var strength = int.Parse(Console.ReadLine());
                creature = (Creature)Activator.CreateInstance(typeof(Melee), name, description, health, stamina, responsibilityType, meleeAgility, strength);
                break;
            default:
                creature = new Creature(name, description, health, stamina, responsibilityType);
                break;
        }
        
        var filePath = $"{creature.GetName()}.json"; // Set the file path for saving the creature. 
        // *A name needs to be assigned to creature.
        creature.SaveCreature(filePath); // Save the creature to a file.
        Console.WriteLine($"Creature saved to {filePath}");

        _creatureList.Add(creature); // Add the creature to the list.
    }

static void LoadCreature() { // Method to load an existing creature.
        Console.Write("Enter creature name to load: ");
        var creatureName = Console.ReadLine(); // Read the creature name.
        var filePath = $"{creatureName}.json"; // Set the file path for loading the creature.
        var creature = Creature.LoadCreature(filePath); // Load the creature from the file.
        if (creature != null) {
            // Display the creature's data
            Console.WriteLine("Creature Details:");
            Console.WriteLine($"Name: {creature.GetName()}");
            Console.WriteLine($"Description: {creature.GetDescript()}");
            Console.WriteLine($"Health: {creature.GetHealth()}");
            Console.WriteLine($"Stamina: {creature.GetStamina()}");
        } else {
            Console.WriteLine("Failed to load creature.");
        }
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