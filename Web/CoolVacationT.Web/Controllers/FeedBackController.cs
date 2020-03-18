namespace CoolVacationT.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CoolVacationT.Services.Data;
    using CoolVacationT.Web.ViewModels.FeedBacks.InputModels;
    using Microsoft.AspNetCore.Mvc;

    public class FeedBackController : BaseController
    {
        private readonly IFeedBackService feedBackService;

        public FeedBackController(IFeedBackService feedBackService)
        {
            this.feedBackService = feedBackService;
        }

        public IActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateFeedBackInputModel inputModel)
        {
            await this.feedBackService.AddAsync(inputModel.Rating, inputModel.Comment);

            return this.Redirect("/");
        }
    }
}
