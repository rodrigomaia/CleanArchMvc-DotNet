using CleanArchMvc.Domain.Account;
using CleanArchMvc.WebUI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchMvc.WebUI.Controllers;

public class AccountController(IAuthenticate authenticate) : Controller
{
    [HttpGet]
    public IActionResult Login(string returnUrl)
    {
        LoginViewModel model = new()
        {
            ReturnUrl = returnUrl
        };

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        var result = await authenticate.Autenticate(model.Email, model.Password);

        if (result)
        {
            if (string.IsNullOrEmpty(model.ReturnUrl))
                return RedirectToAction("Index", "Home");

            return Redirect(model.ReturnUrl);
        }
        else
        {
            ModelState.AddModelError(string.Empty, "Invalid login or password");
            return View(model);
        }
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(LoginViewModel model)
    {
        var result = await authenticate.RegisterUser(model.Email, model.Password);

        if (result)
        {
            return RedirectToAction("Index", "Home");
        }
        else
        {
            ModelState.AddModelError(string.Empty, "Invalid login or password");
            return View(model);
        }
    }

    [HttpGet]
    public async Task<IActionResult> Logout(){
        await authenticate.Logout();
        return Redirect("/Account/Login");
    }

}