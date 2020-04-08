namespace CoolVacationT.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CoolVacationT.Data.Models;
    using CoolVacationT.Services.Data;
    using CoolVacationT.Web.ViewModels.Reservations.InputModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class ReservationsController : BaseController
    {
        private readonly IReservationService reservationService;
        private readonly UserManager<ApplicationUser> userManager;

        public ReservationsController(
            IReservationService reservationService,
            UserManager<ApplicationUser> userManager)
        {
            this.reservationService = reservationService;
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        [Authorize]
        public IActionResult Add()
        {
            return this.View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Add(CreateReservationInputModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            var user = await this.userManager.GetUserAsync(this.User);
            await this.reservationService.AddAsync(user.Id, inputModel.NoOfPeople);

            return this.Redirect("/Reservations/Success");
        }

        public IActionResult Success()
        {
            return this.View();
        }
    }
}
