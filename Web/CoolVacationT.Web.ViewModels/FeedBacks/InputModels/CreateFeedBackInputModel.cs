namespace CoolVacationT.Web.ViewModels.FeedBacks.InputModels
{
    using CoolVacationT.Data.Models;
    using CoolVacationT.Services.Mapping;

    public class CreateFeedBackInputModel : IMapTo<FeedBack>
    {
        public int Rating { get; set; }

        public string Comment { get; set; }
    }
}
