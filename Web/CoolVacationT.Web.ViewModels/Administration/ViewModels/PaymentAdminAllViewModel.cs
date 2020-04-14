namespace CoolVacationT.Web.ViewModels.Administration.ViewModels
{
    using System.Collections.Generic;

    using CoolVacationT.Web.ViewModels.Administartion.ViewModels;

    public class PaymentAdminAllViewModel
    {
        public PaymentAdminAllViewModel(IEnumerable<PaymentAdminViewModel> lists)
        {
            this.Payments = lists;
        }

        public IEnumerable<PaymentAdminViewModel> Payments { get; set; }
    }
}
