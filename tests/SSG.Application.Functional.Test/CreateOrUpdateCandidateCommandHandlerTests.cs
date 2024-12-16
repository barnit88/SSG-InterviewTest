using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using SSG.Application.Features.Candidate.Command;
using SSG.Application.Tests;
using SSG.Domain.Entities;


namespace SSG.Application.Functional.Test
{

    public class CreateOrUpdateCandidateCommandHandlerTests : TestBase
    {
        private CreateOrUpdateCandidateCommandHandler _handler;

        [SetUp]
        public void Init()
        {
            _handler = new CreateOrUpdateCandidateCommandHandler(DbContext);
        }

        [Test]
        public async Task Handle_ShouldCreateNewCandidate_WhenCandidateDoesNotExist()
        {
            var command = new CreateOrUpdateCandidateCommand
            {
                FirstName = "John",
                LastName = "Doe",
                PhoneNumber = "1234567890",
                Email = "john.doe@test.com",
                CallTimeInterval = "9 AM - 5 PM",
                LinkedInProfileUrl = "https://linkedin.com/in/johndoe",
                GitHubProfileUrl = "https://github.com/johndoe",
                Comment = "A skilled developer"
            };

            var result = await _handler.Handle(command, CancellationToken.None);

            result.Should().NotBeNull();
            result.IsSuccess.Should().BeTrue();
            result.Value.ReturnMessage.Should().Contain("Candidate Saved Successfully");

            var candidate = await DbContext.Candidates.FirstOrDefaultAsync(c => c.Email == command.Email);
            candidate.Should().NotBeNull();
            candidate.Email.Should().Be(command.Email);
        }

        [Test]
        public async Task Handle_ShouldUpdateCandidate_WhenCandidateExists()
        {
            // Arrange
            var existingCandidate = new Candidate
            {
                FirstName = "Jane",
                LastName = "Doe",
                Email = "jane.doe@test.com",
                PhoneNumber = "1234567890",
                CallTimeInterval = "9 AM - 5 PM",
                LinkedInProfileUrl = "https://linkedin.com/in/janedoe",
                GitHubProfileUrl = "https://github.com/janedoe",
                Comment = "An experienced developer"
            };
            await DbContext.Candidates.AddAsync(existingCandidate);
            await DbContext.SaveChangesAsync(CancellationToken.None);

            var command = new CreateOrUpdateCandidateCommand
            {
                FirstName = "Jane Updated",
                LastName = "Doe",
                PhoneNumber = "0987654321",
                Email = "jane.doe@test.com",
                CallTimeInterval = "10 AM - 6 PM",
                LinkedInProfileUrl = "https://linkedin.com/in/janeupdated",
                GitHubProfileUrl = "https://github.com/janeupdated",
                Comment = "Updated details"
            };

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);


            // Assert
            result.Should().NotBeNull();
            result.IsSuccess.Should().BeTrue();
            result.Value.ReturnMessage.Should().Contain("Candidate Updated Successfully");

            var candidate = await DbContext.Candidates.FirstOrDefaultAsync(c => c.Email == command.Email);
            candidate.Should().NotBeNull();
            candidate.FirstName.Should().Be(command.FirstName);
            candidate.PhoneNumber.Should().Be(command.PhoneNumber);
        }
    }
}
