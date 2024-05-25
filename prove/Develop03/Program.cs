using System;
 /* In Addition I implimented a selection of scriptures for the user to 
 pick from which, if typed correctly, they be able access and memorize 
 that desired scripture. The "Reference" Class includes all additonal    
 verses with their corresponding reference to access them. */
public class Program {

    private Scripture _scripture; // Calls the Scripture Class.
    private Reference _reference; // Calls the Referance Class.
    private const int WordsToHide = 3; // Calls the Words Class with limit on how many words to hide at a time.
    public Program() { // Sets the Scripture and refrance to none at first.
        _scripture = null;
        _reference = null;
    }

    static void Main(string[] args) { // Start the program.
        Console.WriteLine("Scripture Memorizer:\n");
        Program program = new Program();
        program.Run();
    }

    public void Run() { // Runs the program. 
        SelectScripture();
        if (_scripture == null) {
            Console.WriteLine("Invalid scripture reference. Program terminated.");
            return;
        }
        
        _reference = new Reference(_scripture);
        while (true) { // Main program loop.
            Console.Clear(); // Resets the concole.
            Console.WriteLine(_reference.Display());
            if (IsComplete()) { // Breaks once all words are hidden
                Console.WriteLine("You have memorized the scripture!");
                break;
            }
            
            Console.WriteLine("Type: 'QUIT' to leave.");
            string input = Console.ReadLine();
            if (input.ToLower() == "quit") { // Ends the Program if the user types "quit".
                Console.WriteLine("Quitting the program.");
                break;
            }
            _scripture.HideRandomWords(WordsToHide);
        }
    }

    private void SelectScripture() { // *Lets the user choose from a varity of scripture verses.
        Console.WriteLine("Choose one of the following:\n- John 3:16\n- Proverbs 3:5-6\n- Matthew 11:28-30\n- 2 Nephi 31:29\n- Ephesians 2:8-9");
        Console.Write("Enter the scripture reference to memorize (e.g., John 3:16): ");
        string reference = Console.ReadLine();
        _scripture = Reference.GetScriptureRef(reference);
    }
    private bool IsComplete() { // Checks to see if all words in verse are hidden.
        return _scripture.Words.All(w => w.IsHidden);
    }
    
    // static void Main(string[] args) { // Refrence for how to use the "Console.Clear()" function.
        // Console.WriteLine("Hello Develop03 World!");
//        This will start by displaying "AAA" and waiting for the user to press the enter key
        // Console.WriteLine("AAA");
        // Console.ReadLine();
 
//        This will clear the console
        // Console.Clear();
// 
//        This will show "BBB" in the console where "AAA" used to be
        // Console.WriteLine("BBB");
    // }
}