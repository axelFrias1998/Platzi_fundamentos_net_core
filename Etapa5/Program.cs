using System;
using System.Collections.Generic;
using Etapa4.App;
using Etapa4.Entities;
using Etapa4.Util;
using static System.Console;

namespace Etapa4
{
    class Program
    {
        static void Main(string[] args)
        {
            SchoolEngine engine = new SchoolEngine();
            engine.Init();
            Printer.PrintTitle("WELCOME");
            PrintSchoolCourses(engine.School);
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
                    WriteLine($"Name: {course.Name}, ID: {course.CourseId}");
            }
        }

    }
}