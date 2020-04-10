namespace CoolVacationT.Web.Controllers
{
    using System;
    using System.Threading.Tasks;

    using CoolVacationT.Services.Data;
    using CoolVacationT.Web.ViewModels.Period.InputModel;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class PeriodsController : BaseController
    {
        private readonly IPeriodService periodService;

        public PeriodsController(IPeriodService periodService)
        {
            this.periodService = periodService;
        }

        [Authorize]
        public IActionResult Add()
        {
            return this.View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Add(CreatePeriodInputModel inputModel)
        {
            DateTime dateNow = DateTime.UtcNow;
            if ((!this.ModelState.IsValid)
                || inputModel.ArrivalDate < dateNow
                || inputModel.DepartDate < dateNow
                || inputModel.ArrivalDate == inputModel.DepartDate)
            {
                return this.View(inputModel);
            }

            await this.periodService.AddAsync(inputModel.ArrivalDate, inputModel.DepartDate);

            return this.Redirect("/Payments/Add");
        }
    }
}
