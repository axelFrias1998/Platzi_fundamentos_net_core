using System;
using Etapa2.Entities;

namespace Etapa2
{
    class Program
    {
        static void Main(string[] args)
        {
            School school = new School("Banting", 2001);
            school.SchoolType = SchoolTypes.Elementary;
            Console.WriteLine(school + System.Environment.NewLine);

            School secondSchool = new School("RFM", 1980, SchoolTypes.HighSchool, country: "México", city: "Ciudad de México");
            Console.WriteLine(secondSchool);

            var coursesArray = new Course[3];
            coursesArray[0] = new Course()
            {
                Name = "101"
            };
            coursesArray[1] = new Course()
            {
                Name = "201"
            };
            coursesArray[2] = new Course()
            {
                Name = "301"
            };
            System.Console.WriteLine("==============================");
            PrintCourses(coursesArray);
        }

        private static void PrintCourses(Course[] coursesArray)
        {
            foreach (Course course in coursesArray)
                Console.WriteLine($"Name: {course.Name}, ID: {course.CourseId}");
        }
    }
}