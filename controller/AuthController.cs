using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    [HttpPost("login")]
    public IActionResult Login(LoginDto loginDto)
    {
        string role;

        if (loginDto.Username == "admin" &&
            loginDto.Password == "password")
        {
            role = "Admin";
        }
        else if (loginDto.Username == "employee" &&
                 loginDto.Password == "password")
        {
            role = "Employee";
        }
        else
        {
            return Unauthorized();
        }

        var claims = new[]
        {
            new Claim(ClaimTypes.Name, loginDto.Username),
            new Claim(ClaimTypes.Role, role)
        };

        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(
                "ThisIsMyVerySecretKeyForJwtToken12345"));

        var creds = new SigningCredentials(
            key,
            SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: "EnterprisePlatform",
            audience: "EnterprisePlatformUsers",
            claims: claims,
            expires: DateTime.Now.AddHours(1),
            signingCredentials: creds);

        var jwt = new JwtSecurityTokenHandler()
            .WriteToken(token);

        return Ok(new
        {
            Token = jwt,
            Role = role
        });
    }
}