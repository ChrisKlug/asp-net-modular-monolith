namespace FiftyNine.ModularMonolith.UserManagement;

public interface IUsers
{
    Task<User?> WithId(int id);
}
