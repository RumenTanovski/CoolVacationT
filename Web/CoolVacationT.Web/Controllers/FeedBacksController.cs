namespace CoolVacationT.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using CoolVacationT.Data.Models;
    using CoolVacationT.Services.Data;
    using CoolVacationT.Web.ViewModels.FeedBacks.InputModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class FeedBacksController : BaseController
    {
        private readonly IFeedBackService feedBackService;
        private readonly UserManager<ApplicationUser> userManager;

        public FeedBacksController(
            IFeedBackService feedBackService,
            UserManager<ApplicationUser> userManager)
        {
            this.feedBackService = feedBackService;
            this.userManager = userManager;
        }

        [Authorize]
        public IActionResult Add()
        {
            return this.View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Add(CreateFeedBackInputModel inputModel)
        {
            var user = await this.userManager.GetUserAsync(this.User);
            await this.feedBackService.AddAsync(inputModel.Rating, inputModel.Comment, user.Id);

            return this.Redirect("/");
        }
    }
}
