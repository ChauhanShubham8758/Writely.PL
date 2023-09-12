using FluentValidation;
using Writely.BLL.ServiceModels.RequestModels.Address;

namespace Writely.BLL.Validators.Address
{
    public class AddCountryValidator : AbstractValidator<AddCountryModel>
    {
        public AddCountryValidator()
        {
            RuleFor(x => x.Name)
                    .NotEmpty().WithMessage(AddressResource.CountryNameRequired)
                    .MaximumLength(50);

            RuleFor(x => x.CountryCode)
                    .NotEmpty().WithMessage(AddressResource.CountryCodeRequired);

            RuleFor(x => x.CountryCode)
                     .NotEmpty().WithMessage(AddressResource.CountryCodeRequired);
        }
    }
}
