using System;

namespace Etapa4.Entities
{
    public class Evaluation
    {
        public Evaluation() => EvaluationId = Guid.NewGuid().ToString();
        
        public string EvaluationId { get; private set; }

        public string Name { get; set; }
    }
}