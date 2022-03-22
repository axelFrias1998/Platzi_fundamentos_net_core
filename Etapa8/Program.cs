using System;
using System.Collections.Generic;
using System.Linq;
using Etapa8.App;
using Etapa8.Entities;
using Etapa8.Util;
using static System.Console;

namespace Etapa8
{
    class Program
    {
        static void Main(string[] args)
        {
            //Evento con flujo normal de término
            AppDomain.CurrentDomain.ProcessExit += ActionEvent;
            //Acumula cualquier cantidad de delegados
            AppDomain.CurrentDomain.ProcessExit += (sender, e) => Printer.PrintTitle("Con lambda");
            //AppDomain.CurrentDomain.ProcessExit -= ActionEvent;

            SchoolEngine engine = new SchoolEngine();
            engine.Init();
            Printer.PrintTitle("WELCOME");
            PrintSchoolCourses(engine.School);

            /*var objList = engine.GetBaseObjects(out int countEvaluations, out dummy, out dummy, out dummy);
            var objList = engine.GetBaseObjects(out int countEvaluations, out int countStudents, out int countClasses, out int countCourses);

            //Todos los objetos que cumplan con esas características (un contrato)
            var listIPlace = from obj in objList
                                where obj is IPlace
                                select (IPlace)obj;
            
            var listStudent = from obj in objList
                                where obj is Student
                                select (Student)obj;

            //ERROR SILENCIOSO y PELIGROSO
            var listIPlace = from obj in objList
                                select (IPlace)obj;
                        engine.School.CleanAddress();*/
            var dictionary = engine.GetDictionaryObj();
            engine.PrintDictionary(dictionary, true);

            var report = new Report(null);
        }

        private static void ActionEvent(object sender, EventArgs e)
        {
            Printer.PrintTitle("FIN");
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