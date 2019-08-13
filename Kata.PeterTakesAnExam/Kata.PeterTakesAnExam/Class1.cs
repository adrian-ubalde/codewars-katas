using System.Collections.Generic;

namespace Kata.PeterTakesAnExam
{
    public class Kata
    {
        public static List<string> PassedStudentList(List<Student> gradeList, int acceptanceGrade)
        {
            gradeList.Sort((first, second) =>
            {
                if (first.Grade > second.Grade)
                {
                    return -1;
                }
                else if (first.Grade < second.Grade)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            });

            var passedStudents = new List<string>();
            foreach (var student in gradeList)
            {
                if (student.Grade >= acceptanceGrade)
                {
                    passedStudents.Add(student.Name);
                }
                else
                {
                    break;
                }
            }

            passedStudents.Sort();

            return passedStudents;
        }
    }

    public class Student
    {
        public string Name { get; set; }
        public double Grade { get; set; }
    }
}