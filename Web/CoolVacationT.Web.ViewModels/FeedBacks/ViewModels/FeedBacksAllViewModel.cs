namespace CoolVacationT.Web.ViewModels.FeedBacks.ViewModels
{
    using System.Collections.Generic;

    public class FeedBacksAllViewModel
    {
        public FeedBacksAllViewModel(IEnumerable<FeedBackViewModel> lists)
        {
            this.FeedBacks = lists;
        }

        public IEnumerable<FeedBackViewModel> FeedBacks { get; set; }
    }
}
