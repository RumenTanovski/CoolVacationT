namespace CoolVacationT.Services.Data
{
    using System.Threading.Tasks;

    using CoolVacationT.Data.Common.Repositories;
    using CoolVacationT.Data.Models;

    public class RelaxProgramService : IRelaxProgramService
    {
        private readonly IDeletableEntityRepository<RelaxProgram> relaxProgramRepository;

        public RelaxProgramService(IDeletableEntityRepository<RelaxProgram> relaxProgramRepository)
        {
            this.relaxProgramRepository = relaxProgramRepository;
        }

        public async Task<int> AddAsync(string ecoTrail, string party, string swimmingPool)
        {
            var relaxProgram = new RelaxProgram
            {
                EcoTrail = ecoTrail,
                Party = party,
                SwimmingPool = swimmingPool,
            };

            await this.relaxProgramRepository.AddAsync(relaxProgram);
            await this.relaxProgramRepository.SaveChangesAsync();
            return relaxProgram.Id;
        }
    }
}
