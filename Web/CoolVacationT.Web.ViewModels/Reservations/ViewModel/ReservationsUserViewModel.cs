namespace CoolVacationT.Web.ViewModels.Reservations.ViewModel
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ReservationsUserViewModel
    {
        public ReservationsUserViewModel(IEnumerable<ReservationViewModel> lists)
        {
            this.Reservations = lists;
        }

        public IEnumerable<ReservationViewModel> Reservations { get; set; }
    }
}
