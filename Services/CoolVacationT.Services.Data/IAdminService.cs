namespace CoolVacationT.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using CoolVacationT.Web.ViewModels.Administration.ViewModels;

    public interface IAdminService
    {
        IEnumerable<FeedBackAdminViewModel> GetAllFeedBacks();

        Task DeleteAsync(string id);

        IEnumerable<PaymentAdminViewModel> GetAllPayments();

        Task ConfirmAsync(int id);

        IEnumerable<ReservationViewModel> GetAllReservations();
    }
}
