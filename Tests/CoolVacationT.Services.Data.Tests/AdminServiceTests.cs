namespace CoolVacationT.Services.Data.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using CoolVacationT.Data;
    using CoolVacationT.Data.Common.Repositories;
    using CoolVacationT.Data.Models;
    using CoolVacationT.Data.Repositories;
    using Microsoft.EntityFrameworkCore;
    using Moq;
    using Xunit;

    public class AdminServiceTests
    {
        public List<FeedBack> GetTestFeedBacksProfile()
        {
            return new List<FeedBack>
            {
                new FeedBack
                {
                    Rating = 1,
                    Comment = "Slaba rakia ste.",
                    ApplicationUserId = "Pesho",
                },
                new FeedBack
                {
                    Rating = 5,
                    Comment = "Gore-dolu stawate.",
                    ApplicationUserId = "Pesho",
                },
                new FeedBack
                {
                    Rating = 10,
                    Comment = "Super ste.",
                    ApplicationUserId = "Stamat",
                },
            };
        }

        [Fact]
        public void GetAllFeedBacksCorrectNumber()
        {
            EfDeletableEntityRepository<RelaxProgram> repoRelaxProgram;
            EfDeletableEntityRepository<Payment> repoPayment;
            EfDeletableEntityRepository<Period> repoPeriod;
            EfDeletableEntityRepository<Reservation> repoReservation;
            EfDeletableEntityRepository<ApplicationUser> repoUser;
            Mock<IDeletableEntityRepository<FeedBack>> repoFeedBack;
            this.MakeRepositoris(out repoRelaxProgram, out repoPayment, out repoPeriod, out repoReservation, out repoUser, out repoFeedBack);

            var service = new AdminService(repoRelaxProgram, repoPeriod, repoReservation, repoPayment, repoFeedBack.Object, repoUser);
            var list = service.GetAllFeedBacks().ToList();

            Assert.Equal(3, list.Count());
        }

        [Fact]
        public void GetAllPaymentsCorectly()
        {
            EfDeletableEntityRepository<RelaxProgram> repoRelaxProgram;
            EfDeletableEntityRepository<Payment> repoPayment;
            EfDeletableEntityRepository<Period> repoPeriod;
            EfDeletableEntityRepository<Reservation> repoReservation;
            EfDeletableEntityRepository<ApplicationUser> repoUser;
            Mock<IDeletableEntityRepository<FeedBack>> repoFeedBack;
            this.MakeRepositoris(out repoRelaxProgram, out repoPayment, out repoPeriod, out repoReservation, out repoUser, out repoFeedBack);

            var service = new AdminService(repoRelaxProgram, repoPeriod, repoReservation, repoPayment, repoFeedBack.Object, repoUser);

            var list = service.GetAllPayments().ToList();

            Assert.Empty(list);
        }

        [Fact]
        public void GetAllReservationCorectly()
        {
            EfDeletableEntityRepository<RelaxProgram> repoRelaxProgram;
            EfDeletableEntityRepository<Payment> repoPayment;
            EfDeletableEntityRepository<Period> repoPeriod;
            EfDeletableEntityRepository<Reservation> repoReservation;
            EfDeletableEntityRepository<ApplicationUser> repoUser;
            Mock<IDeletableEntityRepository<FeedBack>> repoFeedBack;
            this.MakeRepositoris(out repoRelaxProgram, out repoPayment, out repoPeriod, out repoReservation, out repoUser, out repoFeedBack);

            var service = new AdminService(repoRelaxProgram, repoPeriod, repoReservation, repoPayment, repoFeedBack.Object, repoUser);

            var list = service.GetAllReservations().ToList();

            Assert.Empty(list);
        }

        private void MakeRepositoris(out EfDeletableEntityRepository<RelaxProgram> repoRelaxProgram, out EfDeletableEntityRepository<Payment> repoPayment, out EfDeletableEntityRepository<Period> repoPeriod, out EfDeletableEntityRepository<Reservation> repoReservation, out EfDeletableEntityRepository<ApplicationUser> repoUser, out Mock<IDeletableEntityRepository<FeedBack>> repoFeedBack)
        {
            var dbContext = new DbContextOptionsBuilder<ApplicationDbContext>()
                            .UseInMemoryDatabase(Guid.NewGuid().ToString());

            repoRelaxProgram = new EfDeletableEntityRepository<RelaxProgram>(new ApplicationDbContext(dbContext.Options));
            repoRelaxProgram.SaveChangesAsync().GetAwaiter().GetResult();

            repoPayment = new EfDeletableEntityRepository<Payment>(new ApplicationDbContext(dbContext.Options));
            repoPayment.SaveChangesAsync().GetAwaiter().GetResult();

            repoPeriod = new EfDeletableEntityRepository<Period>(new ApplicationDbContext(dbContext.Options));
            repoPeriod.SaveChangesAsync().GetAwaiter().GetResult();

            repoReservation = new EfDeletableEntityRepository<Reservation>(new ApplicationDbContext(dbContext.Options));
            repoReservation.SaveChangesAsync().GetAwaiter().GetResult();

            repoUser = new EfDeletableEntityRepository<ApplicationUser>(new ApplicationDbContext(dbContext.Options));
            repoReservation.SaveChangesAsync().GetAwaiter().GetResult();

            repoFeedBack = new Mock<IDeletableEntityRepository<FeedBack>>();
            repoFeedBack.Setup(f => f.All())
                        .Returns(this.GetTestFeedBacksProfile()
                        .AsQueryable());
        }

    }
}
