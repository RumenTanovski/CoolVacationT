namespace CoolVacationT.Web.ViewModels.FeedBacks.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using CoolVacationT.Data.Models;
    using CoolVacationT.Services.Mapping;

    public class FeedBackViewModel : IMapFrom<FeedBack>
    {
        public int Rating { get; set; }

        public string Comment { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
