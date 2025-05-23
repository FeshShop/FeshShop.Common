namespace FeshShop.Common.Mediator.Contracts.Query;

public interface IQueryMediator
{
    Task<TResult> QueryAsync<TResult>(IQuery<TResult> query);
}