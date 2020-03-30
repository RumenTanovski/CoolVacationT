namespace CoolVacationT.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using CoolVacationT.Data.Models;
    using CoolVacationT.Web.ViewModels.FeedBacks.ViewModels;

    public interface IFeedBackService
    {
        Task<string> AddAsync(int rating, string comment, string id);

        IEnumerable<FeedBackViewModel> GetFeedBacks(string id);
    }
}
