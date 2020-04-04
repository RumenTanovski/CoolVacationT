namespace CoolVacationT.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public interface IPaymentService
    {
        Task<int> AddAsync(string amountPaid, string documentNumber);

        //IEnumerable<FeedBackViewModel> GetFeedBacks(string id);
    }
}
