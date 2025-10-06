using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqOperations
{
    public class StudentOperations
    {
        public static void Run()
        {
            var students = new List<Student>
            {
                new Student("Alice", 21, "Computer Science", 'A'),
                new Student("Bob", 22, "Mathematics", 'B'),
                new Student("Charlie", 20, "Computer Science", 'A'),
                new Student("Diana", 23, "Physics", 'C'),
                new Student("Eve", 21, "Mathematics", 'A')
            };

            var aStudents = students
                .Where(s => s.Grade == 'A')
                .ToList();

            Console.WriteLine("A Students:");
            aStudents.ForEach(s => Console.WriteLine($"{s.Name} - {s.Major}"));

            var sortedByAge = students
                .OrderBy(s => s.Age)
                .ToList();

            Console.WriteLine("\nStudents Sorted by Age:");
            sortedByAge.ForEach(s => Console.WriteLine($"{s.Name} ({s.Age})"));

            var groupedByMajor = students
                .GroupBy(s => s.Major)
                .ToList();

            Console.WriteLine("nStudents Grouped by Major:");
            foreach (var group in groupedByMajor)
            {
                Console.WriteLine($"{group.Key}:");
                foreach (var s in group)
                {
                    Console.WriteLine($"  {s.Name} ({s.Grade})");
                }
            }

            var gradeScale = new Dictionary<char, int> { {'A', 4}, {'B', 3}, {'C', 2}, {'D', 1}, {'F', 0} };

            double avgGrade = students
                .Average(s => gradeScale[s.Grade]);

            Console.WriteLine($"\nAverage Grade (on 4.0 scale): {avgGrade:F2}");
        }
    }
}
