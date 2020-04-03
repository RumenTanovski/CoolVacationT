namespace CoolVacationT.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public interface IPeriodService
    {
        Task<int> AddAsync(DateTime arrivalDate, DateTime departureDate);

        //IEnumerable<FeedBackViewModel> GetFeedBacks(string id);
    }
}
