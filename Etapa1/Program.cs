using System;
using Etapa1.Entities;

namespace Etapa1
{
    class Program
    {
        static void Main(string[] args)
        {
            School school = new School("Banting", 2001);
            school.SchoolType = SchoolTypes.Elementary;
            Console.WriteLine(school);
        }
    }
}