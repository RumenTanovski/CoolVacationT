namespace CoolVacationT.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using CoolVacationT.Data.Common.Models;

    public class FeedBack : BaseDeletableModel<string>
    {
        public int Rating { get; set; }

        public string Comment { get; set; }

        [Required]
        public string ApplicationUserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
