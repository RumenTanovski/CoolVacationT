namespace CoolVacationT.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using CoolVacationT.Web.ViewModels.Administartion.ViewModels;

    public interface IAdminService
    {
        IEnumerable<FeedBackAdminViewModel> GetAllFeedBacks();

        Task DeleteAsync(string id);

        IEnumerable<PaymentAdminViewModel> GetAllPayments();
    }
}
