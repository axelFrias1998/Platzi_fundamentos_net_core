namespace Etapa5.Entities
{
    public class Evaluation : BaseObject
    {
        public Student Student { get; set; }

        public Class Class { get; set; }

        public float Score { get; set; }
    }
}