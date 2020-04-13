namespace CoolVacationT.Web.ViewModels.Administartion.ViewModels
{
    using System;

    using CoolVacationT.Data.Models;
    using CoolVacationT.Services.Mapping;

    public class FeedBackAdminViewModel : IMapFrom<FeedBack>
    {
        public string Id { get; set; }

        public int Rating { get; set; }

        public string Comment { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
