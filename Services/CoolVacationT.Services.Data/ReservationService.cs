namespace CoolVacationT.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using CoolVacationT.Data.Common.Repositories;
    using CoolVacationT.Data.Models;
    using CoolVacationT.Web.ViewModels.Reservations.ViewModel;

    public class ReservationService : IReservationService
    {
        private readonly IDeletableEntityRepository<RelaxProgram> relaxProgramRepository;
        private readonly IDeletableEntityRepository<Payment> paymentRepository;
        private readonly IDeletableEntityRepository<Period> periodRepository;
        private readonly IDeletableEntityRepository<Reservation> reservationRepository;

        public ReservationService(
            IDeletableEntityRepository<RelaxProgram> relaxProgramRepository,
            IDeletableEntityRepository<Payment> paymentRepository,
            IDeletableEntityRepository<Period> periodRepository,
            IDeletableEntityRepository<Reservation> reservationRepository)
        {
            this.relaxProgramRepository = relaxProgramRepository;
            this.paymentRepository = paymentRepository;
            this.periodRepository = periodRepository;
            this.reservationRepository = reservationRepository;
        }

        public async Task<int> AddAsync(string id, int noOfPeople)//, Payment payment, RelaxProgram relaxProgram)
        {
            IEnumerable<Period> periods = this.periodRepository
                .All()
                .ToList();
            Period period = periods.OrderByDescending(x => x.Id).FirstOrDefault();

            IEnumerable<Payment> payments = this.paymentRepository
                .All()
                .ToList();
            Payment payment = payments.OrderByDescending(x => x.Id).FirstOrDefault();

            IEnumerable<RelaxProgram> relaxPrograms = this.relaxProgramRepository
                .All()
                .ToList();
            RelaxProgram relaxProgram = relaxPrograms.OrderByDescending(x => x.Id).FirstOrDefault();

            var reservation = new Reservation
            {
                NoOfPeople = noOfPeople,
                PeriodId = period.Id,
                PaymentId = payment.Id,
                RelaxProgramId = relaxProgram.Id,
                ApplicationUserId = id,
            };

            await this.reservationRepository.AddAsync(reservation);
            await this.reservationRepository.SaveChangesAsync();
            return reservation.Id;
        }

        //public IEnumerable<ReservationViewModel> GetFeedBacks(string id)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
