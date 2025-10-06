using System;

namespace Assignment5
{
 

    public class Program
    {
        public  void Run(string[] args)
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Calculate Circle Area");
            Console.WriteLine("2. Calculate Rectangle Area");
            Console.WriteLine("3. Calculate Triangle Area");
            Console.WriteLine("4. Check if a number is Prime");
            Console.WriteLine("5. Calculate Factorial");

            Console.Write("Enter your choice ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Enter radius: ");
                    double radius = double.Parse(Console.ReadLine());
                    Console.WriteLine($"Circle Area = {Utilities.CalculateCircleArea(radius)}");
                    break;

                case 2:
                    Console.Write("Enter length: ");
                    double length = double.Parse(Console.ReadLine());
                    Console.Write("Enter width: ");
                    double width = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine($"Rectangle Area = {Utilities.CalculateRectangleArea(length, width)}");
                    break;

                case 3:
                    Console.Write("Enter base length: ");
                    double baseLength = double.Parse(Console.ReadLine());
                    Console.Write("Enter height: ");
                    double height = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine($"Triangle Area = {Utilities.CalculateTriangleArea(baseLength, height)}");
                    break;

                case 4:
                    Console.Write("Enter a number: ");
                    int numPrime = int.Parse(Console.ReadLine());
                    Console.WriteLine(Utilities.IsPrime(numPrime)
                        ? $"{numPrime} is Prime"
                        : $"{numPrime} is NOT Prime");
                    break;

                case 5:
                    Console.Write("Enter a number: ");
                    int numFact = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine($"Factorial of {numFact} = {Utilities.Factorial(numFact)}");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please select between 1-5.");
                    break;
            }
        }
    }
}
