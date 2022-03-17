using System.Collections.Generic;
using Etapa6.Util;

namespace Etapa6.Entities
{
    public class School : BaseObject, IPlace
    {
        //Igualación por tuplas
        public School(string name, int foundationYear) => (Name, FoundationYear) = (name, foundationYear);

        public School(string name, int foundationYear, SchoolTypes schoolType, string country = "", string city = "") : base()
        {
           (Name, FoundationYear) = (name, foundationYear);
            Country = country;
            City = city;
        }

        public int FoundationYear { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public SchoolTypes SchoolType { get; set; }

        public string Address { get; set; }

        public List<Course> Courses { get; set; }

        public void CleanAddress()
        {
            Printer.PrintTitle($"School {Name} is clean");
            Printer.PrintTitle($"Cleaning courses ...");
            foreach (var course in Courses)
            {
                course.CleanAddress();
            }
        }

        public override string ToString()
        {
            return $"Name: {Name}\nType: {SchoolType}\nCountry: {Country}\nFoundation Year: {FoundationYear}";
        }
    }
}