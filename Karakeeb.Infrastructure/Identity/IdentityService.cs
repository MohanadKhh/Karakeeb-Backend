using Karakeeb.Application;
using Microsoft.AspNetCore.Identity;

namespace Karakeeb.Infrastructure;
public class IdentityService(UserManager<ApplicationUser> _userManager) : IIdentityService
{
    public async Task<int?> GetUserIdAsync(string email)
    {
        var user = await _userManager.FindByEmailAsync(email);

        return user?.Id;
    }

    public async Task<string?> GetUserNameAsync(int userId)
    {
        var user = await _userManager.FindByIdAsync(userId.ToString());

        return user?.UserName;
    }

    public async Task<bool> IsInRoleAsync(int userId, string role)
    {
        var user = await _userManager.FindByIdAsync(userId.ToString());

        if (user == null)
        {
            return false;
        }

        return await _userManager.IsInRoleAsync(user, role);
    }
}
