using System;

namespace Etapa3.Entities
{
    public class Course
    {
        public Course() => CourseId = Guid.NewGuid().ToString();
        public string CourseId { get; private set; }

        public string Name { get; set; }

        public WorkTimeTypes WorkTimeType { get; set; }
    }
}