namespace CoolVacationT.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CoolVacationT.Services.Data;
    using CoolVacationT.Web.ViewModels.FeedBacks.InputModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class FeedBacksController : BaseController
    {
        private readonly IFeedBackService feedBackService;

        public FeedBacksController(IFeedBackService feedBackService)
        {
            this.feedBackService = feedBackService;
        }

        public IActionResult Add()
        {
            return this.View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Add(CreateFeedBackInputModel inputModel)
        {
            await this.feedBackService.AddAsync(inputModel.Rating, inputModel.Comment);

            return this.Redirect("/");
        }
    }
}
