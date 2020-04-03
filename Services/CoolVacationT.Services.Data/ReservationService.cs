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
        private readonly IDeletableEntityRepository<Period> periodRepository;
        private readonly IDeletableEntityRepository<Reservation> reservationRepository;

        public ReservationService(
            IDeletableEntityRepository<Period> periodRepository,
            IDeletableEntityRepository<Reservation> reservationRepository)
        {
            this.periodRepository = periodRepository;
            this.reservationRepository = reservationRepository;
        }

        public async Task<int> AddAsync(string id, int noOfPeople)//, Payment payment, RelaxProgram relaxProgram)
        {
            IEnumerable<Period> periods = this.periodRepository
                .All()
                .ToList();

            Period period = periods.OrderByDescending(x => x.Id).FirstOrDefault();
            var reservation = new Reservation
            {
                NoOfPeople = noOfPeople,
                
                //PeriodId = period.Id,
              //Payment = payment,
              //RelaxProgram = relaxProgram,
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
