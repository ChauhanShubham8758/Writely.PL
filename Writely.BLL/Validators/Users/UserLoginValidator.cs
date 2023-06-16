using FluentValidation;
using Writely.BLL.ServiceModels.RequestModels.Users;

namespace Writely.BLL.Validators.Users
{
    public class UserLoginValidator : AbstractValidator<UserLoginModel>
    {
        public UserLoginValidator()
        {
            RuleFor(x => x.Email)
                        .NotEmpty().WithMessage(UserResource.EmailRequired)
                        .EmailAddress().WithMessage(UserResource.ValidEmail);

            RuleFor(x => x.Password)
                        .NotEmpty().WithMessage(UserResource.PasswordRequired)
                        .NotEqual(x => x.Email).WithMessage(UserResource.PasswordNotMail)
                        .Matches(UserResource.PasswordRegEx).WithMessage(UserResource.ValidPassword)
                        .Length(8, 50).WithMessage(UserResource.PasswordRange);
        }
    }
}
