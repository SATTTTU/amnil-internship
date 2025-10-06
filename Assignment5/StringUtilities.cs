using System;
namespace Assignment5{
   
    public class CheckUtilities {
        public void Run(string[] args) {
            bool running =true;
            while (running)
            {
                Console.WriteLine("String Utilities:");
                Console.WriteLine("1. Count Words");
                Console.WriteLine("2. Reverse String");
                Console.WriteLine("3. Check Palindrome");
                Console.WriteLine("4. Remove Spaces");
                Console.WriteLine("5.Exit");

                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());
                if (choice == 5)
                {
                    Console.WriteLine("Exiting...");
                    running = false;
                    continue;
                }

                Console.Write("Enter the string: ");
                string input = Console.ReadLine();

                switch (choice)
                {
                    case 1:
                        Console.WriteLine(StringUtilities.CountWords(input));
                        break;
                    case 2:
                        Console.WriteLine($"Reversed String: {StringUtilities.ReverseString(input)}");
                        break;
                    case 3:
                        bool isPalindrome = StringUtilities.IsPalindrome(input);
                        Console.WriteLine(isPalindrome ? "The string is a palindrome." : "The string is not a palindrome.");
                        break;
                    case 4:
                        Console.WriteLine($"String without spaces: {StringUtilities.RemoveSpace(input)}");
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }
    }
}