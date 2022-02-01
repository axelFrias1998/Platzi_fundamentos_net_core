using System;
using System.Media;

namespace CoreEscuela
{
    /*
    dotnet new console -o (si es diferente el nombre a local) -f (framework sdk)
    */

    class School 
    {
        public string name;
        public string address;
        public int foundationYear;
        public string ceo;
        
        //This method won't work in Linux or Mac
        /*void MakeNoisse()
        {
            Console.Beep(10000, 3000);
        }*/
    }

    class Program
    {
        static void Main(string[] args)
        {
            School school = new School();
            school.name = "Platzi Academy";
            school.address = "Rey T.";
            school.foundationYear = 1998;
            school.ceo = "Axel";

            Console.WriteLine($"Escuela: {school.name}");
        }
    }
}
