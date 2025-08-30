namespace Wibe.Users.Domain.Models.Users;

/// <summary>
/// Пользователь
/// </summary>
public record UserDto
{
    /// <summary>ctor.</summary>
    public UserDto(Guid userId, string? userName, string? firstName, string? lastName, string? middleName, bool isGuest, IReadOnlyCollection<UserContactDto> contacts)
    {
        UserId = userId;
        UserName = userName;
        FirstName = firstName;
        LastName = lastName;
        MiddleName = middleName;
        IsGuest = isGuest;
        Contacts = contacts;
    }

    /// <summary>
    /// Идентификатор
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
    
    /// <summary>
    /// Гость
    /// </summary>
    public bool IsGuest { get; }

    /// <summary>
    /// Контактные данные пользователя
    /// </summary>
    public IReadOnlyCollection<UserContactDto> Contacts { get; }  
}   