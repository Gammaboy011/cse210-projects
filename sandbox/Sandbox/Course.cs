using System.ComponentModel.DataAnnotations;
//Using System.Console;
public class Course {
    public string _courseCode;
    public string _className;
    public int _numberOfCredits;
    public string _color;

    // method
    public void Display() {
        /*
        Course course1 = new Course();
        course1._className = "prog. w/Classes";
        course1._color = "green";
        course1._courseCode = "CSE 210";
        course1._numberOfCredits = 2;
        Console.WriteLine("Are we having fun yet?")
        */
        Console.WriteLine($"{_courseCode} {_className} {_numberOfCredits} {_color}");
    }
}
