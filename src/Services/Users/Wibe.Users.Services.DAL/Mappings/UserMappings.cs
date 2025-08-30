using Wibe.Users.Domain.Models.Users;
using Wibe.Users.Services.DAL.Models.User;

namespace Wibe.Users.Services.DAL.Mappings;

/// <summary>
/// Маппинги DBO {=} DTO
/// </summary>
internal static class UserMappings
{
    /// <summary>Маппинг в Dto</summary>
    public static UserDto ToDto(this UserDbo user)
    {
        return new UserDto(
            user.UserId, 
            user.UserName, 
            user.FirstName, 
            user.LastName, 
            user.MiddleName, 
            user.IsGuest, 
            user.Contacts
            .Select(c => c.ToDto())
            .ToList());
    }

    /// <summary>Маппинг в Dto</summary>
    private static UserContactDto ToDto(this UserContactDbo contact)
    {
        return new UserContactDto(
            contact.Type, 
            contact.Value, 
            contact.IsPrimary, 
            contact.IsNotificationEnabled, 
            contact.IsVerified);
    }
    
    /// <summary>Маппинг в Dbo</summary>
    public static UserDbo ToDbo(this UserDto user)
    {
        return new UserDbo
        {
            UserId = user.UserId,
            UserName = user.UserName,
            FirstName = user.FirstName,
            LastName = user.LastName,
            MiddleName = user.MiddleName,
            Contacts = user.Contacts
                .Select(c => c.ToDbo())
                .ToList()   
        };
    }

    /// <summary>Маппинг в Dbo</summary>
    private static UserContactDbo ToDbo(this UserContactDto contact)
    {       
        return new UserContactDbo
        {
            Type = contact.Type,
            Value = contact.Value,
            IsPrimary = contact.IsPrimary,
            IsNotificationEnabled = contact.IsNotificationEnabled,
            IsVerified = contact.IsVerified 
        };
    }   
}
