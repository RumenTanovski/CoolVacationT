namespace CoolVacationT.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using CoolVacationT.Data.Models;

    public interface IReservationService
    {
        Task<int> AddAsync(string id, int noOfPeople);

        IEnumerable<Web.ViewModels.Reservations.ViewModel.ReservationViewModel> GetUserReservations(string id);
    }
}
