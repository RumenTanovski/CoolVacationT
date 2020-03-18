namespace CoolVacationT.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using CoolVacationT.Data.Common.Repositories;
    using CoolVacationT.Data.Models;

    public class FeedBackService : IFeedBackService
    {
        private readonly IDeletableEntityRepository<FeedBack> feedBackRepository;

        public FeedBackService(IDeletableEntityRepository<FeedBack> feedBackRepository)
        {
            this.feedBackRepository = feedBackRepository;
        }

        public async Task AddAsync(int rating, string comment)
        {
            var feedBack = new FeedBack
            {
                Id = Guid.NewGuid().ToString(),
                Rating = rating,
                Comment = comment,
            };

            await this.feedBackRepository.AddAsync(feedBack);
            await this.feedBackRepository.SaveChangesAsync();
        }
    }
}
