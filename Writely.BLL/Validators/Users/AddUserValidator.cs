using FluentValidation;
using Writely.BLL.ServiceModels.RequestModels.Users;

namespace Writely.BLL.Validators.Users
{
    public class AddUserValidator : AbstractValidator<AddUserModel>
    {
        public AddUserValidator()
        {
            RuleFor(x => x.FirstName)
                        .NotEmpty().WithMessage(UserResource.FirstNameRequired)
                        .MaximumLength(50).WithMessage(UserResource.ValidFirstName);

            RuleFor(x => x.LastName)
                        .NotEmpty().WithMessage(UserResource.LastNameRequired)
                        .MaximumLength(50).WithMessage(UserResource.ValidLastName);

            RuleFor(x => x.Email)
                        .NotEmpty().WithMessage(UserResource.EmailRequired)
                        .EmailAddress().WithMessage(UserResource.ValidEmail);

            RuleFor(x => x.Password)
                        .NotEmpty().WithMessage(UserResource.PasswordRequired)
                        .NotEqual(x => x.FirstName).WithMessage(UserResource.PasswordNotFirstName)
                        .NotEqual(x => x.LastName).WithMessage(UserResource.PasswordNotLastName)
                        .NotEqual(x => x.Email).WithMessage(UserResource.PasswordNotMail)
                        .Matches(UserResource.PasswordRegEx).WithMessage(UserResource.ValidPassword)
                        .Length(8, 50).WithMessage(UserResource.PasswordRange);

            RuleFor(x => x.PhoneNumber)
                        .NotEmpty().WithMessage(UserResource.MobileNumberRequired)
                        .Matches(UserResource.MobileRegEx).WithMessage(UserResource.ValidMobileNumber);

            RuleFor(x => x.Gender)
                        .IsInEnum().WithName("Gender").WithMessage("Invalid gender.");
        }
    }
}
