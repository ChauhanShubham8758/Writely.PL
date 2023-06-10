using AutoMapper;
using OneOf;
using Writely.BLL.ErrorCodes.Address;
using Writely.BLL.Infrastructure.Domains;
using Writely.BLL.ServiceModels.ResponseModels.Address;
using Writely.BLL.Services.IService.Address;
using Writely.DAL.Repositories.IRepository.Address;

namespace Writely.BLL.Services.Service.Address
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;

        public CityService(ICityRepository cityRepository, IMapper mapper)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
        }
        public async Task<OneOf<List<CityDisplayModel>, WritelyError>> GetAllCities(CancellationToken cancellationToken = default)
        {
            try
            {
                var citylist = await _cityRepository.GetAllCity();
                if (citylist.Count <= 0)
                {
                    return new ErrorFetchingCity();
                }
                else
                {
                    var returnModel = _mapper.Map<List<CityDisplayModel>>(citylist);
                    return returnModel;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<OneOf<List<CityDisplayModel>, WritelyError>> GetCityByStateId(int stateId, CancellationToken cancellationToken = default)
        {
            try
            {
                var citylist = await _cityRepository.GetCityByStateId(stateId);
                return citylist.Count <= 0 ? new List<CityDisplayModel>() : _mapper.Map<List<CityDisplayModel>>(citylist);
            }
            catch (Exception ex)
            {
                var error = new ErrorFetchingCity(ex);
                return error;
            }
        }
    }
}
