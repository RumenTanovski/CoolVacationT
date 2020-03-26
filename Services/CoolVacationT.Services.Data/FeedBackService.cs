namespace CoolVacationT.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using CoolVacationT.Data.Common.Repositories;
    using CoolVacationT.Data.Models;
    using Microsoft.AspNetCore.Identity;

    public class FeedBackService : IFeedBackService
    {
        private readonly IDeletableEntityRepository<FeedBack> feedBackRepository;

        public FeedBackService(
            IDeletableEntityRepository<FeedBack> feedBackRepository)
        {
            this.feedBackRepository = feedBackRepository;
        }

        public async Task<string> AddAsync(int rating, string comment, string id)
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
    }
}
