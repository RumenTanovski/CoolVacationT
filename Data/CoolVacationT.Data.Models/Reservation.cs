namespace CoolVacationT.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using CoolVacationT.Data.Common.Models;

    public class Reservation : BaseDeletableModel<int>
    {
        public Reservation()
        {
            this.Periods = new HashSet<Period>();
            this.Payments = new HashSet<Payment>();
            this.RelaxPrograms = new HashSet<RelaxProgram>();
        }

        [Required]
        [Range(1, 14)]
        public int NoOfPeople { get; set; }

        public bool Confirmed { get; set; }

        [Required]
        public string ApplicationUserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        public virtual ICollection<Period> Periods { get; set; }

        public virtual ICollection<Payment> Payments { get; set; }

        public virtual ICollection<RelaxProgram> RelaxPrograms { get; set; }

    }
}
