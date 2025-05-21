using ApplyBuddy.Server.Domain.Documents;
using ApplyBuddy.Server.Features.Common.Contracts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApplyBuddy.Server.Features.Documents;

[ApiController]
[Route("api/documents")]
public class EvaluateResumeController : ControllerBase
{
    private readonly IChatService _chatService;

    public EvaluateResumeController(IChatService chatService)
    {
        _chatService = chatService;
    }
    
    /// <summary>
    /// Evaluates the specified resume based on its identifier.
    /// </summary>
    /// <returns>An ActionResult indicating the result of the resume evaluation process.</returns>
    [HttpGet("resumes/{id}/evaluate")]
    public async Task<IActionResult> Evaluate([FromBody] EvaluateResume.Command request)
    {
        var testPrompt =
            "Pretend that I have just submitted a CV and also a job description for you to compare. Please write a pretend evaluation of the suitability of my CV towards a job description. This is for testing purposes.";
        if (string.IsNullOrWhiteSpace(testPrompt))
            return BadRequest("Prompt must not be empty.");

        var result = await _chatService.TryParseCv(testPrompt, DocumentType.Resume);
        return Ok(new { Response = result });
    }
}

public static class EvaluateResume
{
    public class Command : IRequest<string>
    {
        public Guid Id { get; set; }
    }

    internal sealed class Handler : IRequestHandler<Command, string>
    {
        private readonly IMediator _mediator;

        public Handler(IMediator mediator)
        {
            _mediator = mediator;
        }


        public Task<string> Handle(Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}