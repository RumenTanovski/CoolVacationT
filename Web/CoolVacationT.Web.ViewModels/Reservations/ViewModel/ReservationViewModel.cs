namespace CoolVacationT.Web.ViewModels.Reservations.ViewModel
{
    using System;

    using CoolVacationT.Data.Models;
    using CoolVacationT.Services.Mapping;

    public class ReservationViewModel : IMapFrom<Reservation>
    {
        public bool Confirmed { get; set; }

        public int NoOfPeople { get; set; }

        public DateTime ArrivalDate { get; set; }

        public DateTime DepartDate { get; set; }

        public decimal? AmountPaid { get; set; }

        public string DocumentNumber { get; set; }

        public string? StringFileCloud { get; set; }

        public string? EcoTrail { get; set; }

        public string? Party { get; set; }

        public string? SwimmingPool { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
