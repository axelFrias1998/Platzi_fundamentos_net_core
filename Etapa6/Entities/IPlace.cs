namespace Etapa6.Entities
{
    public interface IPlace
    {
        string Address { get; set; }

        void CleanAddress();
    }
}