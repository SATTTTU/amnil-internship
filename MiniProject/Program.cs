  using System;
namespace MiniProject
{
    class Program
    {
        static void Main(string[] args)
        {
            StudentManager manager = new StudentManager();

            Student s1 = new Student("S001", "Satish");
            s1.AddGrade("Math", 90);
            s1.AddGrade("Science", 85);

            Student s2 = new Student("S002", "Myname ");
            s2.AddGrade("Math", 70);
            s2.AddGrade("English", 80);

            manager.AddStudent(s1);
            manager.AddStudent(s2);

            manager.ViewAllStudents();

            s1.ViewGrades();
        }
    }
}