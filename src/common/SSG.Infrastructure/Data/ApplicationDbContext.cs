using Microsoft.EntityFrameworkCore;
using SSG.Application.Common.Interface;
using SSG.Domain.Entities;
using SSG.Infrastructure.Data.Interceptors;
using System.Reflection;

namespace SSG.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext ,IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.AddInterceptors(new AuditInterceptor());
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        public DbSet<Candidate> Candidates { get; set; }
    }
}