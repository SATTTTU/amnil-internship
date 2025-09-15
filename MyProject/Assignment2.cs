using System;
namespace MyProject
{
    public class Assignment2
    {
        public  void Run(string[] args)
        {
            // Collect personal information
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();

            Console.Write("Enter your age: ");
            int age = int.Parse(Console.ReadLine());

            Console.Write("Enter your city: ");
            string city = Console.ReadLine();

            Console.Write("Enter your favorite hobby: ");
            string hobby = Console.ReadLine();

            // Bonus: calculate birth year
            int currentYear = DateTime.Now.Year;
            int birthYear = currentYear - age;

            // Display formatted summary
            Console.WriteLine(" Personal Information Summary ");
            Console.WriteLine($"Name       : {name}");
            Console.WriteLine($"Age        : {age}");
            Console.WriteLine($"City       : {city}");
            Console.WriteLine($"Hobby      : {hobby}");
            Console.WriteLine($"Birth Year : {birthYear}");
        }
    }
}
