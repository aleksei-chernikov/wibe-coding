using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Wibe.Common.MongoDb.Configuration;
using Wibe.Common.MongoDb.Extensions;
using Wibe.Users.Services.DAL.Models.User;

namespace Wibe.Users.Services.DAL.DI;

/// <summary>
/// Расширения для добавления в DI базы данных
/// </summary>
public static class DatabaseLayerExtensions
{
    /// <summary>
    /// Добавить слой доступа к базе данных
    /// </summary>
    public static IServiceCollection AddDatabaseLayer(this IServiceCollection services, IConfiguration configuration)
    {
        return services
            .AddMongoDb(configuration)
            .AddCollection<UserDbo>(UserDbo.Collection);
    }

    
}