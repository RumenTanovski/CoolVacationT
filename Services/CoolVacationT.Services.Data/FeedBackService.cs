﻿namespace CoolVacationT.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using AutoMapper;
    using CoolVacationT.Data.Common.Repositories;
    using CoolVacationT.Data.Models;
    using CoolVacationT.Web.ViewModels.FeedBacks.ViewModels;
    using Microsoft.AspNetCore.Identity;

    public class FeedBackService : IFeedBackService
    {
        private readonly IDeletableEntityRepository<FeedBack> feedBackRepository;

        public FeedBackService(
            IDeletableEntityRepository<FeedBack> feedBackRepository)
        {
            this.feedBackRepository = feedBackRepository;
        }

        public async Task<string> AddAsync(int rating, string comment, string id)
        {
            var feedBack = new FeedBack
            {
                Id = Guid.NewGuid().ToString(),
                Rating = rating,
                Comment = comment,
                ApplicationUserId = id,
            };

            await this.feedBackRepository.AddAsync(feedBack);
            await this.feedBackRepository.SaveChangesAsync();
            return feedBack.Id;
        }

        public IEnumerable<FeedBackViewModel> GetFeedBacks(string id)
        {
            IEnumerable<FeedBack> feedBacks = this.feedBackRepository.All()
                .Where(f => f.ApplicationUserId == id)
                .ToList();

            IEnumerable<FeedBackViewModel> usersViewModel = feedBacks.Select(f => new FeedBackViewModel
            {
                Rating = f.Rating,
                Comment = f.Comment,
            })
            .ToList();

            return usersViewModel;
        }
    }
}
