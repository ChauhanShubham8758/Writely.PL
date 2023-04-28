using Microsoft.AspNetCore.Mvc;
using Writely.BLL.Services.IService.Address;

namespace Writely.PL.Controllers
{
    public class UserController : Controller
    {
        private readonly ICountryService _countryService;
        public UserController(ICountryService countryService)
        {
            _countryService = countryService;
        }
        public IActionResult LoginUser()
        {
            return View();
        }
        public async Task<IActionResult> RegisterUser()
        {
            var outcome = await _countryService.GetAllCountries();
            if (outcome.IsT0)
            {
                ViewBag.CountryList = outcome.AsT0;
                return View();
            }
            return BadRequest(outcome.AsT1);
        }
    }
}
