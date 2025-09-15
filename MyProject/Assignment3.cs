using System;

namespace MyProject
{
    /// <summary>
    /// A simple calculator that performs basic arithmetic operations and calculates compound interest.
    /// </summary>
    public class SimpleCalculator
    {
        public void Run(string[] args)
        {
            Console.WriteLine("--- Simple Calculator ---");
            Console.Write("Enter first number: ");
            double num1 = double.Parse(Console.ReadLine());

            Console.Write("Enter second number: ");
            double num2 = double.Parse(Console.ReadLine());

            Console.WriteLine("\nChoose an operation:");
            Console.WriteLine("1. Add (+)");
            Console.WriteLine("2. Subtract (-)");
            Console.WriteLine("3. Multiply (*)");
            Console.WriteLine("4. Divide (/)");
            Console.WriteLine("5. Compound Interest");

            Console.Write("Enter choice (1-5): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine($"Result: {num1} + {num2} = {num1 + num2}");
                    break;

                case "2":
                    Console.WriteLine($"Result: {num1} - {num2} = {num1 - num2}");
                    break;

                case "3":
                    Console.WriteLine($"Result: {num1} * {num2} = {num1 * num2}");
                    break;

                case "4":
                    if (num2 == 0)
                    {
                        Console.WriteLine("Error: Division by zero is not allowed.");
                    }
                    else
                    {
                        Console.WriteLine($"Result: {num1} / {num2} = {num1 / num2}");
                    }
                    break;

                case "5":
                    Console.Write("\nEnter Principal (P): ");
                    double P = double.Parse(Console.ReadLine());

                    Console.Write("Enter Annual Rate of Interest (r in decimal, e.g. 0.05 for 5%): ");
                    double r = double.Parse(Console.ReadLine());

                    Console.Write("Enter number of times interest is compounded per year (n): ");
                    int n = int.Parse(Console.ReadLine());

                    Console.Write("Enter time in years (t): ");
                    int t = int.Parse(Console.ReadLine());

                    double A = P * Math.Pow((1 + r / n), n * t);
                    Console.WriteLine($"Compound Interest (Final Amount A): {A}");
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}
