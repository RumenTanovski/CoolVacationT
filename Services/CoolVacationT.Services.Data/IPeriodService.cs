namespace CoolVacationT.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using CoolVacationT.Data.Models;

    public interface IPeriodService
    {
        Task<int> AddAsync(DateTime arrivalDate, DateTime departureDate);

        Task<IList<Period>> TakeBusyDay();
        //IEnumerable<FeedBackViewModel> GetFeedBacks(string id);
    }
}
