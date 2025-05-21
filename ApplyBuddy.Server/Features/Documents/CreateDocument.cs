using ApplyBuddy.Server.Domain.Documents;
using ApplyBuddy.Server.Domain.JobApplication;
using ApplyBuddy.Server.Features.Common.Contracts;
using ApplyBuddy.Server.Features.Documents.Services;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApplyBuddy.Server.Features.Documents;

[ApiController]
[Route("api/documents")]
public class CreateDocumentController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> Create([FromForm] CreateDocument.CreateDocumentCommand request)
    {
        var result = await mediator.Send(request);

        return result.IsSuccess
            ? Ok("File uploaded successfully.")
            : BadRequest(result.Error);
    }
}

public static class CreateDocument
{
    public class CreateDocumentCommand : IRequest<Result>
    {
        public required IFormFile File { get; init; }
        public required DocumentType Type { get; init; }
    }

    public class CreateDocumentValidator : AbstractValidator<CreateDocumentCommand>
    {
    }

    internal sealed class Handler : IRequestHandler<CreateDocumentCommand, Result>
    {
        private readonly ILogger<Handler> _logger;
        private readonly ICvParser _cvParser;
        private readonly IChatService _chatService;

        public Handler(ILogger<Handler> logger, ICvParser cvParser, IChatService chatService)
        {
            _logger = logger;
            _cvParser = cvParser;
            _chatService = chatService;
        }

        public async Task<Result> Handle(CreateDocumentCommand request, CancellationToken cancellationToken)
        {
            if (request.File.Length is 0 ||
                request.File.Length > 5242880 ||
                request.File.ContentType != "application/pdf")
            {
                return Result.Failure("No file or an invalid file uploaded.");
            }

            try
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), $"{Guid.NewGuid()}.pdf");

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await request.File.CopyToAsync(stream, cancellationToken);
                }

                var documentRecord = new DocumentRecord
                {
                    Id = Guid.NewGuid(),
                    FilePath = path,
                    FileName = request.File.FileName,
                    FileSize = request.File.Length,
                    Type = request.Type
                };

                var cvAsString = _cvParser.Parse(path);
                var testPrompt =
                    "Please analyse the following CV document that has been normalised into a single string " +
                    "and return it as a JSON in the specified schema. Make sure any dates are in the format that can be parsed from JSON to a C# DateTime object. CV as string:" +
                    cvAsString;
                
                var result = await _chatService.TryParseCv(testPrompt, DocumentType.Resume);

                if (result is not null)
                {
                    _logger.LogInformation(result.ToString());;
                }
                else
                {
                    _logger.LogInformation("result is null.");
                }

                // TODO: Add document record to database

                _logger.LogInformation("Document {DocumentId} uploaded successfully", documentRecord.Id);
                _logger.LogInformation("Document {DocumentId} analysis result: {Result}", documentRecord.Id, result);
                return Result.Success();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error uploading document");
                return Result.Failure("Failed to upload document.");
            }
        }

        private string GetJsonSchema()
        {
            return
                "{\n  \"$schema\": \"http://json-schema.org/draft-07/schema#\",\n  \"title\": \"CV\",\n  \"type\": \"object\",\n  \"properties\": {\n    \"Summary\": {\n      \"type\": \"object\",\n      \"description\": \"A brief overview of the person's professional background and career goals.\",\n      \"properties\": {\n        \"Summary\": {\n          \"type\": \"string\",\n          \"description\": \"The summary text.\"\n        }\n      },\n      \"required\": [\"Summary\"]\n    },\n    \"Skills\": {\n      \"type\": \"array\",\n      \"description\": \"A list of professional and technical skills.\",\n      \"items\": {\n        \"type\": \"string\"\n      }\n    },\n    \"Education\": {\n      \"type\": \"array\",\n      \"description\": \"A list of formal education entries.\",\n      \"items\": {\n        \"type\": \"object\",\n        \"properties\": {\n          \"Insitute\": {\n            \"type\": \"string\",\n            \"description\": \"Name of the educational institution.\"\n          },\n          \"StartDate\": {\n            \"type\": [\"string\", \"null\"],\n            \"format\": \"date-time\",\n            \"description\": \"Start date in ISO 8601 format.\"\n          },\n          \"EndDate\": {\n            \"type\": [\"string\", \"null\"],\n            \"format\": \"date-time\",\n            \"description\": \"End date in ISO 8601 format.\"\n          },\n          \"Subjects\": {\n            \"type\": \"array\",\n            \"description\": \"Subjects studied and the grades achieved.\",\n            \"items\": {\n              \"type\": \"object\",\n              \"properties\": {\n                \"Subject\": {\n                  \"type\": \"string\",\n                  \"description\": \"Name of the subject.\"\n                },\n                \"Grade\": {\n                  \"type\": \"string\",\n                  \"description\": \"Grade achieved in the subject.\"\n                }\n              },\n              \"required\": [\"Subject\", \"Grade\"]\n            }\n          }\n        },\n        \"required\": [\"Insitute\", \"Subjects\"]\n      }\n    },\n    \"JobHistory\": {\n      \"type\": \"array\",\n      \"description\": \"A list of previous jobs or roles.\",\n      \"items\": {\n        \"type\": \"object\",\n        \"properties\": {\n          \"Title\": {\n            \"type\": \"string\",\n            \"description\": \"The job title or role name.\"\n          },\n          \"StartDate\": {\n            \"type\": [\"string\", \"null\"],\n            \"format\": \"date-time\",\n            \"description\": \"Job start date in ISO 8601 format.\"\n          },\n          \"EndDate\": {\n            \"type\": [\"string\", \"null\"],\n            \"format\": \"date-time\",\n            \"description\": \"Job end date in ISO 8601 format (null if current).\"\n          },\n          \"Description\": {\n            \"type\": [\"string\", \"null\"],\n            \"description\": \"Summary of job responsibilities and achievements.\"\n          }\n        },\n        \"required\": [\"Title\"]\n      }\n    }\n  },\n  \"additionalProperties\": false\n}";
        }
    }
}