using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net.Http.Headers;
using Writely.BLL.ServiceModels.RequestModels.Users;
using Writely.BLL.Services.IService.Address;
using Writely.BLL.Services.IService.Users;
using Writely.DAL.Models.Users.Domain;

namespace Writely.PL.Controllers
{
    public class UserController : Controller
    {
        private readonly ICountryService _countryService;
        private readonly IUserService _userService;

        public UserController(ICountryService countryService, IUserService userService)
        {
            _countryService = countryService;
            _userService = userService;
        }
        public IActionResult LoginUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoginUser(UserLoginModel userDisplay, CancellationToken cancellationToken = default)
        {
            var outcome = await _userService.Login(userDisplay, cancellationToken);
            if (outcome.IsT1)
            {
                ViewBag.ErrorMessage = outcome.AsT1.LoggingDescriptor.ErrorMessage.ToString();
                return BadRequest(outcome.AsT1);
            }
            else
            {
                var clientHandler = new HttpClientHandler();
                var client = new HttpClient(clientHandler);
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", outcome.AsT0);
                TempData["name"] = outcome.AsT0;
                return Ok( new { outcome.AsT0 });
            }
        }

        [HttpGet]
        public async Task<IActionResult> RegisterUser()
        {
            var genderValues = Enum.GetValues(typeof(Gender)).Cast<Gender>();
            var genderListItems = genderValues.Select(x => new SelectListItem
            {
                Text = x.ToString(),
                Value = x.ToString()
            }).ToList();

            ViewData["Gender"] = genderListItems;

            var outcome = await _countryService.GetAllCountries();
            if (outcome.IsT0)
            {
                ViewBag.CountryList = outcome.AsT0;
                return View();
            }
            return BadRequest(outcome.AsT1);
        }

        [HttpPost]
        public async Task<IActionResult>  RegisterUser(AddUserModel user, CancellationToken cancellationToken)
        {
            var outcome = await _userService.CreateUser(user, cancellationToken);
            if(outcome.IsT1)
            {
                ViewBag.ErrorMessage = outcome.AsT1.LoggingDescriptor.ErrorMessage.ToString();
                return BadRequest(outcome.AsT1);
            }
            else
            {
                return RedirectToAction("Login","Home");
            }
        }
    }
}
