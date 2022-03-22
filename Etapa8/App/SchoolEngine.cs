using static System.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using Etapa7.Entities;
using Etapa7.Util;

namespace Etapa7.App
{
    //Sealed --> Se pueden crear instancias de, pero no heredar de ella
    public sealed class SchoolEngine
    {
        public School School { get; set; }
        public SchoolEngine()
        {
        }

        public void Init()
        {
            School = new School("RFM", 1980, SchoolTypes.HighSchool, country: "México", city: "Ciudad de México");
            LoadCourses();
            LoadClasses();
            LoadEvaluations();
        }

        public Dictionary<Keys, IEnumerable<BaseObject>> GetDictionaryObj()
        {
            var dictionary = new Dictionary<Keys, IEnumerable<BaseObject>>();
            
            dictionary.Add(Keys.School, new[] { School });
            //Checar covarianza y contravarianza dictionary.Add(Keys.Courses, School.Courses.Cast<BaseObject>());           
            dictionary.Add(Keys.Courses, School.Courses);

            var tempEvaluations = new List<Evaluation>();
            var tempClasses = new List<Class>();
            var tempStudents = new List<Student>();

            foreach (var course in School.Courses)
            {
                tempStudents.AddRange(course.Students);
                tempClasses.AddRange(course.Classes);

                foreach (var student in course.Students)
                    tempEvaluations.AddRange(student.Evaluations);
            }
            dictionary.Add(Keys.Students, tempStudents);
            dictionary.Add(Keys.Classes, tempClasses);
            dictionary.Add(Keys.Evaluations, tempEvaluations);

            return dictionary;
        }

        public void PrintDictionary(Dictionary<Keys, IEnumerable<BaseObject>> dictionary, bool printEvaluations = false)
        {
            foreach (var item in dictionary)
            {
                Printer.PrintTitle(item.Key.ToString());
                foreach (var value in item.Value)
                {
                    switch (item.Key)
                    {
                        case Keys.Evaluations:
                            if(printEvaluations)
                                WriteLine(value);   
                            break;
                        case Keys.School:
                            WriteLine($"School: {value}");  
                            break;
                        case Keys.Students:
                            WriteLine($"Alumno: {value}");   
                            break;
                        case Keys.Courses:
                            var tmpCourse = value as Course;
                            if(tmpCourse is not null)
                            {
                                int count = ((Course)value).Students.Count;
                                WriteLine($"Curso: {value.Name}. Cantidad de alumnos: {count}");
                            }
                            break;
                        default:
                            WriteLine(value);
                            break;
                    }
                }
            }
        }

        #region Base object
        public IReadOnlyList<BaseObject> GetBaseObjects(bool hasEvaluations = true, bool hasStudents = true, bool hasClasses = true, bool hasCourses = true)
        {                            
            return GetBaseObjects(out int dummy, out dummy, out dummy, out dummy);
        }

        public IReadOnlyList<BaseObject> GetBaseObjects(out int countEvaluations, bool hasEvaluations = true, bool hasStudents = true, bool hasClasses = true, bool hasCourses = true)
        {                            
            return GetBaseObjects(out countEvaluations, out int dummy, out dummy, out dummy);
        }

        public IReadOnlyList<BaseObject> GetBaseObjects(out int countEvaluations, out int countStudents, bool hasEvaluations = true, bool hasStudents = true, bool hasClasses = true, bool hasCourses = true)
        {                            
            return GetBaseObjects(out countEvaluations, out countStudents, out int dummy, out dummy);
        }

        public IReadOnlyList<BaseObject> GetBaseObjects(out int countEvaluations, out int countStudents, out int countClasses, bool hasEvaluations = true, bool hasStudents = true, bool hasClasses = true, bool hasCourses = true)
        {                        
            return GetBaseObjects(out countEvaluations, out countStudents, out countClasses, out int dummy);
        }
        
        public IReadOnlyList<BaseObject> GetBaseObjects(out int countEvaluations, out int countStudents, out int countClasses, out int countCourses,
                                                        bool hasEvaluations = true, bool hasStudents = true, bool hasClasses = true, bool hasCourses = true)
        {
            countEvaluations = countStudents = countClasses = 0; 
            
            var objList = new List<BaseObject>();
            objList.Add(School);
            if(hasCourses)
                objList.AddRange(School.Courses);

            countCourses = School.Courses.Count;

            foreach (var course in School.Courses)
            {
                countClasses += course.Classes.Count;
                countStudents += course.Students.Count;

                if(hasClasses)
                    objList.AddRange(course.Classes);

                if(hasStudents)
                    objList.AddRange(course.Students);

                if(hasEvaluations)
                {
                    foreach (var student in course.Students)
                    {
                        objList.AddRange(student.Evaluations);
                        countEvaluations += student.Evaluations.Count;
                    }
                }
            }
                
            return objList.AsReadOnly();
        }

        /*public List<BaseObject> GetBaseObjects()
        {
            var objList = new List<BaseObject>();
            objList.Add(School);
            objList.AddRange(School.Courses);
            foreach (var course in School.Courses)
            {
                objList.AddRange(course.Classes);
                objList.AddRange(course.Students);

                foreach (var student in course.Students)
                {
                    objList.AddRange(student.Evaluations);
                }
            }
            return objList;
        }*/
        #endregion

        #region Load info
        private List<Student> CreateRandomStudents(int size)
        {
            string[] name = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
            string[] lastName = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
            string[] secondName = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };

            var students = from n in name
                            from n2 in secondName
                            from ln in lastName
                            select new Student { Name = $"{n} {n2} {ln}" };
            return students.OrderBy((student) => student.Id).Take(size).ToList();
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
                couse.Students = CreateRandomStudents(rnd.Next(10, 30));
        }

        private void LoadEvaluations()
        {
            var rnd = new Random();
            foreach (var course in School.Courses)
            {
                foreach (var clss in course.Classes)
                {
                    foreach (var student in course.Students)
                    {

                        for (int i = 0; i < 5; i++)
                        {
                            var evaluation = new Evaluation
                            {
                                Class = clss,
                                Name = $"{clss.Name} Evaluation#{i + 1}",
                                Score = MathF.Round(5 * (float)rnd.NextDouble(), 2),
                                Student = student
                            };
                            student.Evaluations.Add(evaluation);
                        }
                    }
                }
            }
        }   
        #endregion
    }
}