namespace CoolVacationT.Services.Data
{
    using System.Threading.Tasks;

    public interface IPaymentService
    {
        Task<int> AddAsync(decimal amountPaid, string documentNumber, string stringFileCloud);

        //IEnumerable<FeedBackViewModel> GetFeedBacks(string id);
    }
}
