using Microsoft.Extensions.Configuration;

namespace Wibe.Common.MongoDb.Configuration;

/// <summary>
/// Конфигурация доступа к монге
/// </summary>
public class MongoDbConfiguration
{
    /// <summary>
    /// Строка подключения
    /// </summary>
    public required string ConnectionString { get; set; }
    
    /// <summary>
    /// Название базы данных для подключения
    /// </summary>
    public required string DatabaseName { get; set; }

    /// <summary>
    /// Создать параметры монги из указанной секции
    /// </summary>
    public static MongoDbConfiguration FromConfiguration(IConfiguration configuration, string sectionName = "MongoDb")
    {
        var result = configuration.GetSection(sectionName).Get<MongoDbConfiguration>();
        if (result == null)
            throw new Exception($"{sectionName} configuration section not found");

        return result;
    }
}