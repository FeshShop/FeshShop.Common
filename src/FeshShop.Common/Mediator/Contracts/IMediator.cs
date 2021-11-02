namespace FeshShop.Common.Mediator.Contracts
{
    using FeshShop.Common.Mediator.Types;
    using System.Threading.Tasks;

    public interface IMediator
    {
        Task<TResult> QueryAsync<TResult>(IQuery<TResult> query);

        Task SendAsync<TModel>(TModel command) where TModel : ICommand;
    }
}
