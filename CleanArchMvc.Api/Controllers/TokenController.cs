using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CleanArchMvc.Api.Models;
using CleanArchMvc.Domain.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace CleanArchMvc.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TokenController(IAuthenticate authenticate, IConfiguration configuration) : ControllerBase
{

    [HttpPost("LoginUser")]
    public async Task<ActionResult<UserToken>> Login([FromBody] LoginModel model)
    {
        var result = await authenticate.Autenticate(model.Email, model.Password);

        if (result)
        {
            return GenerateToken(model);
        }
        else
        {
            ModelState.AddModelError(string.Empty, "Invalid login");
            return BadRequest(ModelState);
        }
    }

    [HttpPost("RotaSecreta")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public async Task<ActionResult> RotaSecreta()
    {
        return Ok();
    }

    private UserToken GenerateToken(LoginModel model)
    {
        var claims = new[]{
            new Claim("email", model.Email),
            new Claim("algumaOutraChave", "qualquerValor"),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var privateKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:SecretKey"]));

        var credentials = new SigningCredentials(privateKey, SecurityAlgorithms.HmacSha256);
        var expiration = DateTime.Now.AddMinutes(10);

        JwtSecurityToken token = new(
            issuer: configuration["Jwt:Issuer"],
            audience: configuration["Jwt:Audience"],
            claims: claims,
            expires: expiration,
            signingCredentials: credentials
        );

        return new UserToken()
        {
            Token = new JwtSecurityTokenHandler().WriteToken(token),
            Expiration = expiration
        };
    }
}
