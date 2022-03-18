namespace Etapa7.Entities
{
    public interface IPlace
    {
        string Address { get; set; }

        void CleanAddress();
    }
}