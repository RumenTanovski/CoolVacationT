namespace CoolVacationT.Web.ViewModels.Payments.InputModel
{
    using System.ComponentModel.DataAnnotations;

    using CoolVacationT.Data.Models;
    using CoolVacationT.Services.Mapping;

    public class CreatePaymentInputModel : IMapTo<Payment>
    {
        [Range(0, 5000.00)]
        public decimal AmountPaid { get; set; }

        [Required]
        public string DocumentNumber { get; set; }
    }
}
