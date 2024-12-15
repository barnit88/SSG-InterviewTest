using MediatR;
using Microsoft.EntityFrameworkCore;
using SSG.Application.Common.Interface;
using SSG.Application.Common.Models;
using SSG.Application.Common.Models.Swagger;
using SSG.Application.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace SSG.Application.Features.Candidate.Command
{
    [SwaggerSchemaFilter(typeof(CreateOrUpdateCandidateModelFilter))]
    public class CreateOrUpdateCandidateCommand : IRequest<ResponseModel<ReturnMessageModel>>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string CallTimeInterval { get; set; }
        public string LinkedInProfileUrl { get; set; }
        public string GitHubProfileUrl { get; set; }
        public string Comment { get; set; }
    }
    public class CreateOrUpdateCandidateCommandHandler : IRequestHandler<CreateOrUpdateCandidateCommand, ResponseModel<ReturnMessageModel>>
    {
        private readonly IApplicationDbContext _dbContext;

        public CreateOrUpdateCandidateCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ResponseModel<ReturnMessageModel>> Handle(CreateOrUpdateCandidateCommand request, CancellationToken cancellationToken)
        {
            ReturnMessageModel returnMessageModel = new ReturnMessageModel();

            var candidate = await _dbContext.Candidates.FirstOrDefaultAsync(p => p.Email == request.Email);
            try
            {
                if (candidate == null)
                {
                    candidate = new SSG.Domain.Entities.Candidate()
                    {
                        Id = candidate?.Id ?? 0,
                        FirstName = request.FirstName,
                        LastName = request.LastName,
                        PhoneNumber = request.PhoneNumber,
                        Email = request.Email,
                        CallTimeInterval = request.CallTimeInterval,
                        GitHubProfileUrl = request.GitHubProfileUrl,
                        LinkedInProfileUrl = request.LinkedInProfileUrl,
                        Comment = request.Comment,
                    };
                    await _dbContext.Candidates.AddAsync(candidate);
                    returnMessageModel.ReturnMessage = ReturnMessageModel.SaveSuccess("Candidate");
                }
                else
                {
                    candidate.FirstName = request.FirstName;
                    candidate.LastName = request.LastName;
                    candidate.PhoneNumber = request.PhoneNumber;
                    candidate.Email = request.Email;
                    candidate.CallTimeInterval = request.CallTimeInterval;
                    candidate.GitHubProfileUrl = request.GitHubProfileUrl;
                    candidate.LinkedInProfileUrl = request.LinkedInProfileUrl;
                    candidate.Comment = request.Comment;
                    _dbContext.Candidates.Update(candidate);
                    returnMessageModel.ReturnMessage = ReturnMessageModel.UpdateSuccess("Candidate");
                }
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                return ResponseModel<ReturnMessageModel>.Error("Failed To Create Or Update Candidate");
            }
         
            return ResponseModel<ReturnMessageModel>.Success(returnMessageModel);
        }
    }
}
