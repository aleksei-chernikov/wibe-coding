using Wibe.Users.Common.Enums;

namespace Wibe.Users.Services.DAL.Models.User;

/// <summary>
/// Контактные данные пользователя (модель БД)
/// </summary>
internal class UserContactDbo
{
    /// <summary>
    /// Тип контактных данных пользователя
    /// </summary>
    public UserContactType Type { get; set; }
    
    /// <summary>
    /// Значение для контактных данных (url \ телефон \ email и т.п.)
    /// </summary>
    public required string Value { get; set; }
    
    /// <summary>
    /// Основной канал для связи
    /// </summary>
    public bool IsPrimary { get; set; }
    
    /// <summary>
    /// Разрешил отправку уведомлений по этому каналу
    /// </summary>
    public bool IsNotificationEnabled { get; set; }
    
    /// <summary>
    /// Верифицированный канал для связи
    /// </summary>
    public bool IsVerified { get; set; }
}