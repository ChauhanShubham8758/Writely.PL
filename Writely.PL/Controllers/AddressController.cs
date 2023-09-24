using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using Writely.BLL.ServiceModels.RequestModels.Address;
using Writely.BLL.ServiceModels.ResponseModels.Address;
using Writely.BLL.Services.IService.Address;
using X.PagedList;

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
        public async Task<IActionResult> CountryHome(int? page = 1)
        {
            if (page != null && page < 1)
            {
                page = 1;
            }

            var pageSize = 10;
            var outcome = await _countryService.GetAllCountries();
            return View(outcome.AsT0.ToPagedList(page ?? 1, pageSize));
        }

        public IActionResult AddCountry()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCountry(AddOrEditCountryModel addCountryModel, CancellationToken cancellationToken)
        {
            await _countryService.CreateCountry(addCountryModel, cancellationToken);
            return RedirectToAction("CountryHome");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCountry(int id, CancellationToken cancellationToken)
        {
            var outcome = await _countryService.DeleteCountry(id, cancellationToken);
            if (outcome.AsT0)
                return Ok(outcome.AsT0);
            else
                return BadRequest(outcome.AsT1);
        }

        [HttpGet]
        public async Task<IActionResult> EditCountry(int id)
        {
            var outcome = await _countryService.GetCountryById(id);
            return View(outcome.AsT0);
        }

        [HttpPost]
        public async Task<IActionResult> EditCountry(CountryDisplayModel countryDisplayModel)
        {
            var outcome = await _countryService.PatchCountry(countryDisplayModel);
            return RedirectToAction("CountryHome");
        }
    }
}
