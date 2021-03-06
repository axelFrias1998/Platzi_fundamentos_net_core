using System;
using System.Collections.Generic;
using System.Linq;
using Etapa6.App;
using Etapa6.Entities;
using Etapa6.Util;
using static System.Console;

namespace Etapa6
{
    class Program
    {
        static void Main(string[] args)
        {
            SchoolEngine engine = new SchoolEngine();
            engine.Init();
            Printer.PrintTitle("WELCOME");
            PrintSchoolCourses(engine.School);

            var objList = engine.GetBaseObjects();

            //Todos los objetos que cumplan con esas características (un contrato)
            var listIPlace = from obj in objList
                                where obj is IPlace
                                select (IPlace)obj;
            
            var listStudent = from obj in objList
                                where obj is Student
                                select (Student)obj;

            //ERROR SILENCIOSO y PELIGROSO
            //var listIPlace = from obj in objList
            //                    select (IPlace)obj;
            //            engine.School.CleanAddress();
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