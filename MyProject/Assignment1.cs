using System;
namespace MyProject
{   
    /// <summary>
    /// Assignment 1: Collect and display student information
    /// </summary>
    public class Assignment1
    {
        public void Run(string[] args)
        {
            // Input name
            Console.Write("Enter your name: ");
            string firstName = Console.ReadLine();

            // Greeting
            Console.WriteLine("Hello " + firstName);

            // Input DOB
            Console.Write("Enter your date of birth in the --- format ");
            string dateInput = Console.ReadLine();
            DateTime dateOfBirth = Convert.ToDateTime(dateInput);

            // Calculate age in days
            DateTime currentDate = DateTime.Now;
            double ageInDays = (currentDate - dateOfBirth).TotalDays;

            // Input grade
            Console.Write("Enter your grade (e.g. 10, 11, 12): ");
            string grade = Console.ReadLine();

            // Input GPA
            Console.Write("Enter your GPA: ");
            double gpa = Convert.ToDouble(Console.ReadLine());

            // Final Output
            Console.WriteLine(" Student Information ");
            Console.WriteLine($"Name: {firstName}");
            Console.WriteLine($"Age (in days): {(int)ageInDays}");
            Console.WriteLine($"Grade: {grade}");
            Console.WriteLine($"GPA: {gpa}");
        }
    }
}