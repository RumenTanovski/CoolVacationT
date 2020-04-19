namespace CoolVacationT.Services.Data.Tests
{
    using System;
    using System.Linq;

    using CoolVacationT.Data;
    using CoolVacationT.Data.Models;
    using CoolVacationT.Data.Repositories;
    using Microsoft.EntityFrameworkCore;
    using Xunit;

    public class RelaxProgramServiceTests
    {
        [Fact]
        public void AddRelaxProgramCorrectly()
        {
            var dbContext = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString());
            var repository = new EfDeletableEntityRepository<RelaxProgram>(new ApplicationDbContext(dbContext.Options));

            repository.SaveChangesAsync().GetAwaiter().GetResult();

            var service = new RelaxProgramService(repository);

            _ = service.AddAsync("Yes", "Yes", "Yes");
            var list = repository.All().ToList();

            Assert.Single(list);
            Assert.Equal("Yes", list[0].EcoTrail);
            Assert.Equal("Yes", list[0].Party);
            Assert.Equal("Yes", list[0].SwimmingPool);
        }
    }
}
