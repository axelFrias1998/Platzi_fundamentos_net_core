using System.Collections.Generic;
using Etapa8.Util;

namespace Etapa8.Entities
{
    public class Course : BaseObject, IPlace
    {
        public WorkTimeTypes WorkTimeType { get; set; }

        public List<Class> Classes { get ; set; }

        public List<Student> Students { get; set; }

        public string Address { get; set; }

        public void CleanAddress()
        {
            Printer.PrintTitle($"Course {Name} is clean");
        }
    }
}