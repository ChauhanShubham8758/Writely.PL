using OneOf;
using Microsoft.AspNetCore.Mvc;

namespace Writely.PL.Controllers
{
    public class WritelyBaseController : ControllerBase
    {
        public IActionResult ApiResult<TOk, TBadRequest>(OneOf<TOk, TBadRequest> outcome)
        {
            if (outcome.IsT0)
            {
                return Ok(outcome.AsT0);
            }
            return BadRequest(outcome.AsT1);
        }
    }
}
