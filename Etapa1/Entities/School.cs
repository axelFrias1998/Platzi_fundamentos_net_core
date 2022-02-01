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
        public School(string name, int creationYear) => (Name, CreationYear) = (name, creationYear);

        string name;

        public string Name
        {
            get { return $"School's name is: {name}"; }
            set { name = value.ToUpper(); }
        }

        public int CreationYear { get; set; }

        public string City { get; set; }

        public string Country { get; set; }
    }
}