using System;
using System.Collections.Generic;
using Etapa3.Entities;
using static System.Console;

namespace Etapa3
{
    class Program
    {
        static void Main(string[] args)
        {
            School school = new School("Banting", 2001);
            school.SchoolType = SchoolTypes.Elementary;
            WriteLine(school + System.Environment.NewLine);

            School secondSchool = new School("RFM", 1980, SchoolTypes.HighSchool, country: "México", city: "Ciudad de México");
            WriteLine(secondSchool);

            var coursesList = new List<Course>(){
                new Course() { Name = "101", WorkTimeType = WorkTimeTypes.Morning },
                new Course() { Name = "201", WorkTimeType = WorkTimeTypes.Morning },
                new Course() { Name = "301", WorkTimeType = WorkTimeTypes.Morning }
            };

            school.Courses = coursesList;
            school.Courses.Add(new Course() {
                Name = "102", WorkTimeType = WorkTimeTypes.Evening
            });
            school.Courses.Add(new Course() {
                Name = "202", WorkTimeType = WorkTimeTypes.Evening
            });

            var extraMorningCourses = new List<Course>(){
                new Course() { Name = "401", WorkTimeType = WorkTimeTypes.Morning },
                new Course() { Name = "501", WorkTimeType = WorkTimeTypes.Morning },
                new Course() { Name = "502", WorkTimeType = WorkTimeTypes.Evening }
            };
            school.Courses.AddRange(extraMorningCourses);
            PrintSchoolCourses(school);
        }

        private static void PrintSchoolCourses(School school)
        {
            WriteLine("================");
            WriteLine("Available courses");
            WriteLine("================");

            if(school?.Courses is not null)
            {
                foreach (var course in school.Courses)
                    WriteLine($"Name: {course.Name}, ID: {course.CourseId}");
            }
        }

        private static void PrintCoursesForEach(Course[] coursesArray)
        {
            foreach (Course course in coursesArray)
                WriteLine($"Name: {course.Name}, ID: {course.CourseId}");
        }

        private static void PrintCoursesWhile(Course[] coursesArray)
        {
            int count = 0;
            while (count < coursesArray.Length)
            {
                WriteLine($"Name: {coursesArray[count].Name}, ID: {coursesArray[count].CourseId}");
                count++;
            }
        }

        private static void PrintCoursesDoWhile(Course[] coursesArray)
        {
            int count = 0;
            do
            {
                WriteLine($"Name: {coursesArray[count].Name}, ID: {coursesArray[count].CourseId}");  
                count++;              
            } while (count < coursesArray.Length);
        }

        private static void PrintCoursesFor(Course[] coursesArray)
        {
            for (int i = 0; i < coursesArray.Length; i++)
                WriteLine($"Name: {coursesArray[i].Name}, ID: {coursesArray[i].CourseId}");
        }
    }
}