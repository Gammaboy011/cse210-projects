using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Learning04 World!");
        CashDrawer myCashDrawer = new CashDrawer();
        // customer paid for $17.72 purchase with a twenty dollar bill:
        myCashDrawer.Update(8, 1);
        // customer received $2.28 in change:
        myCashDrawer.Update(0, -3);
        myCashDrawer.Update(3, -1);
        myCashDrawer.Update(5, -2);
    }
}