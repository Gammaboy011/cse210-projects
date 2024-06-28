using System;
using System.ComponentModel;

public abstract class Goal { // Abstract base class representing a goal
    protected int _id; // Unique identifier for the goal
    protected string _title; // Title of the goal
    protected int _points; // Points awarded for completing the goal
    protected string _descript; // Description of the goal
    public int Id { get { return _id; } } // Property to get the goal's ID
    public int Points { get { return _points; } } // Property to get the points for the goal
    public Goal(int id, string title, string descript, int points) { // Constructor to initialize a goal with its ID, title, description, and points
        _id = id;
        _title = title;
        _descript = descript;
        _points = points;
    }

    public abstract int MarkComplete(); // Abstract method to mark a goal as complete, returning the points earned

    public override string ToString() { // Override ToString method to display the goal
        return base.ToString();
    }

    public static Goal CreateGoalFromUserInput() { // Static method to create a goal based on user input
        Console.Write("Enter Goal ID: ");
        int id = int.Parse(Console.ReadLine());
        // Prompt user to choose the type of goal
        Console.WriteLine("Enter Goal Type:\n1. SimpleGoal\n2. EternalGoal\n3. ChecklistGoal");
        Console.Write("Choose an option: ");
        string input = Console.ReadLine(); // Read user choice
        int type; // Get additional details about the goal from the user
        Console.Write("Enter Goal Title: ");
        string title = Console.ReadLine();
        Console.Write("Enter Goal Description: ");
        string descript = Console.ReadLine();
        Console.Write("Enter Goal Points: ");
        int points = int.Parse(Console.ReadLine());
        Console.Clear(); // Clear the console screen
        Goal goal = null; // Initialize goal to null

        
        if (int.TryParse(input, out type)) { // Try to parse the input to determine the type of goal
            switch (type) {
                case 1: // Create a SimpleGoal
                    goal = new SimpleGoal(id, title, descript, points);
                    break;
                case 2: // Create an EternalGoal
                    goal = new EternalGoal(id, title, descript, points);
                    break;
                case 3: // Create a ChecklistGoal
                    Console.Write("Enter Target Count: ");
                    int targetCount = int.Parse(Console.ReadLine());
                    Console.Write("Enter Bonus Points: ");
                    int bonusPoints = int.Parse(Console.ReadLine());
                    goal = new ChecklistGoal(id, title, descript, points, targetCount, bonusPoints);
                    break;
                default:
                    Console.WriteLine("Invalid goal type.");
                    break;
            }
        } else { // If the input is not a valid integer
            Console.WriteLine("Invalid input. Please enter a number.");
        }
        return goal; // Ensure goal is returned, even if it's null
    }
    // Static method to create a goal from a string (used for loading goals from a file)
    public static Goal CreateGoalFromString(string goalString) {
        string[] parts = goalString.Split(','); // Split the input string into parts
        int id = int.Parse(parts[0]); // Parse the ID
        string title = parts[1]; // Get the title
        string descript = parts[2]; // Get the description
        int points = int.Parse(parts[3]); // Parse the points
        string type = parts[4]; // Get the type of goal
        
        Goal goal = null;
        if (type == "SimpleGoal") { // Create the appropriate 'type' of goal based on the string input
            goal = new SimpleGoal(id, title, descript, points);
        }
        else if (type == "EternalGoal") {
            goal = new EternalGoal(id, title, descript, points);
        }
        else if (type == "ChecklistGoal") {
            int targetCount = int.Parse(parts[5]);
            int currentCount = int.Parse(parts[6]);
            int bonusPoints = int.Parse(parts[7]);
            goal = new ChecklistGoal(id, title, descript, points, targetCount, bonusPoints);
        }
        return goal;
    }
}