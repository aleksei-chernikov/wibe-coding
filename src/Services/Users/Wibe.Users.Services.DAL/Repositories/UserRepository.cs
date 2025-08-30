using MongoDB.Driver;
using Wibe.Users.Common.Enums;
using Wibe.Users.Domain.DAL;
using Wibe.Users.Domain.Models.Users;
using Wibe.Users.Services.DAL.Mappings;
using Wibe.Users.Services.DAL.Models.User;

namespace Wibe.Users.Services.DAL.Repositories;

/// <summary>
/// Репозиторий для работы c пользователями
/// </summary>
internal class UserRepository : IUserRepository
{
    private readonly IMongoCollection<UserDbo> _collection;

    public UserRepository(IMongoCollection<UserDbo> collection)
        => _collection = collection;

    public async Task<UserDto?> GetUser(Guid id, CancellationToken ct)
    {
        var result = await _collection.Find(x => x.UserId == id).FirstOrDefaultAsync(ct);
        return result?.ToDto();
    }

    public async Task Create(UserDto user, CancellationToken ct)
    {
        var dbo = user.ToDbo();
        await _collection.InsertOneAsync(dbo, cancellationToken: ct);
    }

    public async Task<UserDto> Update(UserUpdateDto user, CancellationToken ct)
    {
        var update = Builders<UserDbo>.Update
            .Set(x => x.UserName, user.UserName)
            .Set(x => x.FirstName, user.FirstName)
            .Set(x => x.LastName, user.LastName)
            .Set(x => x.MiddleName, user.MiddleName);

        var result = await _collection.FindOneAndUpdateAsync(x => x.UserId == user.UserId, update, cancellationToken: ct); 
        return result.ToDto();
    }

    public async Task<UserDto> UpdateContact(Guid id, UserUpdateContactDto userContact, CancellationToken ct)
    {
        // TODO: Так работает? По моему нет.
        var update = Builders<UserDbo>.Update
            .Set(x => x.Contacts.First(c => c.Type == userContact.Type).Value, userContact.Value)
            .Set(x => x.Contacts.First(c => c.Type == userContact.Type).IsPrimary, userContact.IsPrimary)
            .Set(x => x.Contacts.First(c => c.Type == userContact.Type).IsNotificationEnabled, userContact.IsNotificationEnabled)
            .Set(x => x.Contacts.First(c => c.Type == userContact.Type).IsVerified, userContact.IsVerified);

        var result = await _collection.FindOneAndUpdateAsync(x => x.UserId == id, update, cancellationToken: ct);
        return result.ToDto();
    }

    public async Task<UserDto> RemoveContact(Guid id, UserContactType contactType, CancellationToken ct)
    {
        var update = Builders<UserDbo>.Update
            .PullFilter(x => x.Contacts, Builders<UserContactDbo>.Filter.Eq(c => c.Type, contactType));

        var result = await _collection.FindOneAndUpdateAsync(x => x.UserId == id, update, cancellationToken: ct);
        return result.ToDto();
    }

    public async Task Delete(Guid id, CancellationToken ct)
    {
        await _collection.DeleteOneAsync(x => x.UserId == id, cancellationToken: ct);   
    }
}   
