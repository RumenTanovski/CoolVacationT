namespace CoolVacationT.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using CoolVacationT.Data.Common.Models;

    public class FeedBack : BaseDeletableModel<string>
    {
        public string UserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public int Rating { get; set; }

        public string Comment { get; set; }
    }
}
