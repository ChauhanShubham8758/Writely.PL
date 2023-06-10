using AutoMapper;
using OneOf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Writely.BLL.Builders.Users;
using Writely.BLL.ErrorCodes.User;
using Writely.BLL.Helpers;
using Writely.BLL.Infrastructure.Domains;
using Writely.BLL.Infrastructure.Extensions;
using Writely.BLL.ServiceModels.RequestModels.Users;
using Writely.BLL.ServiceModels.ResponseModels.Users;
using Writely.BLL.Services.IService.Users;
using Writely.BLL.Validators.Users;
using Writely.DAL.Repositories.IRepository.Users;

namespace Writely.BLL.Services.Service.User
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IHelperService _helperService;
        public UserService(IHelperService helperService, IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _helperService = helperService;
            _mapper = mapper;
        }

        public async Task<OneOf<UserDisplayModel, WritelyError>> CreateUser(AddUserModel model, CancellationToken cancellationToken)
        {
            try
            {
                //1. Validate incoming model
                var validator = new AddUserValidator();
                var valResult = await validator.ValidateAsync(model, cancellationToken);
                if (!valResult.IsValid)
                {
                    return new WritelyValidationError(valResult.GetErrorMessagesWithPropertyName());
                }

                //2. Converting incoming model into domain model
                var encryptResponseModel = _helperService.Encrypt(model.Password);
                var user = UserBuilder.Convert(model, encryptResponseModel);
                user.Username = model.FirstName + model.LastName;
                user.IsActive = true;
                user.CreatedAt = DateTime.UtcNow;
                user.UpdatedAt = DateTime.UtcNow;
                var outcome = await _userRepository.SaveUser(user, cancellationToken);

                //3. Send Error When outcome false
                if (!outcome) return new ErrorCreatingUser();

                //4. Returning model after converting into display model
                user = await _userRepository.GetUser(user.Id, cancellationToken);
                var returnmodel = _mapper.Map<UserDisplayModel>(user);
                return returnmodel;
            }
            catch(Exception ex)
            {
                var error = new ErrorCreatingUser(ex);
                return error;
            }
        }

        public async Task<OneOf<UserDisplayModel, WritelyError>> GetUserById(UserDisplayModel model, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
