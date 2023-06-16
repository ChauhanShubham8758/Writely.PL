using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Writely.BLL.Infrastructure.AppSettings;
using Writely.BLL.Infrastructure.Domains;
using Writely.DAL.Models.Users.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Writely.BLL.Helpers
{
    public class HelperService : IHelperService
    {
        private readonly JWTSettings _jwtSettings;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _contextAccessor;
        
        public HelperService(IConfiguration configuration, IHttpContextAccessor contextAccessor,
            IOptions<JWTSettings> jwtSettings)
        {
            _configuration = configuration;
            _contextAccessor = contextAccessor;
            _jwtSettings = jwtSettings.Value;
        }
        public EncryptResponseModel Encrypt(string password)
        {
            byte[] salt = new byte[128 / 8];

            using (var rngCsp = new RNGCryptoServiceProvider())
            {
                rngCsp.GetNonZeroBytes(salt);
            }

            string hash = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                    password: password,
                    salt: salt,
                    prf: KeyDerivationPrf.HMACSHA256,
                    iterationCount: 100000,
                    numBytesRequested: 256 / 8));

            return new EncryptResponseModel { Hash = hash, Salt = salt };
        }

        public string EncryptBySalt(string password, byte[] salt)
        {
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 100000,
            numBytesRequested: 256 / 8));

            return hashed;
        }

        public string  Authenticate(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(_jwtSettings.Key);

            var claims = new Dictionary<string, object>(){
                { ClaimTypes.Name, user.FirstName },
                { ClaimTypes.Surname, user.LastName },
                { ClaimTypes.Email, user.Email }
            };

            if (user.IsAuthor)
                claims.Add(ClaimTypes.Role, "Author");
            else if(user.IsAdmin)
                claims.Add(ClaimTypes.Role, "Admin");
            else
                claims.Add(ClaimTypes.Role, "User");


            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _jwtSettings.Issuer,
                Audience = _jwtSettings.Audience,
                Subject = new ClaimsIdentity(new List<Claim>
                {
                    new Claim("sub", user.Id.ToString())
                }),

                Claims = claims,
                Expires = DateTime.Now.AddHours(3),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
