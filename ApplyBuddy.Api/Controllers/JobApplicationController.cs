using ApplyBuddy.Application.Features.JobApplications.Commands.Create;
using ApplyBuddy.Application.Features.JobApplications.Queries.GetJobApplication;
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

    #region QUERIES

    [HttpGet("all", Name = "GetAllApplications")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<JobApplicationListVm>>> GetAllJobApplications()
    {
        var viewModels = await _mediator.Send(new GetJobApplicationListQuery());
        return Ok(viewModels);
    }

    [HttpGet("{id}", Name = "GetApplicationById")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<JobApplicationDetailVm>> GetApplicationById(Guid id)
    {
        var getApplicationDetailQuery = new GetJobApplicationDetailQuery() { Id = id };
        var application = await _mediator.Send(getApplicationDetailQuery);

        if(application == null)
        {
            return NotFound();
        }

        return Ok(application);
    }

    #endregion

    #region COMMANDS

    [HttpPost(Name = "CreateJobApplication")]
    public async Task<ActionResult<CreateJobApplicationResponse>> Create([FromBody] CreateJobApplicationCommand createJobApplicationCommand)
    {
        var response = await _mediator.Send(createJobApplicationCommand);

        return CreatedAtRoute(
            "GetApplicationById",
            new { id = response.JobApplication.Id},
            response);
    }

    #endregion



}
