namespace CoolVacationT.Services.Data
{
    using System.Threading.Tasks;

    public interface IRelaxProgramService
    {
        Task<int> AddAsync(string ecoTrail, string party, string swimmingPool);
    }
}
