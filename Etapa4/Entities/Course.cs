using System;
using System.Collections.Generic;

namespace Etapa4.Entities
{
    public class Course
    {
        public Course() => CourseId = Guid.NewGuid().ToString();
        public string CourseId { get; private set; }

        public string Name { get; set; }

        public WorkTimeTypes WorkTimeType { get; set; }

        public List<Class> Classes { get ; set; }

        public List<Student> Students { get; set; }
    }
}