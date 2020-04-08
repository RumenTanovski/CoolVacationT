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
        [Required]
        [Range(1, 14)]
        [Display(Name = "Number of people")]
        public int NoOfPeople { get; set; }

    }
}
