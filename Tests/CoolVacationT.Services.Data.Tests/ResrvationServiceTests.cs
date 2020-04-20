namespace CoolVacationT.Services.Data.Tests
{
    using System;
    using System.Linq;

    using CoolVacationT.Data;
    using CoolVacationT.Data.Models;
    using CoolVacationT.Data.Repositories;
    using Microsoft.EntityFrameworkCore;
    using Xunit;

    public class ResrvationServiceTests
    {
        [Fact]
        public void AddReservationCorrectly()
        {
            var dbContext = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString());

            var repoRelaxProgram = new EfDeletableEntityRepository<RelaxProgram>(new ApplicationDbContext(dbContext.Options));
            repoRelaxProgram.SaveChangesAsync().GetAwaiter().GetResult();

            var repoPayment = new EfDeletableEntityRepository<Payment>(new ApplicationDbContext(dbContext.Options));
            repoPayment.SaveChangesAsync().GetAwaiter().GetResult();

            var repoPeriod = new EfDeletableEntityRepository<Period>(new ApplicationDbContext(dbContext.Options));
            repoPeriod.SaveChangesAsync().GetAwaiter().GetResult();

            var repoReservation = new EfDeletableEntityRepository<Reservation>(new ApplicationDbContext(dbContext.Options));
            repoReservation.SaveChangesAsync().GetAwaiter().GetResult();

            Payment payment = new Payment
            {
                AmountPaid = 1000,
                DocumentNumber = "Plategno 125/15.04.2020",
            };
            repoPayment.AddAsync(payment);
            repoPayment.SaveChangesAsync().GetAwaiter().GetResult();

            RelaxProgram relaxProgram = new RelaxProgram
            {
                EcoTrail = "Yes",
                Party = "Yes",
                SwimmingPool = "Yes",
            };

            repoRelaxProgram.AddAsync(relaxProgram);
            repoRelaxProgram.SaveChangesAsync().GetAwaiter().GetResult();

            Period period = new Period
            {
                ArrivalDate = new DateTime(2020, 5, 1),
                DepartDate = new DateTime(2020, 5, 5),
            };
            repoPeriod.AddAsync(period);
            repoPeriod.SaveChangesAsync().GetAwaiter().GetResult();

            var service = new ReservationService(repoRelaxProgram, repoPayment, repoPeriod, repoReservation);

            _ = service.AddAsync("cb6c61f0-4134-4450-8203-aaee05081d45", 5);
            var list = repoReservation.All().ToList();

            Assert.Single(list);
            Assert.Equal(5, list[0].NoOfPeople);
        }
    }
}
