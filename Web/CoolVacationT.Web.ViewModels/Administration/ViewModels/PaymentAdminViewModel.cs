namespace CoolVacationT.Web.ViewModels.Administartion.ViewModels
{
    using System;

    using CoolVacationT.Data.Models;
    using CoolVacationT.Services.Mapping;

    public class PaymentAdminViewModel : IMapFrom<FeedBack>
    {
        public int Id { get; set; }

        public decimal? AmountPaid { get; set; }

        public string DocumentNumber { get; set; }

        public string StringFileCloud { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
