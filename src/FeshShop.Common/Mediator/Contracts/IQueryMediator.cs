namespace FeshShop.Common.Mediator.Contracts
{
    using FeshShop.Common.Mediator.Types;
    using System.Threading.Tasks;

    public interface IQueryMediator
    {
        Task<TResult> QueryAsync<TResult>(IQuery<TResult> query);
    }
}
