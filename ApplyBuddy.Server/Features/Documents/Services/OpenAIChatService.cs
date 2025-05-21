using System.ClientModel;
using System.Text.Json;
using ApplyBuddy.Server.Domain.Documents;
using ApplyBuddy.Server.Features.Common.Contracts;
using ApplyBuddy.Server.Infrastructure.Integrations;
using Microsoft.Extensions.Options;
using OpenAI;
using OpenAI.Chat;

namespace ApplyBuddy.Server.Features.Documents.Services;

public class OpenAIChatService : IChatService
{
    private readonly ChatClient _client;
    private readonly string _model;

    private static readonly string CV_SCHEMA = """
                                               {
                                                 "type": "object",
                                                 "properties": {
                                                   "summary": { "type": "string" },
                                                   "skills": {
                                                     "type": "array",
                                                     "items": { "type": "string" }
                                                   },
                                                   "education": {
                                                     "type": "array",
                                                     "items": {
                                                       "type": "object",
                                                       "properties": {
                                                         "institute": { "type": "string" },
                                                         "grade": { "type": "string" },
                                                         "startDate": { "type": "string" },
                                                         "endDate": { "type": "string" },
                                                         "subjects": {
                                                           "type": "array",
                                                           "items": {
                                                             "type": "string"
                                                           }
                                                         }
                                                       },
                                                       "required": ["institute", "grade", "startDate", "endDate", "subjects"],
                                                       "additionalProperties": false
                                                     }
                                                   },
                                                   "jobHistory": {
                                                     "type": "array",
                                                     "items": {
                                                       "type": "object",
                                                       "properties": {
                                                         "title": { "type": "string" },
                                                         "startDate": { "type": "string" },
                                                         "endDate": { "type": "string" },
                                                         "description": { "type": "string" }
                                                       },
                                                       "required": ["title", "startDate", "endDate", "description"],
                                                       "additionalProperties": false
                                                     }
                                                   },
                                                   "aboutSection": { "type": "string" }
                                                 },
                                                 "required": ["summary", "skills", "education", "jobHistory", "aboutSection"],
                                                 "additionalProperties": false
                                               }
                                               """;

    string PARSE_CV_PROMPT = """
                             Please analyse the following CV document that has been normalised into a single string
                             and return it as a JSON in the specified schema. Make sure any dates are in the format
                             that can be parsed from JSON to a C# DateTime object. CV as string:
                             """;

    public OpenAIChatService(IOptions<OpenAISettings> options)
    {
        var settings = options.Value;

        var openAIOptions = new OpenAIClientOptions
        {
            Endpoint = new Uri(settings.Endpoint)
        };

        _client = new ChatClient(
            settings.Model,
            new ApiKeyCredential(settings.ApiKey),
            openAIOptions
        );

        _model = settings.Model;
    }

    public async Task<CV?> TryParseCv(string cvAsString, DocumentType documentType)
    {
        var messages = new List<ChatMessage>
        {
            new SystemChatMessage(PARSE_CV_PROMPT),
            new UserChatMessage(cvAsString)
        };

        var options = CreateCvParseChatOptions();

        ChatCompletion completion = await _client.CompleteChatAsync(messages, options);

        return JsonSerializer.Deserialize<CV>(completion.Content[0].Text, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        });
    }

    private ChatCompletionOptions CreateCvParseChatOptions()
    {
        return new ChatCompletionOptions
        {
            Temperature = 0.2f,
            TopP = 0.1f,
            ResponseFormat = ChatResponseFormat.CreateJsonSchemaFormat(
                jsonSchemaFormatName: "cv_parsed",
                jsonSchema: BinaryData.FromBytes(System.Text.Encoding.UTF8.GetBytes(CV_SCHEMA)),
                jsonSchemaIsStrict: true
            )
        };
    }
}