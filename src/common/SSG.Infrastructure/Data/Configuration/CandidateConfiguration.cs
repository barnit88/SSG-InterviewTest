using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SSG.Domain.Entities;

namespace SSG.Infrastructure.Data.Configuration
{
    public class CandidateConfiguration : IEntityTypeConfiguration<Candidate>
    {
        public void Configure(EntityTypeBuilder<Candidate> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.FirstName)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(t => t.LastName)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(t => t.PhoneNumber)
                .HasMaxLength(15);

            builder.Property(u => u.Email)
                    .IsRequired()
                    .HasConversion(
                            v => v.ToLower(),
                            v => v)
                    .HasMaxLength(500);

            builder.HasIndex(t => t.Email).IsUnique();

            builder.Property(t => t.CallTimeInterval)
                            .HasMaxLength(500);

            builder.Property(t => t.LinkedInProfileUrl)
                            .HasMaxLength(500);
            
            builder.Property(t => t.GitHubProfileUrl)
                            .HasMaxLength(500);

            builder.Property(t => t.Comment)
                .IsRequired();

        }
    }
}