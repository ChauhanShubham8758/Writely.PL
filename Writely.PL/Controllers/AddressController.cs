using Microsoft.AspNetCore.Mvc;
using Writely.BLL.Services.IService.Address;

namespace Writely.PL.Controllers
{
    public class AddressController : WritelyBaseController
    {
        private readonly ICountryService _countryService;

        public AddressController(ICountryService countryService)
        {
            _countryService = countryService;
        }
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken = default)
        {
            var outcome = await _countryService.GetAllCountries(cancellationToken);
            return ApiResult(outcome);
        }
    }
}
