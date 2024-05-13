using System;
using System.Security.Cryptography.X509Certificates;
/* Header
    Learning02, WK3
    --Isaac Madrid--
    Assignment name
    05/07/24
    */

class Program
{
    static void Main(string[] args) {
        Console.WriteLine("Hello Learning02 World!");
        Job job1 = new Job();
        job1._jobTitle = "Software Engineer";
        job1._company = "Microsoft";
        job1._startYear = 2019;
        job1._endYear = 2022;
        //testJob.setJob("Software Engineer", "Microsoft", 2019, 2022);
        Console.WriteLine($"{job1._jobTitle} ({job1._company}) {job1._startYear}-{job1._endYear}");
        Job job2 = new Job();
        job2._jobTitle = "Manager";
        job2._company = "Apple";
        job2._startYear = 2022;
        job2._endYear = 2023;
        //testJob.setJob("Manager", "Apple", 2022, 2023);
        Console.WriteLine($"{job2._jobTitle} ({job2._company}) {job2._startYear}-{job2._endYear}");
    }
}