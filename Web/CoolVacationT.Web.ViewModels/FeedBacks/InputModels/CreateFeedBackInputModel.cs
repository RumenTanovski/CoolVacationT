namespace CoolVacationT.Web.ViewModels.FeedBacks.InputModels
{
    using System.ComponentModel.DataAnnotations;

    using CoolVacationT.Data.Models;
    using CoolVacationT.Services.Mapping;

    public class CreateFeedBackInputModel : IMapTo<FeedBack>
    {
        [Required]
        [Range(1, 10)]
        public int Rating { get; set; }

        [Required]
        [StringLength(250, MinimumLength = 3)]
        public string Comment { get; set; }
    }
}
