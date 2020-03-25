namespace CoolVacationT.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using CoolVacationT.Data.Common.Models;

    public class Payment : BaseDeletableModel<int>
    {
        public decimal AmountPaid { get; set; }

        public string PicPaid { get; set; }

        public decimal AmountOwing { get; set; }

        public int ReservationId { get; set; }

        public virtual Reservation Reservation { get; set; }
    }
}
