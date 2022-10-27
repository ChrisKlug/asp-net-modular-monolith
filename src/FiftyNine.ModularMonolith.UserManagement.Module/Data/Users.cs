using FiftyNine.ModularMonolith.UserManagement.Module.Entities;
using FiftyNine.ModularMonolith.UserManagement.Module.Extensions;

namespace FiftyNine.ModularMonolith.UserManagement.Module.Data;

public interface IUsers
{
    Task<User?> WithId(int id);
}

public class Users : IUsers, UserManagement.IUsers
{
    public Task<User?> WithId(int id)
    {
        if (id != 1)
        {
            return Task.FromResult<User?>(null);
        }

        return Task.FromResult<User?>(User.Create(id, "Chris", "Klug"));
    }

    Task<UserManagement.User?> UserManagement.IUsers.WithId(int id)
        => WithId(id).ContinueWith(x => x.Result?.ToUser());
}
