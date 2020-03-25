namespace CoolVacationT.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using CoolVacationT.Data.Common.Models;

    public class FeedBack : BaseDeletableModel<string>
    {
        public int Rating { get; set; }

        public string Comment { get; set; }

        public string ApplicationUserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
