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
            Console.WriteLine("==============================\nFor each:");
            PrintCoursesForEach(coursesArray);
            Console.WriteLine("==============================\nFor:");
            PrintCoursesFor(coursesArray);
            Console.WriteLine("==============================\nWhile:");
            PrintCoursesWhile(coursesArray);
            Console.WriteLine("==============================\nDo while:");
            PrintCoursesDoWhile(coursesArray);
        }

        private static void PrintCoursesForEach(Course[] coursesArray)
        {
            foreach (Course course in coursesArray)
                Console.WriteLine($"Name: {course.Name}, ID: {course.CourseId}");
        }

        private static void PrintCoursesWhile(Course[] coursesArray)
        {
            int count = 0;
            while (count < coursesArray.Length)
            {
                Console.WriteLine($"Name: {coursesArray[count].Name}, ID: {coursesArray[count].CourseId}");
                count++;
            }
        }

        private static void PrintCoursesDoWhile(Course[] coursesArray)
        {
            int count = 0;
            do
            {
                Console.WriteLine($"Name: {coursesArray[count].Name}, ID: {coursesArray[count].CourseId}");  
                count++;              
            } while (count < coursesArray.Length);
        }

        private static void PrintCoursesFor(Course[] coursesArray)
        {
            for (int i = 0; i < coursesArray.Length; i++)
                Console.WriteLine($"Name: {coursesArray[i].Name}, ID: {coursesArray[i].CourseId}");
        }
    }
}