namespace CoolVacationT.Web.ViewModels.FeedBacks.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class FeedBacksUserViewModel
    {
        public FeedBacksUserViewModel(IEnumerable<FeedBackViewModel> lists)
        {
            this.FeedBacks = lists;
        }

        public IEnumerable<FeedBackViewModel> FeedBacks { get; set; }
    }
}
