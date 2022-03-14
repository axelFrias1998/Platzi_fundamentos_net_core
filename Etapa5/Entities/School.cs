using System.Collections.Generic;

namespace Etapa5.Entities
{
    public class School : BaseObject
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

        public List<Course> Courses { get; set; }
        
        public override string ToString()
        {
            return $"Name: {Name}\nType: {SchoolType}\nCountry: {Country}\nFoundation Year: {FoundationYear}";
        }
    }
}