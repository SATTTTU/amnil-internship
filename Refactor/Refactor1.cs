using System;
namespace Refactor
{
    public class Refactor1
    {
        static int Sum(int number1, int number2)
        {
            return number1 + number2;
        }
        static int Multiply(int number1, int number2)
        {
            return number1 * number2;
        }
        static int Subtract(int number1, int number2)
        {
            return number1 - number2;
        }
        static int Division(int number1, int number2)
        {
            if (number2 == 0)
            {
                Console.WriteLine("Divide by zeo not allowed ");
                return 0;
            }
            return number1 / number2;
        }
        public void DisplayResult(int a, int b)
        {
            Console.WriteLine("Sum: " + Sum(a, b));
            Console.WriteLine("Multiply: " + Multiply(a, b));
            Console.WriteLine("Subtract: " + Subtract(a, b));
            Console.WriteLine("Division: " + Division(a, b));
        }

       
    }

}