namespace CoolVacationT.Data.Models
{
    using System;
    using System.Collections.Generic;
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

        public int NoOfPeople { get; set; }

        public bool Confirmed { get; set; }

        public string ApplicationUserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        public virtual ICollection<Period> Periods { get; set; }

        public virtual ICollection<Payment> Payments { get; set; }

        public virtual ICollection<RelaxProgram> RelaxPrograms { get; set; }

    }
}
