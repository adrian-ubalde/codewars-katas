using System;
using System.Collections.Generic;
using Xunit;

namespace Kata.PeterTakesAnExam2
{
    public class UnitTest1
    {
        [Fact]
        public void WhenGradeIsGreaterThanAcceptanceGrade_StudentPasses()
        {
            var result = Kata.PassedStudentList(
                new List<Student>
                {
                    new Student { Name = "Adrian", Grade = 9.1 }
                },
                9);

            Assert.Equal(new List<string> { "Adrian" }, result);
        }

        [Fact]
        public void WhenGradeIsEqualToAcceptanceGrade_StudentPasses()
        {
            var result = Kata.PassedStudentList(
                new List<Student>
                {
                    new Student { Name = "Adrian", Grade = 9 },
                },
                9);

            Assert.Equal(new List<string> { "Adrian" }, result);
        }

        [Fact]
        public void WhenGradeIsLessThanAcceptanceGrade_StudentDoesNotPass()
        {
            var emptyList = new List<string>();
            var result = Kata.PassedStudentList(
                new List<Student>
                {
                    new Student { Name = "Adrian", Grade = 8 }
                },
                9);

            Assert.Equal(emptyList, result);
        }
    }

    public class Student
    {
        public string Name { get; set; }
        public double Grade { get; set; }
    }

    public class Kata
    {
        public static List<string> PassedStudentList(List<Student> students, int acceptanceGrade)
        {
            var passedStudents = new List<string>();

            foreach (var student in students)
            {
                if (student.Grade >= acceptanceGrade)
                    passedStudents.Add(student.Name);
            }

            passedStudents.Sort();

            return passedStudents;
        }
    }
}
