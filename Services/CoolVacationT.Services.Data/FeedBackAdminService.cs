namespace CoolVacationT.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CoolVacationT.Data.Common.Repositories;
    using CoolVacationT.Data.Models;
    using CoolVacationT.Web.ViewModels.Administartion.ViewModels;

    public class FeedBackAdminService : IFeedBackAdminService
    {
        private readonly IDeletableEntityRepository<FeedBack> feedBackRepository;
        private readonly IDeletableEntityRepository<ApplicationUser> userRepository;

        public FeedBackAdminService(
            IDeletableEntityRepository<FeedBack> feedBackRepository,
            IDeletableEntityRepository<ApplicationUser> userRepository)
        {
            this.feedBackRepository = feedBackRepository;
            this.userRepository = userRepository;
        }

        public IEnumerable<FeedBackAdminViewModel> GetAllFeedBacks()
        {
            IEnumerable<FeedBack> feedBacks = this.feedBackRepository.All()
                .ToList();

            IEnumerable<FeedBackAdminViewModel> allViewModel = feedBacks.Select(f => new FeedBackAdminViewModel
            {
                Id = f.Id,
                CreatedOn = f.CreatedOn,
                Rating = f.Rating,
                Comment = f.Comment,
            })
            .ToList();

            return allViewModel;
        }

        public async Task DeleteAsync(string id)
        {
            FeedBack feedBack = this.feedBackRepository.All().FirstOrDefault(f => f.Id == id);

            this.feedBackRepository.Delete(feedBack);

            await this.feedBackRepository.SaveChangesAsync();
        }
    }
}
