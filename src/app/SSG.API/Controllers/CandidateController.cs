using Microsoft.AspNetCore.Mvc;
using SSG.Application.Common.Models;
using SSG.Application.Features.Candidate.Command;
using SSG.Application.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Controllers
{
    public class CandidateController : BaseApiController
    {
        private const string _swaggerOperationTag = "Candidate";

        [HttpPost("create-or-update")]
        [SwaggerOperation(
        Summary = "Retrieves all command argumens",
        Description = "Retrieves all command arguments",
        OperationId = "commandArgument.GetCommandArgumentListAsync",
        Tags = new[] { _swaggerOperationTag })]
        [SwaggerResponse(StatusCodes.Status200OK, "Returns a list of command arguments", type: typeof(ResponseModel<ReturnMessageModel>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid request")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Application failed to process the request")]
        public async Task<IActionResult> CreateOrUpdateCandidate(CreateOrUpdateCandidateCommand request, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(request, cancellationToken);
            return HandleResult(result);
        }
    }
}
