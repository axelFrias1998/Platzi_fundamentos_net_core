using System;

namespace Etapa4.Entities
{
    public class Student
    {
        public Student() => StudentId = Guid.NewGuid().ToString();
        
        public string StudentId { get; private set; }

        public string Name { get; set; }
    }
}