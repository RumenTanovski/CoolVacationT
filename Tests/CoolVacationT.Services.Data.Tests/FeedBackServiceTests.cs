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

    public class FeedBackServiceTests
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
            var repository = new Mock<IDeletableEntityRepository<FeedBack>>();
            repository.Setup(f => f.All())
                .Returns(this.GetTestFeedBacksProfile()
                .AsQueryable());

            var service = new FeedBackService(repository.Object);
            var list = service.GetAllFeedBacks().ToList();

            Assert.Equal(3, list.Count());
        }

        [Fact]
        public void GetUserFeedBacksCorrectNumber()
        {
            var repository = new Mock<IDeletableEntityRepository<FeedBack>>();
            repository.Setup(f => f.All())
                .Returns(this.GetTestFeedBacksProfile()
                .AsQueryable());

            var service = new FeedBackService(repository.Object);
            var list = service.GetUserFeedBacks("Pesho").ToList();

            Assert.Equal(2, list.Count());
        }

        // [Fact]
        // public async void AddFeedBacksCorrectlyWithMock()
        // {
        //     var repository = new Mock<IDeletableEntityRepository<FeedBack>>();
        //     repository.Setup(f => f.All())
        //         .Returns(this.GetTestFeedBacksProfile()
        //         .AsQueryable());
        //
        //     var service = new FeedBackService(repository.Object);
        //
        //     _ = await service.AddAsync("Stamat", 10, "Beshe gotino");
        //     var list = service.GetAllFeedBacks().ToList();
        //
        //     Assert.Equal(3, list.Count);
        // }
        [Fact]
        public void AddFeedBacksCorrectly()
        {
            var dbContext = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString());
            var repository = new EfDeletableEntityRepository<FeedBack>(new ApplicationDbContext(dbContext.Options));

            repository.SaveChangesAsync().GetAwaiter().GetResult();

            var service = new FeedBackService(repository);

            _ = service.AddAsync("Stamat", 10, "Beshe gotino");
            var list = service.GetAllFeedBacks().ToList();

            Assert.Single(list);
            Assert.Equal(10, list[0].Rating);
            Assert.Equal("Beshe gotino", list[0].Comment);
        }
    }
}
