using Microsoft.IdentityModel.Tokens;
using System.Text;
using eShopApi.Models;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using eShopApi.Interfaces;

namespace eShopApi.Shared
{
    public class TokenService : ITokenService
    {
        private readonly SymmetricSecurityKey _key;
        public TokenService(IConfiguration configuration)
        {
            var token = configuration["TokenKey"];
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(token));
        }
        public string CreateToken(User user)
        {
            var claims = new List<Claim>
            {
                 new Claim(JwtRegisteredClaimNames.Email,user.Email),
                 new Claim(JwtRegisteredClaimNames.Name,user.UserName),
                  new Claim(JwtRegisteredClaimNames.NameId,user.Id),
                //  new Claim("roleId",user.RoleId.ToString()),
            };
            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = creds
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}