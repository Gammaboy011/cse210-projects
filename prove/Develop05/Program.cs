using System;
using System.Runtime;

class Program   {
    private int totalPoints = 0;
    protected List<Goal> Goals = [];
    static void Main(string[] args) {
        var program = new Program();
        Console.WriteLine("**Eternal Quest**"); // Display the title
        program.Display(); // Call the method to display the menu

    }

    public void Display () { // Main menu for user to make selections
        while (true){
            Console.WriteLine($"\nYou have {totalPoints} points!\n"); // Display total points
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Create New Goal"); // Create a new Goal.
            Console.WriteLine("2. List Goal"); // List all Goals in file.
            Console.WriteLine("3. Save Goals"); // Save all goals to a file.
            Console.WriteLine("4. Load Goals"); // Load all goals in a file.
            Console.WriteLine("5. Record Goals"); // Record all Goals in a file.
            Console.WriteLine("6. Exit"); // Exit the program.
            Console.Write("Choose an option: ");
            string input = Console.ReadLine(); // Read user choice
            Console.Clear(); // Clear the console screen
            int choice;
            if (int.TryParse(input, out choice)) { // Call the method to handle the chosen activity
                // Process the choice
                switch (choice) { // If the input is a valid integer (int.TryParse returns true)
                    case 1:
                        CreateGoal(); // Create New Goal
                        break;
                    case 2:
                        ListGoals(); // List Goals
                        break;
                    case 3:
                        SaveGoals(); // Save Goals
                        break;
                    case 4:
                        LoadGoals(); // Load Goals
                        break;
                    case 5:
                        RecordGoals(); // Record Goals
                        break;
                    case 6:
                        Console.Clear();
                        Console.WriteLine("Remember to make SMART GOALS!");
                        Environment.Exit(0); // Exit
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
    private void CreateGoal() { // Method for creating a new goal by the user
        Goal goal = Goal.CreateGoalFromUserInput();
        if (goal != null) { // *Updated the CreateGoal method to use new 'FindAndReplaceGoalById' method
            FindAndReplaceGoalById(goal);
        } else {
            Console.WriteLine("Goal creation failed.");
        }
    }
    private void ListGoals() { // Method for listing all goals created by the user
        foreach (var goal in Goals) {
            Console.WriteLine(goal);
        }
        Console.Write("\nPress any key to continue... ");
        Console.ReadKey();
    }
    private void SaveGoals() { // Method for creating a new file for current goals made.
        Console.Write("Enter the filename to save goals: ");
        string filename = Console.ReadLine();
        using (StreamWriter writer = new StreamWriter(filename)) {
            writer.WriteLine(totalPoints); // Save the total points at the top
            foreach (var goal in Goals) {
                writer.WriteLine(goal);
            }
        }
        Console.WriteLine("Goals successfully saved!");
    }
    private void LoadGoals() { // Method for opening a file created by the user.
        Console.Write("Enter the filename to load goals: ");
        string filename = Console.ReadLine();
        if (File.Exists(filename)) {
            Goals.Clear();
            using (StreamReader reader = new StreamReader(filename)) {
                totalPoints = int.Parse(reader.ReadLine()); // Load the total points
            string line;
            while ((line = reader.ReadLine()) != null) {
                Goal goal = Goal.CreateGoalFromString(line);
                if (goal != null) {
                    Goals.Add(goal);
                }
            }
        }
        Console.WriteLine("Goals successfully loaded!");
    } else {
        Console.WriteLine("File not found.");
        }
    }
    private void RecordGoals() { // method to update totalPoints with points earned from completed goals.
        Console.Write("Enter Goal ID to record goal: ");
        int id = int.Parse(Console.ReadLine());
        foreach (var goal in Goals) {
            if (goal.Id == id) {
                int points = goal.MarkComplete();
                totalPoints += points;
                Console.WriteLine("Event recorded successfully!");
                return;
            }
        }
        Console.WriteLine("Goal not found.");
    }
    private void FindAndReplaceGoalById(Goal newGoal) { // *Method to find and replace a goal by its ID
    for (int i = 0; i < Goals.Count; i++) {
        if (Goals[i].Id == newGoal.Id) {
            Goals[i] = newGoal;
            Console.WriteLine("Goal updated successfully!");
            return;
        }
    }
    Goals.Add(newGoal); // If not found, add as new goal.
    Console.WriteLine("Goal created successfully!");
}
}