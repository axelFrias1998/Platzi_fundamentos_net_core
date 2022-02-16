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

            //Un predicado es un delegado. Un delegado es un tipo de método que define parámetros de entrada, los de salida, y puede ser consumido como argumento
            //school.Courses.RemoveAll(Predicado);
            
            //Delegado --> Para cada miembro, ejecuta la rutina. Si se cumple, elimina el objeto
            school.Courses.RemoveAll(delegate(Course course) {
                return course.Name.Equals("301");
            });
            //Expresión lambda (también un delegado)
            //school.Courses.RemoveAll((Course course) => course.Name.Equals("301"));
            school.Courses.RemoveAll((course) => course.Name.Equals("501") && course.WorkTimeType == WorkTimeTypes.Morning);
            PrintSchoolCourses(school);
        }

        private static bool Predicado(Course obj)
        {
            return obj.Name.Equals("301");
        }

        ///<summary></summary>
        ///
        ///
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