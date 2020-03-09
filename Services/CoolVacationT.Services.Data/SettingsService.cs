namespace CoolVacationT.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using CoolVacationT.Data.Common.Repositories;
    using CoolVacationT.Data.Models;
    using CoolVacationT.Services.Mapping;

    public class SettingsService : ISettingsService
    {
        private readonly IDeletableEntityRepository<Setting> settingsRepository;

        public SettingsService(IDeletableEntityRepository<Setting> settingsRepository)
        {
            this.settingsRepository = settingsRepository;
        }

        public int GetCount()
        {
            return this.settingsRepository.All().Count();
        }

        public IEnumerable<T> GetAll<T>()
        {
            return this.settingsRepository.All().To<T>().ToList();
        }
    }
}
