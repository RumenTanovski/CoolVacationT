namespace CoolVacationT.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using CoolVacationT.Data.Common.Repositories;
    using CoolVacationT.Data.Models;
    using CoolVacationT.Web.ViewModels.FeedBacks.ViewModels;
    using Microsoft.AspNetCore.Identity;

    public class FeedBackService : IFeedBackService
    {
        private readonly IDeletableEntityRepository<FeedBack> feedBackRepository;

        public FeedBackService(
            IDeletableEntityRepository<FeedBack> feedBackRepository)
        {
            this.feedBackRepository = feedBackRepository;
        }

        public async Task<string> AddAsync(string id, int rating, string comment)
        {
            var feedBack = new FeedBack
            {
                Id = Guid.NewGuid().ToString(),
                Rating = rating,
                Comment = comment,
                ApplicationUserId = id,
            };

            await this.feedBackRepository.AddAsync(feedBack);
            await this.feedBackRepository.SaveChangesAsync();
            return feedBack.Id;
        }

        public IEnumerable<FeedBackViewModel> GetUserFeedBacks(string id)
        {
            IEnumerable<FeedBack> feedBacks = this.feedBackRepository.All()
                .Where(f => f.ApplicationUserId == id)
                .ToList();

            IEnumerable<FeedBackViewModel> usersViewModel = feedBacks.Select(f => new FeedBackViewModel
            {
                CreatedOn = f.CreatedOn,
                Rating = f.Rating,
                Comment = f.Comment,
            })
            .ToList();

            return usersViewModel;
        }

        public IEnumerable<FeedBackViewModel> GetAllFeedBacks()
        {
            IEnumerable<FeedBack> feedBacks = this.feedBackRepository.All()
                .ToList();

            IEnumerable<FeedBackViewModel> allViewModel = feedBacks.Select(f => new FeedBackViewModel
            {
                CreatedOn = f.CreatedOn,
                Rating = f.Rating,
                Comment = f.Comment,
            })
            .ToList();

            return allViewModel;
        }
    }
}
