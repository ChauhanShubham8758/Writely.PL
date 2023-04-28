using AutoMapper;
using OneOf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Writely.BLL.ErrorCodes.Address;
using Writely.BLL.Infrastructure.Domains;
using Writely.BLL.ServiceModels.ResponseModels.Address;
using Writely.BLL.Services.IService.Address;
using Writely.DAL.Repositories.IRepository.Address;

namespace Writely.BLL.Services.Service.Address
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;
        public CountryService(ICountryRepository countryRepository,IMapper mapper)
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
    }
}
