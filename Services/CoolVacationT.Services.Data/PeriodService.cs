﻿namespace CoolVacationT.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using CoolVacationT.Data.Common.Repositories;
    using CoolVacationT.Data.Models;

    public class PeriodService : IPeriodService
    {
        private readonly IDeletableEntityRepository<Period> periodRepository;

        public PeriodService(IDeletableEntityRepository<Period> periodRepository)
        {
            this.periodRepository = periodRepository;
        }

        public async Task<int> AddAsync(DateTime arrivalDate, DateTime departureDate)
        {
            var period = new Period
            {
                ArrivalDate = arrivalDate,
                DepartDate = departureDate,
            };

            await this.periodRepository.AddAsync(period);
            await this.periodRepository.SaveChangesAsync();
            return period.Id;
        }

        public async Task<IList<Period>> TakeBusyDay()
        {
            IList<Period> listPeriod = new List<Period>();

            listPeriod = this.periodRepository.All()
                .OrderByDescending(d => d.ArrivalDate)
                .ToList();

            return listPeriod;
        }
    }
}
