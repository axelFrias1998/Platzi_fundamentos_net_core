namespace Etapa2.Entities
{
    class School
    {
        /*public School(string name, int creationYear)
        {
            this.name = name.ToUpper();
            CreationYear = creationYear;
        }*/

        //Igualación por tuplas
        public School(string name, int foundationYear) => (Name, FoundationYear) = (name, foundationYear);

        public School(string name, int foundationYear, SchoolTypes schoolType, string country = "", string city = "")
        {
           (Name, FoundationYear) = (name, foundationYear);
            Country = country;
            City = city;
        }
        string name;

        public string Name
        {
            get { return name; }
            set { name = value.ToUpper(); }
        }

        public int FoundationYear { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public SchoolTypes SchoolType { get; set; }

        public Course[] Courses { get; set; }
        
        public override string ToString()
        {
            return $"Name: {Name}\nType: {SchoolType}\nCountry: {Country}\nFoundation Year: {FoundationYear}";
        }
    }
}