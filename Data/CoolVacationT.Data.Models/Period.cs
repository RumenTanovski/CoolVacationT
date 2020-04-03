namespace CoolVacationT.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using CoolVacationT.Data.Common.Models;

    public class Period : BaseDeletableModel<int>
    {
        public Period()
        {
            this.Reservations = new HashSet<Reservation>();
        }

        [Required]
        public DateTime ArrivalDate { get; set; }

        [Required]
        public DateTime DepartDate { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
