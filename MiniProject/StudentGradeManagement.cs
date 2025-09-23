using System;
using System.Collections.Generic;

namespace MiniProject
{
    public class Grade
    {
        public string Course { get; set; }
        public double Score { get; set; }

        public Grade(string course, double score)
        {
            Course = course;
            Score = score;
        }
    }

    public class Student
    {
        public string StudentID { get; set; }
        public string Name { get; set; }
        public List<Grade> Grades { get; set; }

        public Student(string studentID, string name)
        {
            StudentID = studentID;
            Name = name;
            Grades = new List<Grade>();
        }

        public void AddGrade(string course, double score)
        {
            Grades.Add(new Grade(course, score));
            Console.WriteLine($"Added grade {score} for {Name} in {course}.");
        }

        public void ViewGrades()
        {
            Console.WriteLine($"Grades for {Name} (ID: {StudentID}):");
            foreach (var grade in Grades)
            {
                Console.WriteLine($"Course: {grade.Course}, Score: {grade.Score}");
            }
        }

        public double CalculateGPA()
        {
            if (Grades.Count == 0) return 0.0;

            double totalScore = 0;
            foreach (var grade in Grades)
            {
                totalScore += grade.Score;
            }
            return totalScore / Grades.Count;
        }
    }

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
                Console.WriteLine($"{student.StudentID}: {student.Name}, GPA: {student.CalculateGPA():F2}");
            }
        }
    }

  
}
