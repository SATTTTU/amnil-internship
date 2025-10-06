using System;
using System.Collections.Generic;

namespace LinqOperations
{
    public class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Major { get; set; }
        public char Grade { get; set; }

        public Student(string name, int age, string major, char grade)
        {
            Name = name;
            Age = age;
            Major = major;
            Grade = grade;
        }
    }
}
