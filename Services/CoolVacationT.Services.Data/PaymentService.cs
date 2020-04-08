﻿namespace CoolVacationT.Services.Data
{
    using System.Threading.Tasks;

    using CoolVacationT.Data.Common.Repositories;
    using CoolVacationT.Data.Models;

    public class PaymentService : IPaymentService
    {
        private readonly IDeletableEntityRepository<Payment> paymentRepository;

        public PaymentService(IDeletableEntityRepository<Payment> paymentRepository)
        {
            this.paymentRepository = paymentRepository;
        }

        public async Task<int> AddAsync(string amountPaid, string documentNumber)
        {
            var payment = new Payment
            {
                AmountPaid = amountPaid,
                DocumentNumber = documentNumber,
            };

            await this.paymentRepository.AddAsync(payment);
            await this.paymentRepository.SaveChangesAsync();
            return payment.Id;
        }
    }
}