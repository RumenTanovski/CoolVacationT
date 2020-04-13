namespace CoolVacationT.Web.ViewModels.Administration.InputModels
{
    using System.ComponentModel.DataAnnotations;

    using CoolVacationT.Data.Models;
    using CoolVacationT.Services.Mapping;

    public class CreateIdInputModel : IMapTo<FeedBack>
    {
        [Required]
        [StringLength(36)]
        public string Id { get; set; }
    }
}
