namespace CoolVacationT.Web.ViewModels.Reservations.InputModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using CoolVacationT.Data.Models;
    using CoolVacationT.Services.Mapping;

    public class CreateReservationInputModel : IMapTo<Reservation>
    {
        // {
        //     this.Periods = new HashSet<Period>();
        //     this.Payments = new HashSet<Payment>();
        //     this.RelaxPrograms = new HashSet<RelaxProgram>();
        // }

        [Required]
        [Range(1, 14)]
        public int NoOfPeople { get; set; }

        //public bool Confirmed { get; set; }
    }
}
