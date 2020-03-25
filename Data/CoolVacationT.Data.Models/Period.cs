namespace CoolVacationT.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using CoolVacationT.Data.Common.Models;

    public class Period : BaseDeletableModel<int>
    {
        public DateTime ArrivalDate { get; set; }

        public DateTime DepartDate { get; set; }

        public int ReservationId { get; set; }

        public virtual Reservation Reservation { get; set; }
    }
}
