namespace CoolVacationT.Web.ViewModels.Administration.InputModels
{
    using System.ComponentModel.DataAnnotations;

    using CoolVacationT.Data.Models;
    using CoolVacationT.Services.Mapping;

    public class CreateIdReservationInputModel : IMapTo<Reservation>
    {
        [Required]
        [Range(0, 100000)]
        public int Id { get; set; }
    }
}
