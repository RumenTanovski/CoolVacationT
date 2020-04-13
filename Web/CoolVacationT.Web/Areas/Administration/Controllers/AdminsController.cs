﻿namespace CoolVacationT.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CoolVacationT.Common;
    using CoolVacationT.Data.Models;
    using CoolVacationT.Services.Data;
    using CoolVacationT.Web.ViewModels.Administartion.ViewModels;
    using CoolVacationT.Web.ViewModels.Administration.InputModels;
    using CoolVacationT.Web.ViewModels.Administration.ViewModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    [Area("Administration")]
    [Route("administration")]
    [Authorize(Roles= GlobalConstants.AdministratorRoleName)]
    public class AdminsController : Controller
    {
        private readonly IFeedBackAdminService feedBackService;
        private readonly UserManager<ApplicationUser> userManager;

        public AdminsController(
            IFeedBackAdminService feedBackService,
            UserManager<ApplicationUser> userManager)
        {
            this.feedBackService = feedBackService;
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        [Route("[action]")]
        public IActionResult GetAllFeedBacks()
        {
            var feeds = this.feedBackService.GetAllFeedBacks();
            FeedBackAdminAllViewModel viewModel = new FeedBackAdminAllViewModel(feeds);

            return this.View(viewModel);
        }

        [Route("[action]")]
        public IActionResult DeleteFeedBack()
        {
            return this.View();
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> DeleteFeedBack(CreateIdInputModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            await this.feedBackService.DeleteAsync(inputModel.Id);

            return this.Redirect("/Administration/Success");
        }

        [Route("[action]")]
        public IActionResult Success()
        {
            return this.View();
        }
    }
}
