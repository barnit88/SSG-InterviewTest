using FluentValidation;

namespace SSG.Application.Features.Candidate.Command
{
    public class CreateOrUpdateCandidateCommandValidator : AbstractValidator<CreateOrUpdateCandidateCommand>
    {
        public CreateOrUpdateCandidateCommandValidator()
        {
            RuleFor(x => x.FirstName).MaximumLength(500).NotEmpty().WithMessage("Invalid First Name");
            RuleFor(x => x.LastName).MaximumLength(500).NotEmpty().WithMessage("Invalid Last Name");
            RuleFor(x => x.PhoneNumber).MaximumLength(15).WithMessage("Invalid Phone Number");
            RuleFor(x => x.Email).MaximumLength(500)
                .NotEmpty()
                .EmailAddress()
                .WithMessage("Invalid Email");
            RuleFor(x => x.CallTimeInterval).MaximumLength(500).WithMessage("Invalid Call Time Interval");
            RuleFor(x => x.LinkedInProfileUrl).MaximumLength(500).WithMessage("Invalid LinkedIn Profile Url");
            RuleFor(x => x.GitHubProfileUrl).MaximumLength(500).WithMessage("Invalid Github Profile Url");
            RuleFor(x => x.Comment).NotEmpty().WithMessage("Invalid Comment");
        }
    }
}