namespace CoolVacationT.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using CoolVacationT.Data.Common.Models;

    public class Payment : BaseDeletableModel<int>
    {
        [Required]
        [Range(0, double.MaxValue)]
        public decimal AmountPaid { get; set; }

        [Required]
        public string PicPaid { get; set; }

        public decimal AmountOwing { get; set; }

        //[Required]
        public string ReservationId { get; set; }

        public virtual Reservation Reservation { get; set; }
    }
}
