using System;
using System.Collections.Generic;
using System.Linq;
using Etapa4.Entities;

namespace Etapa4.App
{
    public class SchoolEngine
    {
        /*
        Carga aleatoria de evaluaciones
        5 evaluaciones x asignatura
        Por cada alumno de cada curso
        Notas al azar entre 0 y 5
        */
        public School School { get; set; }
        public SchoolEngine()
        {
        }

        public void Init()
        {
            School = new School("RFM", 1980, SchoolTypes.HighSchool, country: "México", city: "Ciudad de México");
            LoadClasses();
            foreach (var course in School.Courses)
                course.Students.AddRange(LoadStudents());
        }

        private void LoadCourses()
        {
            
            School.Courses = new List<Course>(){
                new Course() { Name = "101", WorkTimeType = WorkTimeTypes.Morning },
                new Course() { Name = "201", WorkTimeType = WorkTimeTypes.Morning },
                new Course() { Name = "301", WorkTimeType = WorkTimeTypes.Morning },
                new Course() { Name = "401", WorkTimeType = WorkTimeTypes.Morning },
                new Course() { Name = "501", WorkTimeType = WorkTimeTypes.Evening },
                new Course() { Name = "502", WorkTimeType = WorkTimeTypes.Evening }
            };

            Random rnd = new Random();
            foreach (var couse in School.Courses)
            {

                couse.Students = CreateRandomStudents(rnd.Next(10, 30));
            }
        }

        private List<Student> CreateRandomEvaluations(int size)
        {
            var evaluations = new List<Evaluation>();
            foreach (var course in School.Courses)
            {
                foreach (var clss in course.Classes)
                {
                    foreach (var student in course.Students)
                    {
                        var rnd = new Random(System.Environment.TickCount);

                        for (int i = 0; i < 5; i++)
                        {
                            var evaluation = new Evaluation
                            {
                                Class = clss,
                                Name = $"{clss.Name} Evaluation#{i + 1}",
                                Score = (float)(5 * rnd.NextDouble()),
                                Student = student
                            };
                            evaluations.Add(evaluation);
                        }
                    }
                }
            }
        }

        private List<Student> CreateRandomStudents(int size)
        {
            string[] name = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
            string[] lastName = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
            string[] secondName = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };

            var students = from n in name
                            from n2 in secondName
                            from ln in lastName
                            select new Student { Name = $"{n} {n2} {ln}" };
            return students.OrderBy((student) => student.StudentId).Take(size).ToList();
        }

        private void LoadClasses()
        {
            foreach (var course in School.Courses)
            {
                var classes = new List<Class>(){
                    new Class{ Name = "Math" },
                    new Class{ Name = "Physics" },
                    new Class{ Name = "Spanish" },
                    new Class{ Name = "Biology" }
                };
                course.Classes = classes;
            }
        }

        private void LoadEvaluations()
        {
            School.Courses = new List<Course>(){
                new Course() { Name = "101", WorkTimeType = WorkTimeTypes.Morning },
                new Course() { Name = "201", WorkTimeType = WorkTimeTypes.Morning },
                new Course() { Name = "301", WorkTimeType = WorkTimeTypes.Morning },
                new Course() { Name = "401", WorkTimeType = WorkTimeTypes.Morning },
                new Course() { Name = "501", WorkTimeType = WorkTimeTypes.Evening },
                new Course() { Name = "502", WorkTimeType = WorkTimeTypes.Evening }
            };
        }
    }
}