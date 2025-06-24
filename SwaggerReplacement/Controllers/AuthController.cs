using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SwaggerReplacement.Controllers;

/// <summary>
/// Provides authentication and JWT token issuance.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    /// <summary>
    /// Issues a JWT token for testing secured endpoints.
    /// </summary>
    /// <returns>JWT token as string.</returns>
    /// <response code="200">Token issued successfully</response>
    [HttpPost("token")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GetToken()
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.Name, "test-user"),
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("this-is-a-very-secure-key-for-smart-only-123!"));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: null,
            audience: null,
            claims: claims,
            expires: DateTime.UtcNow.AddHours(1),
            signingCredentials: creds);

        var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

        return Ok(new { token = tokenString });
    }
}
