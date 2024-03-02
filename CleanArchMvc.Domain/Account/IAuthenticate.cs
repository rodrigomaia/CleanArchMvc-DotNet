namespace CleanArchMvc.Domain.Account;

public interface IAuthenticate
{
    Task<bool> Autenticate(string email, string pass);
    Task<bool> RegisterUser(string email, string pass);
    Task Logout();
}