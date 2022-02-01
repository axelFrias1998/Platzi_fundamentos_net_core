namespace Etapa1.Entities
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

        string name;

        public string Name
        {
            get { return $"School's name is: {name}"; }
            set { name = value.ToUpper(); }
        }

        public int FoundationYear { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public SchoolTypes SchoolType { get; set; }

        
        public override string ToString()
        {
            return $"Name: {Name}\nType: {SchoolType}\nCountry: {Country}\nFoundation Year: {FoundationYear}";
        }
    }
}