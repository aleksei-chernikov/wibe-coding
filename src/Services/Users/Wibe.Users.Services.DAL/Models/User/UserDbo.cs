using MongoDB.Bson.Serialization.Attributes;

namespace Wibe.Users.Services.DAL.Models.User;

/// <summary>
/// Пользователь (модель БД)
/// </summary>
[BsonIgnoreExtraElements]
internal class UserDbo
{
    /// <summary>
    /// Название коллекции
    /// </summary>
    public const string Collection = "Users";
    
    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid UserId { get; set; }
    
    /// <summary>
    /// Имя пользователя
    /// </summary>
    [BsonIgnoreIfNull]
    public string? UserName { get; set; }
    
    /// <summary>
    /// Имя
    /// </summary>
    [BsonIgnoreIfNull]
    public string? FirstName { get; set; }
    
    /// <summary>
    /// Фамилия
    /// </summary>
    [BsonIgnoreIfNull]
    public string? LastName { get; set; }
    
    /// <summary>
    /// Отчество
    /// </summary>
    [BsonIgnoreIfNull]
    public string? MiddleName { get; set; }
    
    /// <summary>
    /// Является ли пользователь гостем
    /// (Не подтверждены не одни контактные данные)
    /// </summary>
    public bool IsGuest { get; set; }

    /// <summary>
    /// Контактные данные пользователя
    /// Ключ - UserContactType
    /// Значение - Контактные данные (сайт\телефон\email и т.п.)
    /// </summary>
    public List<UserContactDbo> Contacts { get; set; } = new();
}