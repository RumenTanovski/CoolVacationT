namespace CoolVacationT.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using CoolVacationT.Data.Models;
    using CoolVacationT.Web.ViewModels.Reservations.ViewModel;

    public interface IReservationService
    {
        Task<int> AddAsync(string id, int noOfPeople);

        IEnumerable<ReservationViewModel> GetUserReservations(string id);
    }
}
