using Microsoft.EntityFrameworkCore;
using SSG.Domain.Entities;

namespace SSG.Application.Common.Interface
{
    public interface IApplicationDbContext
    {
        DbSet<Candidate> Candidates { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}