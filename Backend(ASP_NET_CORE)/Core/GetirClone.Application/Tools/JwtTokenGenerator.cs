using GetirClone.Application.Dto;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace GetirClone.Application.Tools
{
    public class JwtTokenGenerator
    {
        public static TokenResponseDto GenerateToken(UserDto dto)
        {
            var claims = new List<Claim>
            {
                new(ClaimTypes.NameIdentifier, dto.Id.ToString())
            };

            if (!string.IsNullOrWhiteSpace(dto.Name))
                claims.Add(new Claim("Name", dto.Name));

            if (!string.IsNullOrWhiteSpace(dto.PhoneNumber))
                claims.Add(new Claim("PhoneNumber", dto.PhoneNumber));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefaults.Key));

            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expireDate = DateTime.UtcNow.AddDays(JwtTokenDefaults.Expire);

            var refreshToken = GenerateRefreshToken();

            claims.Add(new Claim("refresh_token", refreshToken));

            JwtSecurityToken token = new JwtSecurityToken(issuer: JwtTokenDefaults.ValidIssuer, audience: JwtTokenDefaults.ValidAudience, claims: claims, notBefore: DateTime.UtcNow, expires: expireDate, signingCredentials: signingCredentials);

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            return new TokenResponseDto(tokenHandler.WriteToken(token), refreshToken, expireDate);
        }

        private static string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }
    }
}
