using System;
using System.Collections.Generic;

namespace MiniProject
{
    public class StudentManager
    {
        private List<Student> students = new List<Student>();

        public void AddStudent(Student student)
        {
            students.Add(student);
            Console.WriteLine($"Student {student.Name} added.");
        }

        public void ViewAllStudents()
        {
            foreach (var student in students)
            {
                Console.WriteLine($"{student.StudentId}: {student.Name}, GPA: {student.CalculateGPA():F2}");
            }
        }
    }

  
}
