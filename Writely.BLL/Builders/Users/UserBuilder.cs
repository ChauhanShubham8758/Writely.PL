using Writely.BLL.Infrastructure.Domains;
using Writely.BLL.ServiceModels.RequestModels.Users;
using Writely.DAL.Models.Users.Domain;

namespace Writely.BLL.Builders.Users
{
    public class UserBuilder
    {
        public static User Convert(AddUserModel model, EncryptResponseModel encryptResponseModel)
        {
            var user = new User(model.UserName, model.Email, encryptResponseModel.Salt, encryptResponseModel.Hash,
                model.FirstName, model.LastName, model.Gender, model.PhoneNumber, model.CityId, true, DateTime.Now, DateTime.Now);

            return user;
        }
    }
}
