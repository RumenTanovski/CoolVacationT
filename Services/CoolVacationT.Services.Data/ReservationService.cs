namespace CoolVacationT.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using CoolVacationT.Data.Common.Repositories;
    using CoolVacationT.Data.Models;
    using CoolVacationT.Web.ViewModels.Reservations.ViewModel;

    public class ReservationService : IReservationService
    {
        private readonly IDeletableEntityRepository<Reservation> reservationRepository;

        public ReservationService(
            IDeletableEntityRepository<Reservation> reservationRepository)
        {
            this.reservationRepository = reservationRepository;
        }

        public async Task<int> AddAsync(string id, int noOfPeople, int periodId)//, Payment payment, RelaxProgram relaxProgram)
        {
            var reservation = new Reservation
            {
                NoOfPeople = noOfPeople,
                PeriodId = periodId,
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
