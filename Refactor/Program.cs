using System;
namespace Refactor
{
    public class Program
    {
        public static void Main(String[] args)
        {
            Console.WriteLine("Which one do you wanna refactor");
            Console.WriteLine("1. Refactor1");
            Console.WriteLine("2. Refactor2");
            int choice = int.Parse(Console.ReadLine());
            if (choice == 2)
            {
                Console.WriteLine("Enter temperture in celcius ");
                double celcius = double.Parse(Console.ReadLine());
                Console.WriteLine("Enter the temperature in farhenheit");
                double farhenheit = double.Parse(Console.ReadLine());
                Console.WriteLine("Enter the temperature in Kelvin");
                double kelvin = double.Parse(Console.ReadLine());

                Refactor2 refactor2 = new Refactor2();
                refactor2.DisplayResult(celcius, farhenheit, kelvin);
                return;
            }
            else if (choice == 1)
            {
                Console.WriteLine("Enter the first number ");
                int a = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the second number ");
                int b = int.Parse(Console.ReadLine());
                Refactor1 refactor1 = new Refactor1();
                refactor1.DisplayResult(a, b);
            }
            else
            {
                Console.WriteLine("Invalid choice");
            }
        }
    }
}