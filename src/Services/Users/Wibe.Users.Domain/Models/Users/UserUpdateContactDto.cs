using Wibe.Users.Common.Enums;

namespace Wibe.Users.Domain.Models.Users;

/// <summary>
/// Обновление контактных данных пользователя
/// </summary>
/// <param name="Type">Тип контактных данных пользователя</param>
/// <param name="Value">Значение для контактных данных (url \ телефон \ email и т.п.)</param>
/// <param name="IsPrimary">Основной канал для связи</param>
/// <param name="IsNotificationEnabled">Разрешил отправку уведомлений по этому каналу</param>
/// <param name="IsVerified">Верифицированный канал для связи</param>
public record UserUpdateContactDto(
    UserContactType Type, 
    string Value, 
    bool IsPrimary, 
    bool IsNotificationEnabled, 
    bool IsVerified
);