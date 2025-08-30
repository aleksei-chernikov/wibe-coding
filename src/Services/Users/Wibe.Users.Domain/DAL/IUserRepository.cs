using Wibe.Users.Common.Enums;
using Wibe.Users.Domain.Models.Users;

namespace Wibe.Users.Domain.DAL;

/// <summary>
/// Репозиторий для работы с пользователями
/// </summary>
public interface IUserRepository 
{
    /// <summary>
    /// Получить пользователя
    /// </summary>
    Task<UserDto?> GetUser(Guid id, CancellationToken ct);

    /// <summary>
    /// Создать пользователя
    /// </summary>
    Task Create(UserDto user, CancellationToken ct);

    /// <summary>
    /// Обновить пользователя
    /// </summary>
    Task<UserDto> Update(UserUpdateDto user, CancellationToken ct);

    /// <summary>
    /// Обновить контакт пользователя
    /// </summary>
    Task<UserDto> UpdateContact(Guid id, UserUpdateContactDto userContact, CancellationToken ct);

    /// <summary>
    /// Удалить контакт пользователя
    /// </summary>
    Task<UserDto> RemoveContact(Guid id, UserContactType contactType, CancellationToken ct);

    /// <summary>
    /// Удалить пользователя
    /// </summary>
    Task Delete(Guid id, CancellationToken ct);
}
