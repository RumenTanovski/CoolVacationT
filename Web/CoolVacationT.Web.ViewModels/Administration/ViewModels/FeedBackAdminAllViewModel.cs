﻿namespace CoolVacationT.Web.ViewModels.Administration.ViewModels
{
    using System.Collections.Generic;

    public class FeedBackAdminAllViewModel
    {
        public FeedBackAdminAllViewModel(IEnumerable<FeedBackAdminViewModel> lists)
        {
            this.FeedBacks = lists;
        }

        public IEnumerable<FeedBackAdminViewModel> FeedBacks { get; set; }
    }
}
