using System;
using System.ComponentModel;
public abstract class Goal {
    protected int _id;
    protected string _title;
    protected int _points;
    protected string _descript;

    public int Id{get{return _id;}} // Gives controlled access to the _id field of the Goal class.
    public int Points {get{return _points;}}
    public Goal(int id, string title, string descript, int points) {
            _id = id;
            _title = title;
            _descript = descript;
            _points = points;
        }

    public abstract int MarkComplete(); // method to return points earned.

    public override string ToString() { // used to display goals in a list.
        return base.ToString();
    }
    public static Goal CreateGoalFromUserInput() {
        Console.Write("Enter Goal ID: ");
        int id = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter Goal Type:\n1. SimpleGoal\n2. EternalGoal\n3. ChecklistGoal)");
        Console.Write("Choose an option: ");
        string input = Console.ReadLine(); // Read user choice
        int type;
        Console.Write("Enter Goal Title: ");
        string title = Console.ReadLine();
        Console.Write("Enter Goal Description: ");
        string descript = Console.ReadLine();
        Console.Write("Enter Goal Points: ");
        int points = int.Parse(Console.ReadLine());
        Console.Clear(); // Clear the console screen
        Goal goal = null; // Initialize goal to null
        if (int.TryParse(input, out type)) {
            switch (type) {
                case 1:
                    goal = new SimpleGoal(id, title, descript, points);
                    break;
                case 2:
                    goal = new EternalGoal(id, title, descript, points);
                    break;
                case 3:
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
        } else { // If the input is not a valid integer. (int.TryParse returns false)
        Console.WriteLine("Invalid input. Please enter a number.");
        }
        return goal; // Ensure goal is returned, even if it's null
    }

    public static Goal CreateGoalFromString(string goalString) {
        string[] parts = goalString.Split(',');
        int id = int.Parse(parts[0]);
        string title = parts[1];
        string descript = parts[2];
        int points = int.Parse(parts[3]);
        string type = parts[4];

        Goal goal = null;
        if (type == "SimpleGoal") {
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