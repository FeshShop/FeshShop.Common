namespace FeshShop.Common
{
    using System.Threading.Tasks;

    public interface IInitializer
    {
        Task InitializeAsync();
    }
}
