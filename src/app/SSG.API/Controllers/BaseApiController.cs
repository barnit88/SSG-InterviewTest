using MediatR;
using Microsoft.AspNetCore.Mvc;
using SSG.Application.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        private ISender _mediator;

        /// <summary>
        /// Mediator sender
        /// </summary>
        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetService<ISender>();

        protected ActionResult HandleResult<T>(ResponseModel<T> result)
        {
            if (result == null)
            {
                return NotFound();
            }
            if (result.IsSuccess && result.Value != null)
            {
                return Ok(result.Value);
            }

            if (result.IsSuccess && result.Value == null)
            {
                return NotFound();
            }

            if (!result.IsSuccess && result.ValidationErrors != null)
            {
                return BadRequest(result.ValidationErrors);
            }
            return BadRequest(result.ErrorMessage);
        }
    }
}