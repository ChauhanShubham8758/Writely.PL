using AutoMapper;
using OneOf;
using Writely.BLL.Builders.Address;
using Writely.BLL.ErrorCodes.Address;
using Writely.BLL.Infrastructure.Domains;
using Writely.BLL.Infrastructure.Extensions;
using Writely.BLL.ServiceModels.RequestModels.Address;
using Writely.BLL.ServiceModels.ResponseModels.Address;
using Writely.BLL.Services.IService.Address;
using Writely.BLL.Validators.Address;
using Writely.DAL.Models.Address.Domain;
using Writely.DAL.Repositories.IRepository.Address;

namespace Writely.BLL.Services.Service.Address
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;
        public CountryService(ICountryRepository countryRepository, IMapper mapper)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
        }
        public async Task<OneOf<List<CountryDisplayModel>, WritelyError>> GetAllCountries(CancellationToken cancellationToken)
        {
            try
            {
                var countryList = await _countryRepository.GetAllCountry();
                if (countryList.Count <= 0)
                {
                    return new ErrorFetchingCountry();
                }
                else
                {
                    var returnModel = _mapper.Map<List<CountryDisplayModel>>(countryList);
                    return returnModel;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<OneOf<CountryDisplayModel, WritelyError>> CreateCountry(AddOrEditCountryModel addCountryModel, CancellationToken cancellationToken = default)
        {
            try
            {
                //1. Validate incoming model
                var validator = new AddCountryValidator();
                var valResult = await validator.ValidateAsync(addCountryModel, cancellationToken);
                if (!valResult.IsValid)
                {
                    return new WritelyValidationError(valResult.GetErrorMessagesWithPropertyName());
                }

                //2. Converting incoming model into domain model
                var country = CountryBuilder.Convert(addCountryModel);
                var outcome = await _countryRepository.SaveCountry(country);

                //3. Send Error When outcome false
                if (!outcome) return new ErrorCreatingCountry();

                //4. Returning model after converting into display model
                country = await _countryRepository.GetCountryById(country.Id, cancellationToken);
                var returnModel = _mapper.Map<CountryDisplayModel>(country);
                return returnModel;
            }
            catch (Exception ex)
            {
                var error = new ErrorCreatingCountry(ex);
                return error;
            }
        }

        public async Task<OneOf<bool, WritelyError>> DeleteCountry(int countryId, CancellationToken cancellationToken = default)
        {
            try
            {
                //1. Check if country exists or not
                var country = await _countryRepository.GetCountryById(countryId, cancellationToken);
                if (country is NullCountry) return new ErrorCountryNotFound(countryId);

                //2. Deleting the country if exists
                return await _countryRepository.RemoveCountry(country);
            }
            catch (Exception ex)
            {
                var error = new ErrorDeletingCountry(ex);
                return error;
            }
        }

        public async Task<OneOf<CountryDisplayModel, WritelyError>> GetCountryById(int countryId, CancellationToken cancellationToken = default)
        {
            try
            {
                var country = await _countryRepository.GetCountryById(countryId, cancellationToken);
                if (country is NullCountry)
                {
                    return new ErrorCountryNotFound(countryId);
                }
                else
                {
                    var returnModel = _mapper.Map<CountryDisplayModel>(country);
                    return returnModel;
                }
            }
            catch (Exception ex)
            {
                var error = new ErrorDeletingCountry(ex);
                return error;
            }
        }

        public async Task<OneOf<CountryDisplayModel, WritelyError>> PatchCountry(CountryDisplayModel editCountryModel, CancellationToken cancellationToken = default)
        {
            try
            {
                //1. Check if country exists or not
                var country = await _countryRepository.GetCountryById(editCountryModel.Id, cancellationToken);
                if (country is NullCountry) return new ErrorCountryNotFound(editCountryModel.Id);

                country = CountryBuilder.ConvertToEdit(editCountryModel);
                var outcome = await _countryRepository.UpdatCountry(editCountryModel.Id, country, cancellationToken);
                if (!outcome)
                {
                    return new ErrorUpdatingCountry(country.Id);
                }

                country = await _countryRepository.GetCountryById(editCountryModel.Id, cancellationToken);
                var returnModel = _mapper.Map<CountryDisplayModel>(country);
                return returnModel;
            }
            catch (Exception ex)
            {
                var error = new ErrorUpdatingCountry(editCountryModel.Id, ex);
                return error;
            }
        }
    }
}
