using ApplyBuddy.Application.Features.JobApplications.Queries.GetJobApplicationList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApplyBuddy.Api.Controllers;

[Route("api/application")]
[ApiController]
public class JobApplicationController : ControllerBase
{
    private readonly IMediator _mediator;

    public JobApplicationController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("all", Name = "GetAllApplications")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<JobApplicationListVm>>> GetAllJobApplications()
    {
        var viewModels = await _mediator.Send(new GetJobApplicationListQuery());
        return Ok(viewModels);
    }


}
