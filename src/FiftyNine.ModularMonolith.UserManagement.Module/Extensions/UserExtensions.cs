namespace FiftyNine.ModularMonolith.UserManagement.Module.Extensions;

public static class UserExtensions
{
    public static UserManagement.User ToUser(this User user)
        => UserManagement.User.Create(user.Id, user.FirstName, user.LastName);
}
