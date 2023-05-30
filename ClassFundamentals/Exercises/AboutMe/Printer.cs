using System;

namespace AboutMe
{
    public class Printer
    {
        public static void PrintHeader()
        {
            Console.Clear();
            Console.WriteLine("About You\n============================");
        }

        public static void PrintAboutMe(string fName, string lName, DateTime dob, int age, string status)
        {
            Console.WriteLine($"Name: {lName}, {fName}");
            Console.WriteLine($"Age: {age}");
            Console.WriteLine($"DOB: {dob:d}");
            
            if(status == "S")
            {
                Console.WriteLine("Marital Status: Single");
            }
            else
            {
                Console.WriteLine("Marital Status: Married");
            }
        }
    }
}
