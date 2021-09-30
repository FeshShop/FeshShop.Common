namespace FeshShop.Common.Mongo
{
    using FeshShop.Common.Mongo.Attributes;
    using FeshShop.Common.Mongo.Contracts;
    using FeshShop.Common.Types;
    using MongoDB.Driver;
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public class MongoRepository<TEntity> : IMongoRepository<TEntity>
        where TEntity : IIdentifiable
    {
        protected IMongoCollection<TEntity> Collection { get; }

        public MongoRepository(IMongoDatabase database)
            => this.Collection = database.GetCollection<TEntity>(this.GetCollectionName(typeof(TEntity)));

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate)
            => await this.Collection.Find(predicate).SingleOrDefaultAsync();

        public async Task AddAsync(TEntity entity) => await this.Collection.InsertOneAsync(entity);

        private string GetCollectionName(Type documentType)
        {
            return ((BsonCollectionAttribute)documentType
                .GetCustomAttributes(typeof(BsonCollectionAttribute), true)
                .FirstOrDefault())?.CollectionName;
        }
    }
}
