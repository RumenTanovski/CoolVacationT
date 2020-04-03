namespace CoolVacationT.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using CoolVacationT.Data.Common.Models;

    public class RelaxProgram : BaseDeletableModel<int>
    {
        public RelaxProgram()
        {
            this.Reservations = new HashSet<Reservation>();
        }

        public string EcoTrail { get; set; }

        public string Party { get; set; }

        public string SwimmingPool { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
