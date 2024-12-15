using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using SSG.Application.Features.Candidate.Command;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace SSG.Application.Common.Models.Swagger
{
    public class CreateOrUpdateCandidateModelFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context) => schema.Example =

            new OpenApiObject
            {
                [System.Text.Json.JsonNamingPolicy.CamelCase.ConvertName(nameof(CreateOrUpdateCandidateCommand.FirstName))] = new OpenApiString("John"),
                [System.Text.Json.JsonNamingPolicy.CamelCase.ConvertName(nameof(CreateOrUpdateCandidateCommand.LastName))] = new OpenApiString("Doe"),
                [System.Text.Json.JsonNamingPolicy.CamelCase.ConvertName(nameof(CreateOrUpdateCandidateCommand.PhoneNumber))] = new OpenApiString("+9779899988899"),
                [System.Text.Json.JsonNamingPolicy.CamelCase.ConvertName(nameof(CreateOrUpdateCandidateCommand.Email))] = new OpenApiString("joh.doe@gmail.com"),
                [System.Text.Json.JsonNamingPolicy.CamelCase.ConvertName(nameof(CreateOrUpdateCandidateCommand.CallTimeInterval))] = new OpenApiString("7:00 PM - 8:00 PM"),
                [System.Text.Json.JsonNamingPolicy.CamelCase.ConvertName(nameof(CreateOrUpdateCandidateCommand.LinkedInProfileUrl))] = new OpenApiString("https://www/linkedin.com/in/john-doe-244v651n6"),
                [System.Text.Json.JsonNamingPolicy.CamelCase.ConvertName(nameof(CreateOrUpdateCandidateCommand.GitHubProfileUrl))] = new OpenApiString("https://www/github.com/johndoe"),
                [System.Text.Json.JsonNamingPolicy.CamelCase.ConvertName(nameof(CreateOrUpdateCandidateCommand.Comment))] = new OpenApiString("Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum."),
            };
    }
}
