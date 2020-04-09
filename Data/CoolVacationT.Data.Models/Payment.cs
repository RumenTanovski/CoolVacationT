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

        [Range(0, 5000.00)]
        public decimal? AmountPaid { get; set; }

        [Required]
        [MaxLength(100)]
        public string DocumentNumber { get; set; }

        [MaxLength(100)]
        public string? StringFileCloud { get; set; }

        public decimal? AmountOwing { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
