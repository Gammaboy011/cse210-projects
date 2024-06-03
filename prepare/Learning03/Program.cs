using System;

class Program {
    static void Main(string[] args) 
    {
        Fraction f1 = new Fraction();
        Console.WriteLine(f1.GetFractionString());
        Console.WriteLine(f1.GetDecimalValue());

        Fraction f2 = new Fraction(5);
        Console.WriteLine(f2.GetFractionString());
        Console.WriteLine(f2.GetDecimalValue());

        Fraction f3 = new Fraction(3, 4);
        Console.WriteLine(f3.GetFractionString());
        Console.WriteLine(f3.GetDecimalValue());

        Fraction f4 = new Fraction(1, 3);
        Console.WriteLine(f4.GetFractionString());
        Console.WriteLine(f4.GetDecimalValue());
        CashDrawer myCashDrawer = new CashDrawer();
        // customer paid for $17.72 purchase with a twenty dollar bill:
        myCashDrawer.Update(8, 1);
        // customer received $2.28 in change:
        myCashDrawer.Update(0, -3);
        myCashDrawer.Update(3, -1);
        myCashDrawer.Update(5, -2);
    }
}