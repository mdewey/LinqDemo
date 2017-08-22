using System;
using System.Collections.Generic;
using System.Linq;


namespace LinqDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var students = new List<Student>{
                new Student{ Name = "Hanna", Score = 98,IsPassing = true,SickDays = 0},
                new Student{ Name = "Allie", Score = 89,IsPassing = true,SickDays = 4},
                new Student{ Name = "Dan", Score =70,IsPassing = true,SickDays = 8},
                new Student{ Name = "Dat", Score = 60,IsPassing = false,SickDays = 2},
                new Student{ Name = "Lou", Score = 68,IsPassing = false,SickDays = 2},
                new Student{ Name = "Zach", Score = 100,IsPassing = true,SickDays = 0},
                new Student{ Name = "Jeff", Score = 99,IsPassing = true,SickDays = 0},
            };

            // BASICS
            // Select -- map
            var score = students.Select((s) =>
            {
                if (s.IsPassing && s.Score > 90 && s.SickDays < 2)
                    return "honor student";
                else 
                    return "non honors";
            });

            // Where -- filter
            var passingStudents = students.Where(w => w.IsPassing).Select(s => s.Name);


            // Aggregate -- reduce
            var totalDaysMissed = students.Aggregate(-5, (total, student) => {
                // return numbers
                return total + student.SickDays;
            });

            // ORDERING
            // First/ Last /orDefault
            var firstHonorStudent = students.FirstOrDefault(f => f.Score > 90);
            if (firstHonorStudent == null)
            {
                Console.WriteLine("Not students with a score about 90");
                
            }
            // OrderBy/Descending
            var highestScoreingStudent = students.OrderByDescending(student => student.Score).Last();

            // SOME MATH
            // Max
            var easyHighestScore = students.Max(f => f.Score);
            // Min
            var lowestSickdayCount = students.Min(m => m.SickDays);
            // Count
            var countOfFailing = students.Count(c => c.IsPassing);
            // Sum
            var totalSickdays = students.Sum(s => s.SickDays);
            // Average
            var avg = students.Average(s => s.Score);

            // Any
            var anyPerfectStudent = students.Any(a => a.Score == 100 && a.SickDays == 0);
            // All
            var IsEveryPassing = students.All(a => a.IsPassing);
            // Distinct
            var uniqueNames = students.Select(s => s.Name).Distinct();
            // Skip
            var secondHighestStudent = students.OrderByDescending(o => o.Score).Skip(1).First(); 
            // Take
            var pageNum = 4;
            var pageSize = 10;
            var pageOne = students.OrderBy(o => o.Name).Take(pageSize).Skip(pageSize * (pageNum-1);


            var studentGrade = students.ToDictionary(key => key.Name, value => value.Score);

            var datsScore = studentGrade["dat"];



            // BONUS: Query Syntax
            var values = from student in students
                        where student.Score > 90
                        orderby student.Name
                        select student.Name;

    

        }
    }
}
