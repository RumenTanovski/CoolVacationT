namespace CoolVacationT.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using CoolVacationT.Data.Common.Models;

    public class Payment : BaseDeletableModel<int>
    {
        public Payment()
        {
            this.Reservations = new HashSet<Reservation>();
        }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal AmountPaid { get; set; }

        [Required]
        public string PicPaid { get; set; }

        public decimal AmountOwing { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
