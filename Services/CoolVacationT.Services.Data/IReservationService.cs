namespace CoolVacationT.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using CoolVacationT.Data.Models;

    public interface IReservationService
    {
        Task<int> AddAsync(string id, int noOfPeople);//, Payment payment, RelaxProgram relaxProgram);

        //IEnumerable<ReservationViewModel> GetFeedBacks(string id);
    }
}
