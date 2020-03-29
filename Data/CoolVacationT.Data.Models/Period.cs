namespace CoolVacationT.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using CoolVacationT.Data.Common.Models;

    public class Period : BaseDeletableModel<int>
    {
        [Required]
        public DateTime ArrivalDate { get; set; }

        [Required]
        public DateTime DepartDate { get; set; }

        [Required]
        public int ReservationId { get; set; }

        public virtual Reservation Reservation { get; set; }
    }
}
