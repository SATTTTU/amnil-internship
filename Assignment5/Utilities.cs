using System;

namespace Assignment5
{
    public class Utilities
    {
        public static double CalculateCircleArea(double radius)
        {
            if (radius < 0)
            {
                Console.WriteLine("Radius cannot be negative.");
                return 0;
            }
            return Math.PI * radius * radius;
        }

        public static double CalculateRectangleArea(double length, double width)
        {
            if (length < 0 || width < 0)
            {
                Console.WriteLine("Length and width cannot be negative.");
                return 0;
            }
            return length * width;
        }

        public static double CalculateTriangleArea(double baseLength, double height)
        {
            if (baseLength < 0 || height < 0)
            {
                Console.WriteLine("Base length and height cannot be negative.");
                return 0;
            }
            return 0.5 * baseLength * height;
        }

        public static bool IsPrime(int number)
        {
            if (number <= 1) return false;
            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0) return false;
            }
            return true;
        }

        public static int Factorial(int number)
        {
            if (number < 0)
            {
                Console.WriteLine("Factorial is not defined for negative numbers.");
                return -1;
            }
            if (number == 0 || number == 1)
            {
                return 1;
            }
            return number * Factorial(number - 1);
        }
    }

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
