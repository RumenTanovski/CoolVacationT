namespace CoolVacationT.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using CoolVacationT.Data.Common.Models;

    public class Reservation : BaseDeletableModel<int>
    {
        [Required]
        [Range(1, 14)]
        public int NoOfPeople { get; set; }

        public bool Confirmed { get; set; }

        [Required]
        public string ApplicationUserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        [Required]
        public int PeriodId { get; set; }

        public virtual Period Period { get; set; }

        [Required]
        public int PaymentId { get; set; }

        public virtual Payment Payment { get; set; }

        [Required]
        public int RelaxProgramId { get; set; }

        public virtual RelaxProgram RelaxProgram { get; set; }
    }
}
