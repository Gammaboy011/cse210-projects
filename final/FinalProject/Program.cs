/* Header
    Final, WK#
    --Isaac Madrid--
    Assignment name
    00/00/24
    */
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
class Program   {
    private static Profile _currentProfile; // The current user profile.
    private static Profile _opponentProfile;  // The opponent user profile.
    private static List<Creature> _creatureList = []; // List of created creatures.
    private static List<Move> _moveList = []; // List of available moves.
    private static bool _isGameRunning; // Flag to indicate if the game is running.
    private static Battle _currentBattle; // The current battle.
    // Main entry point of the program.
    static void Main(string[] args) {  
        _isGameRunning = true; // Initialize game running flag.
        Console.WriteLine("Welcome to the Creature Battle Simulator!");
        Directory.CreateDirectory("CSE210/All_Players");
        Directory.CreateDirectory("CSE210/All_Creatures");
        while (_isGameRunning) {
            DisplayMenu(); // Display the main menu.
        }
        static void DisplayMenu() { // Method to display the main menu.
            Console.WriteLine("\nMain Menu");
            Console.WriteLine("1. Create Profile");
            Console.WriteLine("2. Load Profile");
            Console.WriteLine("3. Create Creature");
            Console.WriteLine("4. Load Creature");
            Console.WriteLine("5. Battle");
            Console.WriteLine("6. Exit!");
            Console.Write("Choose an option: ");
            string input = Console.ReadLine(); // Read user choice.
            //Console.Clear(); // Clear the console screen.
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
                        ViewCreature(); // Once .txt can store data in file, have the program 'list' 
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
    // *Method to create a new profile.
    static void CreateProfile() { 
        Console.Write("Enter username: ");
        var userName = Console.ReadLine();
        //Console.Write("Enter level: "); // Needs to be revised so it updates after each code.
        var level = 0;
        // Create a new profile
        _currentProfile = new Profile(userName, level);
        var filePath = $"CSE210/All_Players/{userName}.json";
        _currentProfile.SaveProfile(filePath);
        Console.WriteLine($"Profile saved to {filePath}");
    }
    
    // Method to load an existing profile.
    private static Profile LoadProfile() { // *Program.LoadProfile()': not all code paths return a value
        
        Console.Write("Enter username to load: ");
        var userName = Console.ReadLine(); // Read the username.
        var filePath = $"CSE210/All_Players/{userName}.json";  // Set the file path for loading the profile.
        _currentProfile = Profile.LoadProfile(filePath);
    if (File.Exists(filePath)){
        // Read the file contents and check if the profile exists
        // string[] profiles = File.ReadAllLines(filePath);
        Console.WriteLine($"Profile loaded for {userName}");
        return Profile.LoadProfile(filePath); // Load the profile from the file.
         
    } else {
        Console.WriteLine("Profile file does not exist.");
        LoadProfile();
    }
 
    } // *A name needs to be assigned to profile created.

    static void CreateCreature() { // *Method to create a new creature.
        Console.Write("Enter creature name: "); // A name must be assinged to creature for it to be save on file
        var name = Console.ReadLine();
        Console.Write("Enter description: ");
        var description = Console.ReadLine();
        Console.Write("Enter health: ");
        var health = float.Parse(Console.ReadLine());
        Console.Write("Enter stamina: ");
        var stamina = float.Parse(Console.ReadLine());
        Console.Write("Enter responsibility type (heavy, melee, mystic, ranged, support): "); 
        // ensures that even if the user misspells a responsibility type, they will receive a 
        // clear message about valid types, prompting them to enter a correct one.
        var responsibilityType = Console.ReadLine().ToLower(); // ensures the user has typed a word in lower case
        
        // Dynamically create the appropriate creature type using reflection.
        Creature creature = responsibilityType.ToLower() switch
    {
        "heavy" => new Heavy(name, description, health, stamina,responsibilityType, GetAttribute("defense")),
        "melee" => new Melee(name, description, health, stamina, responsibilityType, GetAttribute("strength"),GetAttribute("melee agility")),
        "mystic" => new Mystic(name, description, health, stamina, responsibilityType, GetAttribute("mana")),
        "ranged" => new Ranged(name, description, health, stamina, responsibilityType, GetAttribute("agility"), GetAttribute("dexterity")),
        "support" => new Support(name, description, health, stamina, responsibilityType, GetAttribute("healing")),
        _ => throw new ArgumentException("Invalid responsibility type. Valid types are: heavy, melee, mystic, ranged, support.")
    };
        /*
        switch (responsibilityType) {
            case "heavy":
                Console.Write("Enter defense: ");
                int defense = int.Parse(Console.ReadLine());
                //creature = new Heavy(name, description, health, stamina, responsibilityType, defense);
                break;
            case "melee":
                Console.Write("Enter agility: ");
                int meleeAgility = int.Parse(Console.ReadLine());
                Console.Write("Enter strength: ");
                int strength = int.Parse(Console.ReadLine());
                //creature = new Melee(name, description, health, stamina, responsibilityType, meleeAgility, strength);
                break;
            case "mystic":
                Console.Write("Enter mana: ");
                int mana = int.Parse(Console.ReadLine());
                //creature = new Mystic(name, description, health, stamina, responsibilityType, mana);
                break;
            case "ranged":
                Console.Write("Enter agility: ");
                int agility = int.Parse(Console.ReadLine());
                Console.Write("Enter dexterity: ");
                int dexterity = int.Parse(Console.ReadLine());
                //creature = new Ranged(name, description, health, stamina, responsibilityType, agility, dexterity);
                break;
            case "support":
                Console.Write("Enter healing: ");
                int healing = int.Parse(Console.ReadLine());
                //creature = new Support(name, description, health, stamina, responsibilityType, healing);
                break;
            default:
                Console.WriteLine("Invalid responsibility type.");
                return;
        }
        */
        var filePath = $"CSE210/cse210-projects/final/All_Creatures/{name}.json"; // Set the file path for saving the creature.
        creature.SaveCreature(filePath); // Save the creature to a file.
        Console.WriteLine($"Creature saved to {filePath}");
        _creatureList.Add(creature); // Add the creature to the list.
    }
    private static int GetAttribute(string attributeName) {
    Console.WriteLine($"Enter {attributeName}:");
    return int.Parse(Console.ReadLine());
    }
    static void ViewCreature() { // Method to load an existing creature.
        Console.Write("Enter the name of the creature you want to view: ");
        var name = Console.ReadLine();
        var filePath = _creatureList.FirstOrDefault(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        
        if (File.Exists(name)) { // matching creature is found
            var json = File.ReadAllText(name);
            var creature = JsonSerializer.Deserialize<Creature>(json);
            filePath.DisplayDetails();
            Console.WriteLine("Do you want to add a move to this creature? (yes/no)");
            var addMoveChoice = Console.ReadLine();

            if (addMoveChoice?.ToLower() == "yes") {
                Move.AddMoveToCreature(creature);
                creature.SaveCreature($"CSE210/All_Creatures/{name}.json");
            }
        
        
        
        } // Details of the creature are displayed.
        else { // no matching creature is found
            Console.WriteLine($"No creature found with the name: {name}");
            return;
        }
    }


    static void StartBattle() {  // Method to start a battle.
        if (_currentProfile == null) {
            Console.WriteLine("Please create or load a profile first.");
            return;
        }
        Profile player1 = _currentProfile;

        Console.WriteLine("Second player, please load your profile.");
        _opponentProfile = LoadProfile();
        Profile player2 = _opponentProfile;
        if (_opponentProfile == null) {
            Console.WriteLine("Failed to load opponent profile. Battle cannot start.");
            return;
        }

        Console.WriteLine("Starting the battle...");
        _currentBattle = new Battle(player1, player2);
        _currentBattle.StartBattle();
        _currentBattle.CheckWinner();
    }
}