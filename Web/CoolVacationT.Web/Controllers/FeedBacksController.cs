namespace CoolVacationT.Web.Controllers
{
    using System.Threading.Tasks;

    using CoolVacationT.Data.Models;
    using CoolVacationT.Services.Data;
    using CoolVacationT.Web.ViewModels.FeedBacks.InputModels;
    using CoolVacationT.Web.ViewModels.FeedBacks.ViewModels;
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
            if (!this.ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            var user = await this.userManager.GetUserAsync(this.User);
            await this.feedBackService.AddAsync(user.Id, inputModel.Rating, inputModel.Comment);

            return this.Redirect("/");
        }

        [Authorize]
        public async Task<IActionResult> GetUserFeedBacks()
        {
            var user = await this.userManager.GetUserAsync(this.User);

            var feeds = this.feedBackService.GetFeedBacks(user.Id);
            FeedBacksUserViewModel viewModel = new FeedBacksUserViewModel(feeds);

            return this.View(viewModel);
        }
    }
}
