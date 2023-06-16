using Writely.BLL.Infrastructure.Domains;
using Writely.DAL.Models.Users.Domain;

namespace Writely.BLL.Helpers
{
    public interface IHelperService
    {
        EncryptResponseModel Encrypt(string password);
        string EncryptBySalt(string password, byte[] salt);
        string Authenticate(User user);
    }
}
