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
            if (number <= 1) 
                return false;

            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0) 
                    return false;
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

            if (number <= 1) 
                return 1;

            return number * Factorial(number - 1);
        }
    }
}
