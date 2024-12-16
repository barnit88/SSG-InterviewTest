using FluentValidation.TestHelper;
using SSG.Application.Features.Candidate.Command;

namespace SSG.Application.Functional.Test
{

    [TestFixture]
    public class CreateOrUpdateCandidateCommandValidatorTests
    {
        private CreateOrUpdateCandidateCommandValidator _validator;

        [SetUp]
        public void SetUp()
        {
            _validator = new CreateOrUpdateCandidateCommandValidator();
        }

        [Test]
        public void Should_HaveValidationError_When_FirstNameIsEmpty()
        {
            var command = new CreateOrUpdateCandidateCommand { FirstName = "" };
            var result = _validator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(x => x.FirstName)
                  .WithErrorMessage("Invalid First Name");
        }

        [Test]
        public void Should_HaveValidationError_When_FirstNameExceedsMaxLength()
        {
            var command = new CreateOrUpdateCandidateCommand { FirstName = new string('A', 501) };
            var result = _validator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(x => x.FirstName)
                  .WithErrorMessage("The length of 'First Name' must be 500 characters or fewer. You entered 501 characters.");
        }

        [Test]
        public void Should_HaveValidationError_When_LastNameIsEmpty()
        {
            var command = new CreateOrUpdateCandidateCommand { LastName = "" };
            var result = _validator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(x => x.LastName)
                  .WithErrorMessage("Invalid Last Name");
        }

        [Test]
        public void Should_HaveValidationError_When_LastNameExceedsMaxLength()
        {
            var command = new CreateOrUpdateCandidateCommand { LastName = new string('A', 501) };
            var result = _validator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(x => x.LastName)
                  .WithErrorMessage("The length of 'Last Name' must be 500 characters or fewer. You entered 501 characters.");
        }

        [Test]
        public void Should_HaveValidationError_When_EmailIsEmpty()
        {
            var command = new CreateOrUpdateCandidateCommand { Email = "" };
            var result = _validator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(x => x.Email)
                  .WithErrorMessage("Invalid Email");
        }

        [Test]
        public void Should_HaveValidationError_When_EmailIsInvalid()
        {
            var command = new CreateOrUpdateCandidateCommand { Email = "notanemail" };
            var result = _validator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(x => x.Email)
                  .WithErrorMessage("Invalid Email");
        }

        [Test]
        public void Should_HaveValidationError_When_PhoneNumberExceedsMaxLength()
        {
            var command = new CreateOrUpdateCandidateCommand { PhoneNumber = new string('1', 16) };
            var result = _validator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(x => x.PhoneNumber)
                  .WithErrorMessage("Invalid Phone Number");
        }

        [Test]
        public void Should_HaveValidationError_When_CallTimeIntervalExceedsMaxLength()
        {
            var command = new CreateOrUpdateCandidateCommand { CallTimeInterval = new string('A', 501) };
            var result = _validator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(x => x.CallTimeInterval)
                  .WithErrorMessage("Invalid Call Time Interval");
        }

        [Test]
        public void Should_HaveValidationError_When_LinkedInProfileUrlExceedsMaxLength()
        {
            var command = new CreateOrUpdateCandidateCommand { LinkedInProfileUrl = new string('A', 501) };
            var result = _validator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(x => x.LinkedInProfileUrl)
                  .WithErrorMessage("Invalid LinkedIn Profile Url");
        }

        [Test]
        public void Should_HaveValidationError_When_GitHubProfileUrlExceedsMaxLength()
        {
            var command = new CreateOrUpdateCandidateCommand { GitHubProfileUrl = new string('A', 501) };
            var result = _validator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(x => x.GitHubProfileUrl)
                  .WithErrorMessage("Invalid Github Profile Url");
        }

        [Test]
        public void Should_HaveValidationError_When_CommentIsEmpty()
        {
            var command = new CreateOrUpdateCandidateCommand { Comment = "" };
            var result = _validator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(x => x.Comment)
                  .WithErrorMessage("Invalid Comment");
        }
    }
}