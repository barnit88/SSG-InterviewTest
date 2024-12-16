using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using SSG.Infrastructure.Data;
using SSG.Application.Common.Interface;

namespace SSG.Application.Tests
{
    public abstract class TestBase
    {
        protected IApplicationDbContext DbContext;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("TestDatabase")
                .Options;

            var context = new ApplicationDbContext(options);

            DbContext = context;
        }

        [TearDown]
        public void TearDown()
        {
            var context = (ApplicationDbContext)DbContext;
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
