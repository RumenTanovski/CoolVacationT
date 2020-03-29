namespace CoolVacationT.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using CoolVacationT.Data.Common.Models;

    public class RelaxProgram : BaseDeletableModel<int>
    {
        public string EcoTrail { get; set; }

        public string Party { get; set; }

        public string SwimmingPool { get; set; }

        [Required]
        public int ReservationId { get; set; }

        public virtual Reservation Reservation { get; set; }
    }
}
