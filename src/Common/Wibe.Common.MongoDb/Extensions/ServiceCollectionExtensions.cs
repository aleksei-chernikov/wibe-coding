using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using Wibe.Common.MongoDb.Configuration;

namespace Wibe.Common.MongoDb.Extensions;

/// <summary>
/// Расширения для добавления MongoDb в DI
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Добавить интерфейсы доступа к монге
    /// </summary>
    public static IServiceCollection AddMongoDb(this IServiceCollection services, IConfiguration configuration, string sectionName = "MongoDb")
    {
        var mongoConfig = MongoDbConfiguration.FromConfiguration(configuration, sectionName);
        services.AddSingleton(mongoConfig);

        return services
            .AddSingleton(mongoConfig)
            .AddSingleton<IMongoClient>(sp => new MongoClient(mongoConfig.ConnectionString))
            .AddSingleton<IMongoDatabase>(sp => sp.GetRequiredService<IMongoClient>().GetDatabase(mongoConfig.DatabaseName));
    }

    /// <summary>
    /// Добавить коллекцию монги в DI
    /// </summary>
    public static IServiceCollection AddCollection<T>(this IServiceCollection services, string collectionName)
    {
        return services
            .AddSingleton<IMongoCollection<T>>(sp =>
            {
                var db = sp.GetRequiredService<IMongoDatabase>();
                return db.GetCollection<T>(collectionName);
            });
    }
}