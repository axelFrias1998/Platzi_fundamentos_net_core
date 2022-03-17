namespace Etapa6.Entities
{
    public class Evaluation : BaseObject
    {
        public Student Student { get; set; }

        public Class Class { get; set; }

        public float Score { get; set; }

        public override string ToString()
        {
            return $"{Score}, {Student.Name}, {Class.Name}";
        }
    }
}