namespace FeshShop.Common.Mediator.Contracts
{
    using FeshShop.Common.Mediator.Types;
    using System.Threading.Tasks;

    public interface ICommandMediator
    {
        public Task SendAsync<TModel>(TModel model) where TModel : ICommand;
    }
}
