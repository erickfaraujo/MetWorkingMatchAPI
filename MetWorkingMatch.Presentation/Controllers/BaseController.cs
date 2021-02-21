using MediatR;
using MetWorkingMatch.Application.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace MetWorkingMatch.Presentation.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        private ISender _mediator;
        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetService<ISender>();


        protected async Task<IActionResult> ResponseBase<T>(BaseResponse<T> response)
        {
            if (response.Errors.data.Count >= 1) return BadRequest(response);
            if (response.Errors.IsForbbiden) return Unauthorized(response);

            return Ok(response);
        }
    }
}
