namespace CoolVacationT.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using CoolVacationT.Web.ViewModels.Administartion.ViewModels;

    public interface IFeedBackAdminService
    {
        IEnumerable<FeedBackAdminViewModel> GetAllFeedBacks();

        Task DeleteAsync(string id);
    }
}
