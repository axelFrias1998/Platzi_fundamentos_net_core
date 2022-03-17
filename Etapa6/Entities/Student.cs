using System.Collections.Generic;

namespace Etapa6.Entities
{
    public class Student : BaseObject
    {
        public List<Evaluation> Evaluations { get; set; } = new List<Evaluation>();
    }
}