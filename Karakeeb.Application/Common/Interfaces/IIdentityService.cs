namespace Karakeeb.Application;

public interface IIdentityService
{
    Task<int?> GetUserIdAsync(string email);
    Task<string?> GetUserNameAsync(int userId);
    Task<bool> IsInRoleAsync(int userId, string role);
}
