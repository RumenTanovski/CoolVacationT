namespace CoolVacationT.Web.ViewModels.Administration.ViewModels
{
    using System.Collections.Generic;

    public class ReservationsAllViewModel
    {
        public ReservationsAllViewModel(IEnumerable<ReservationViewModel> lists)
        {
            this.Reservations = lists;
        }

        public IEnumerable<ReservationViewModel> Reservations { get; set; }
    }
}
