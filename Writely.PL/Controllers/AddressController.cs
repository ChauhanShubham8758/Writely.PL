using Microsoft.AspNetCore.Mvc;
using Writely.BLL.Services.IService.Address;

namespace Writely.PL.Controllers
{
    public class AddressController : WritelyBaseController
    {
        private readonly ICountryService _countryService;
        private readonly IStateService _stateService;
        private readonly ICityService _cityService;

        public AddressController(ICountryService countryService, IStateService stateService, ICityService cityService)
        {
            _countryService = countryService;
            _stateService = stateService;
            _cityService = cityService;
        }
        public async Task<IActionResult> GetCountries(CancellationToken cancellationToken = default)
        {
            var outcome = await _countryService.GetAllCountries(cancellationToken);
            return ApiResult(outcome);
        }

        public async Task<IActionResult> GetStates(CancellationToken cancellationToken = default)
        {
            var outcome = await _stateService.GetAllStates(cancellationToken);
            return ApiResult(outcome);
        }

        public async Task<IActionResult> GetStatesByCountryId([FromQuery]int countryId, CancellationToken cancellationToken = default)
        {
            var outcome = await _stateService.GetStatesByCountryId(countryId);
            return ApiResult(outcome);
        }

        public async Task<IActionResult> GetCities(int stateId,CancellationToken cancellationToken = default)
        {
            var outcome = await _cityService.GetCityByStateId(stateId);
            return ApiResult(outcome);
        }
    }
}
