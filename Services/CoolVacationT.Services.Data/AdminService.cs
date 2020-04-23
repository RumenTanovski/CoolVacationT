namespace CoolVacationT.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CoolVacationT.Data.Common.Repositories;
    using CoolVacationT.Data.Models;
    using CoolVacationT.Web.ViewModels.Administration.ViewModels;

    public class AdminService : IAdminService
    {
        private readonly IDeletableEntityRepository<RelaxProgram> relaxProgramRepository;
        private readonly IDeletableEntityRepository<Period> periodRepository;
        private readonly IDeletableEntityRepository<Reservation> reservationRepository;
        private readonly IDeletableEntityRepository<Payment> paymentRepository;
        private readonly IDeletableEntityRepository<FeedBack> feedBackRepository;
        private readonly IDeletableEntityRepository<ApplicationUser> userRepository;

        public AdminService(
            IDeletableEntityRepository<RelaxProgram> relaxProgramRepository,
            IDeletableEntityRepository<Period> periodRepository,
            IDeletableEntityRepository<Reservation> reservationRepository,
            IDeletableEntityRepository<Payment> paymentRepository,
            IDeletableEntityRepository<FeedBack> feedBackRepository,
            IDeletableEntityRepository<ApplicationUser> userRepository)
        {
            this.relaxProgramRepository = relaxProgramRepository;
            this.periodRepository = periodRepository;
            this.reservationRepository = reservationRepository;
            this.paymentRepository = paymentRepository;
            this.feedBackRepository = feedBackRepository;
            this.userRepository = userRepository;
        }

        public IEnumerable<FeedBackAdminViewModel> GetAllFeedBacks()
        {
            IEnumerable<FeedBack> feedBacks = this.feedBackRepository.All()
                .ToList();

            IEnumerable<FeedBackAdminViewModel> allViewModel = feedBacks.Select(f => new FeedBackAdminViewModel
            {
                Id = f.Id,
                CreatedOn = f.CreatedOn,
                Rating = f.Rating,
                Comment = f.Comment,
            })
            .ToList();

            return allViewModel;
        }

        public async Task DeleteAsync(string id)
        {
            FeedBack feedBack = this.feedBackRepository.All().FirstOrDefault(f => f.Id == id);

            this.feedBackRepository.Delete(feedBack);

            await this.feedBackRepository.SaveChangesAsync();
        }

        public IEnumerable<PaymentAdminViewModel> GetAllPayments()
        {
            IEnumerable<Payment> payments = this.paymentRepository.All()
                .ToList();

            IEnumerable<PaymentAdminViewModel> allViewModel = payments.Select(p => new PaymentAdminViewModel
            {
                Id = p.Id,
                AmountPaid = p.AmountPaid,
                DocumentNumber = p.DocumentNumber,
                StringFileCloud = p.StringFileCloud,
                CreatedOn = p.CreatedOn,
            })
            .ToList();

            return allViewModel;
        }

        public async Task ConfirmAsync(int id)
        {
            Reservation reservation = this.reservationRepository.All().FirstOrDefault(f => f.Id == id);

            reservation.Confirmed = true;

            await this.reservationRepository.SaveChangesAsync();
        }

        public IEnumerable<ReservationViewModel> GetAllReservations()
        {
            IEnumerable<Reservation> reservations = this.reservationRepository.All()
                                    .ToList();

            IEnumerable<ReservationViewModel> allViewModel = reservations.Select(f => new ReservationViewModel
            {
                UserName = this.userRepository.All().FirstOrDefault(u => u.Id == f.ApplicationUserId).UserName,
                Id = f.Id,
                CreatedOn = f.CreatedOn,
                Confirmed = f.Confirmed,
                NoOfPeople = f.NoOfPeople,
                ArrivalDate = this.periodRepository.All().FirstOrDefault(p => p.Id == f.PeriodId).ArrivalDate,
                DepartDate = f.Period.DepartDate,
                AmountPaid = this.paymentRepository.All().FirstOrDefault(p => p.Id == f.PaymentId).AmountPaid,
                DocumentNumber = f.Payment.DocumentNumber,
                StringFileCloud = f.Payment.StringFileCloud,
                EcoTrail = this.relaxProgramRepository.All().FirstOrDefault(r => r.Id == f.RelaxProgramId).EcoTrail,
                Party = f.RelaxProgram.Party,
                SwimmingPool = f.RelaxProgram.SwimmingPool,
            })
            .ToList();

            return allViewModel;
        }
    }
}
