namespace CoolVacationT.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CoolVacationT.Data.Models;
    using CoolVacationT.Services.Data;
    using CoolVacationT.Web.ViewModels.Period.InputModel;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
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
            var periodId = await this.periodService.AddAsync(inputModel.ArrivalDate, inputModel.DepartDate);
                        
            // To DO correct REDIRECTION

            return this.Redirect("/Reservations/Add");
        }

    }
}