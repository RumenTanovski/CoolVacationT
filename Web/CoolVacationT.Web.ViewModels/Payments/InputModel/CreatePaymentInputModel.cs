namespace CoolVacationT.Web.ViewModels.Payments.InputModel
{
    using CoolVacationT.Data.Models;
    using CoolVacationT.Services.Mapping;

    public class CreatePaymentInputModel : IMapTo<Payment>
    {
        public string AmountPaid { get; set; }

        public string DocumentNumber { get; set; }
    }
}
