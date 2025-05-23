namespace FeshShop.Common.Mongo;

using Contracts;
using MongoDB.Driver;
using System.Threading.Tasks;

public class MongoDbSeeder(IMongoDatabase database) : IMongoDbSeeder
{
    protected readonly IMongoDatabase mongoDatabase = database;

    public async Task SeedAsync() => await this.CustomSeedAsync();

    protected virtual async Task CustomSeedAsync()
    {
        var cursor = await mongoDatabase.ListCollectionsAsync();
        var collections = await cursor.ToListAsync();

        if (collections.Count != 0)
            return;

        await Task.CompletedTask;
    }
}