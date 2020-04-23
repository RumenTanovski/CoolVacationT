namespace CoolVacationT.Web.ViewModels.Administration.ViewModels
{
    using System.Collections.Generic;

    public class PaymentAdminAllViewModel
    {
        public PaymentAdminAllViewModel(IEnumerable<PaymentAdminViewModel> lists)
        {
            this.Payments = lists;
        }

        public IEnumerable<PaymentAdminViewModel> Payments { get; set; }
    }
}
