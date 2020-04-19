namespace CoolVacationT.Services.Data.Tests
{
    using System;
    using System.Linq;

    using CoolVacationT.Data;
    using CoolVacationT.Data.Models;
    using CoolVacationT.Data.Repositories;
    using Microsoft.EntityFrameworkCore;
    using Xunit;

    public class PaymentServiceTests
    {
        [Fact]
        public void AddPaymentThreeArgumentCorrectly()
        {
            var dbContext = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString());
            var repository = new EfDeletableEntityRepository<Payment>(new ApplicationDbContext(dbContext.Options));

            repository.SaveChangesAsync().GetAwaiter().GetResult();

            var service = new PaymentService(repository);

            _ = service.AddAsync(1000, "Plategno 125/15.04.2020", "http://res.cloudinary.com/...");
            var list = repository.All().ToList();

            Assert.Single(list);
            Assert.Equal(1000, list[0].AmountPaid);
            Assert.Equal("Plategno 125/15.04.2020", list[0].DocumentNumber);
            Assert.Equal("http://res.cloudinary.com/...", list[0].StringFileCloud);
        }

        [Fact]
        public void AddPaymentTwoArgumentCorrectly()
        {
            var dbContext = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString());
            var repository = new EfDeletableEntityRepository<Payment>(new ApplicationDbContext(dbContext.Options));

            repository.SaveChangesAsync().GetAwaiter().GetResult();

            var service = new PaymentService(repository);

            _ = service.AddAsync(1000, "Plategno 125/15.04.2020");
            var list = repository.All().ToList();

            Assert.Single(list);
            Assert.Equal(1000, list[0].AmountPaid);
            Assert.Equal("Plategno 125/15.04.2020", list[0].DocumentNumber);
        }
    }
}
