  public class Student
    {
        public string StudentId { get; set; }
        public string Name { get; set; }
        public List<Grade> Grades { get; set; }

        public Student(string studentId, string name)
        {
            StudentId = studentId;
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
            Console.WriteLine($"Grades for {Name} (ID: {StudentId}):");
            foreach (var grade in Grades)
            {
                Console.WriteLine($"Course: {grade.Course}, Score: {grade.Score}");
            }
        }

       public double CalculateGPA()
{
        return Grades.Any() ? Grades.Average(g => g.Score) : 0;
}

    }