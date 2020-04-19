namespace CoolVacationT.Services.Data.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using CoolVacationT.Data;
    using CoolVacationT.Data.Common.Repositories;
    using CoolVacationT.Data.Models;
    using CoolVacationT.Data.Repositories;
    using CoolVacationT.Web.ViewModels.FeedBacks.InputModels;
    using Microsoft.EntityFrameworkCore;
    using Moq;
    using Xunit;

    public class PeriodServiceTests
    {
        [Fact]
        public void AddPeriodCorrectly()
        {
            var dbContext = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString());
            var repository = new EfDeletableEntityRepository<Period>(new ApplicationDbContext(dbContext.Options));

            repository.SaveChangesAsync().GetAwaiter().GetResult();

            var service = new PeriodService(repository);

            _ = service.AddAsync(new DateTime(2020, 5, 1), new DateTime(2020, 5, 5));
            var list = repository.All().ToList();

            Assert.Single(list);
            Assert.Equal(new DateTime(2020, 5, 1), list[0].ArrivalDate);
            Assert.Equal(new DateTime(2020, 5, 5), list[0].DepartDate);
        }
    }
}
