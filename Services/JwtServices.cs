using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ChuyenDoiSoServer.Models;
using Microsoft.IdentityModel.Tokens;

namespace ChuyenDoiSoServer.Services;

public class JwtServices
{
    private readonly IConfiguration _configuration;

    public JwtServices(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public string GenerateAccessToken(Users user)
    {
        string signingKey = _configuration["JWT:Key"];
        string issuer = _configuration["JWT:Issuer"];
        string audience = _configuration["JWT:Audience"];
        _ = int.TryParse(_configuration["JWT:TokenValidityInHours"], out int accessTokenValidityInHours);

        // Add payload
        var claims = new List<Claim>() {
            new (ClaimTypes.Sid, user.Id.ToString()),
            new ("Hoten", user.Name),
            // new ("lastName", user.LastName),
        };
        user.UserVaitro?.ToList().ForEach(vaitro =>
        {
            claims.Add(new(ClaimTypes.Role, vaitro.Vaitro.Tenvaitro));
        }
        );

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signingKey));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            expires: DateTime.UtcNow.Add(TimeSpan.FromHours(accessTokenValidityInHours)),
            claims: claims,
            signingCredentials: creds
        );
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}