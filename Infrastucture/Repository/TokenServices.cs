using Infrastucture.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

public class TokenServices : ITokenServices
{
    private readonly IConfiguration configuration;

    public TokenServices(IConfiguration _configuration)
    {
        this.configuration = _configuration;
    }

    public string CreateToken(IdentityUser identityUser)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Email, identityUser.Email),
            new Claim(ClaimTypes.GivenName, identityUser.UserName)
        };


        var secretKey = configuration.GetValue<string>("SecretKey");
      
        var KeyInBytes = Encoding.ASCII.GetBytes(secretKey);

        var Key = new SymmetricSecurityKey(KeyInBytes);
        var credentials = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256Signature);



        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.Now.AddDays(15), 
            SigningCredentials = credentials 
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);  
    }
}