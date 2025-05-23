namespace FeshShop.Common.Mongo;

using Contracts;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Bson.Serialization.Serializers;
using System.Collections.Generic;
using System.Threading.Tasks;

public class MongoDbInitializer(IMongoDbSeeder mongoSeeder, IOptions<MongoDbSettings> mongoOptions)
    : IMongoDbInitializer
{
    private static bool _initialized;
    private readonly bool seed = mongoOptions.Value.Seed;

    public async Task InitializeAsync()
    {
        if (_initialized)
            return;

        RegisterConventions();
        _initialized = true;

        if (!seed)
            return;

        await mongoSeeder.SeedAsync();
    }

    private static void RegisterConventions()
    {
        BsonSerializer.RegisterSerializer(new DecimalSerializer(BsonType.Decimal128));
        BsonSerializer.RegisterSerializer(new NullableSerializer<decimal>(new DecimalSerializer(BsonType.Decimal128)));
        BsonSerializer.RegisterSerializer(new GuidSerializer(BsonType.String));
        ConventionRegistry.Register("Conventions", new MongoDbConventions(), x => true);
    }

    private class MongoDbConventions : IConventionPack
    {
        public IEnumerable<IConvention> Conventions => new List<IConvention>
        {
            new IgnoreExtraElementsConvention(true),
            new EnumRepresentationConvention(BsonType.String),
            new CamelCaseElementNameConvention()
        };
    }
}