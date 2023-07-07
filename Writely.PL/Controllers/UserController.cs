using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            //return View();
            if (outcome.IsT1)
            {
                ViewBag.ErrorMessage = outcome.AsT1.LoggingDescriptor.ErrorMessage.ToString();
                return BadRequest(outcome.AsT1);
            }
            else
            {
                //Response.Cookies.Append("AuthToken", outcome.AsT0, new CookieOptions
                //{
                //    Expires = DateTime.Now.AddHours(3), // Set the expiration time as needed
                //    HttpOnly = true, // Ensure the cookie is accessible only through HTTP (not JavaScript)
                //    Secure = true, // Set to true if using HTTPS
                //    SameSite = SameSiteMode.Strict // Adjust the SameSite value as per your requirements
                //});
                Response.ContentType = "application/json";
                Response.Headers.Add("Access-Control-Expose-Headers", "Authorization"); // Allow the client to access the Authorization header
                Response.Headers.Add("Authorization", "Bearer Token" + outcome.AsT0);
                //HttpContext.Response.Headers.Add("Authorization", $"Bearer {outcome.AsT0}");
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
