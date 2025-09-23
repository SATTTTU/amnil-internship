  using System;
namespace MiniProject
{
    class Program
    {
        static void Main(string[] args)
        {
            // StudentManager manager = new StudentManager();

            // Student s1 = new Student("S001", "Satish");
            // s1.AddGrade("Math", 90);
            // s1.AddGrade("Science", 85);

            // Student s2 = new Student("S002", "Myname ");
            // s2.AddGrade("Math", 70);
            // s2.AddGrade("English", 80);

            // manager.AddStudent(s1);
            // manager.AddStudent(s2);

            // manager.ViewAllStudents();

            // s1.ViewGrades();
             Car car1 = new Car("Toyota", "Corolla", 2020, "White");
            Car car2 = new Car("Honda", "Civic", 2019, "Black");
            Car car3 = new Car("Ford", "Mustang", 2022, "Red");

            car1.DisplayInfo();
            car1.Start();
            car1.Accelerate(60);
            car1.Stop();

            Console.WriteLine(); 

            car2.DisplayInfo();
            car2.Start();
            car2.Accelerate(80);
            car2.Stop();

            Console.WriteLine();

            car3.DisplayInfo();
            car3.Start();
            car3.Accelerate(120);
            car3.Stop();

            Console.ReadLine();
        }
    }
}