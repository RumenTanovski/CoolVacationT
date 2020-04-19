namespace CoolVacationT.Services.Data
{
    using System;
    using System.Threading.Tasks;

    public interface IPeriodService
    {
        Task<int> AddAsync(DateTime arrivalDate, DateTime departureDate);
    }
}
