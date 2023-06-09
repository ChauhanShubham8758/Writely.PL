using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;
using Writely.BLL.Infrastructure.Domains;

namespace Writely.BLL.Helpers
{
    public class HelperService : IHelperService
    {
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
    }
}
