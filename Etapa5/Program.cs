using System;
using System.Collections.Generic;
using Etapa5.App;
using Etapa5.Entities;
using Etapa5.Util;
using static System.Console;

namespace Etapa5
{
    class Program
    {
        static void Main(string[] args)
        {
            SchoolEngine engine = new SchoolEngine();
            engine.Init();
            Printer.PrintTitle("WELCOME");
            PrintSchoolCourses(engine.School);

            Printer.PrintTitle("Pruebas polimorfismo");
            var student = new Student
            {
                Name = "Axelito mixxx"
            };
            BaseObject ob = student;
            Printer.PrintTitle("Alumno");
            WriteLine($"ID: {student.Id}. Alumno: {student.Name}");
            
            Printer.PrintTitle("Base object");
            WriteLine($"ID: {ob.Id}. Alumno: {ob.Name}");
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
            if(school?.Courses is not null)
            {
                foreach (var course in school.Courses)
                    WriteLine($"Name: {course.Name}, ID: {course.Id}");
            }
        }

    }
}