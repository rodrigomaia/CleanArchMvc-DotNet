using CleanArchMvc.Domain.Account;
using CleanArchMvc.Infra.Data.Identity;
using Microsoft.AspNetCore.Identity;

namespace CleanArchMvc.Infra.Data;

public class AuthenticateService(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager) : IAuthenticate
{
    public async Task<bool> Autenticate(string email, string pass)
    {
        var result = await signInManager.PasswordSignInAsync(email, pass, false, lockoutOnFailure: false);
        return result.Succeeded;
    }

    public async Task<bool> RegisterUser(string email, string pass)
    {
        var appUser = new ApplicationUser {
            UserName = email,
            Email = email,

        };

        var result = userManager.CreateAsync(appUser, pass);

        if (result.IsCompletedSuccessfully)
        {
            await signInManager.SignInAsync(appUser, isPersistent: false);
        }

        return result.IsCompletedSuccessfully;
    }

    public async Task Logout()
    {
        await signInManager.SignOutAsync();
    }

}