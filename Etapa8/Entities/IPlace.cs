namespace Etapa8.Entities
{
    public interface IPlace
    {
        string Address { get; set; }

        void CleanAddress();
    }
}