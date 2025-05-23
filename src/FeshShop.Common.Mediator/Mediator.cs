namespace FeshShop.Common.Mediator;

using Contracts.Command;
using Contracts.Query;
using Contracts;
using System.Threading.Tasks;

public class Mediator(IQueryMediator queryMediator, ICommandMediator commandMediator)
    : IMediator
{
    public async Task<TResult> QueryAsync<TResult>(IQuery<TResult> query)
        => await queryMediator.QueryAsync(query);

    public async Task SendAsync<TModel>(TModel model) where TModel : ICommand 
        => await commandMediator.SendAsync(model);
}