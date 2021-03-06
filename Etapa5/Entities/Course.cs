using System.Collections.Generic;

namespace Etapa5.Entities
{
    public class Course : BaseObject
    {
        public WorkTimeTypes WorkTimeType { get; set; }

        public List<Class> Classes { get ; set; }

        public List<Student> Students { get; set; }
    }
}