﻿namespace CoolVacationT.Web.ViewModels.Payments.InputModel
{
    using System.ComponentModel.DataAnnotations;

    using CoolVacationT.Data.Models;
    using CoolVacationT.Services.Mapping;
    using Microsoft.AspNetCore.Http;

    public class CreatePaymentInputModel : IMapTo<Payment>
    {
        [Range(0, 5000.00)]
        public decimal AmountPaid { get; set; }

        [Required]
        [StringLength(100)]
        public string DocumentNumber { get; set; }

        public IFormFile PaymentDocument { get; set; }
    }
}
