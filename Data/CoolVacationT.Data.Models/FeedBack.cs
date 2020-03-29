namespace CoolVacationT.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using CoolVacationT.Data.Common.Models;

    public class FeedBack : BaseDeletableModel<string>
    {
        [Required]
        [Range(1, 10)]
        public int Rating { get; set; }

        [Required]
        [StringLength(250, MinimumLength = 3)]
        public string Comment { get; set; }

        [Required]
        public string ApplicationUserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
