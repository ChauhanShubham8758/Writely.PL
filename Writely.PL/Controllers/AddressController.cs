using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Writely.BLL.ServiceModels.RequestModels.Address;
using Writely.BLL.Services.IService.Address;

namespace Writely.PL.Controllers
{
    public class AddressController : Controller
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
            return Ok();
        }

        public async Task<IActionResult> GetStates(CancellationToken cancellationToken = default)
        {
            var outcome = await _stateService.GetAllStates(cancellationToken);
            return Ok();
        }

        public async Task<IActionResult> GetStatesByCountryId([FromQuery]int countryId, CancellationToken cancellationToken = default)
        {
            var outcome = await _stateService.GetStatesByCountryId(countryId);
            return Ok(outcome.AsT0);
        }

        public async Task<IActionResult> GetCities(int stateId,CancellationToken cancellationToken = default)
        {
            var outcome = await _cityService.GetCityByStateId(stateId);
            return Ok(outcome.AsT0);
        }

        [HttpGet]
        public async Task<IActionResult> CountryHome()
        {
            var outcome = await _countryService.GetAllCountries();
            return View(outcome.AsT0);
        }

        public IActionResult AddCountry()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCountry(AddCountryModel addCountryModel)
        {
            return View();
        }
    }
}
