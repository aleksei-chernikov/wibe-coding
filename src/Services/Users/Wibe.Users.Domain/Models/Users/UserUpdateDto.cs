namespace Wibe.Users.Domain.Models.Users;

/// <summary>
/// Обновление данных пользователя
/// </summary>
public record UserUpdateDto
{
    /// <summary>ctor.</summary>
    public UserUpdateDto(Guid userId, string? userName, string? firstName, string? lastName, string? middleName)
    {
        UserId = userId;
        UserName = userName;
        FirstName = firstName;
        LastName = lastName;
        MiddleName = middleName;
    }
    
    /// <summary>
    /// Идентификатор пользователя
    /// </summary>
    public Guid UserId { get; }

    /// <summary>
    /// Имя пользователя
    /// </summary>
    public string? UserName { get; }

    /// <summary>
    /// Имя
    /// </summary>
    public string? FirstName { get; }

    /// <summary>
    /// Фамилия
    /// </summary>
    public string? LastName { get; }
    
    /// <summary>
    /// Отчество
    /// </summary>
    public string? MiddleName { get; }
}