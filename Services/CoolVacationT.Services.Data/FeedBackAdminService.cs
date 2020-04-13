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

        public FeedBackAdminService(
            IDeletableEntityRepository<FeedBack> feedBackRepository)
        {
            this.feedBackRepository = feedBackRepository;
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

        public Task<string> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}
