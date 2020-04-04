using CoolVacationT.Services.Data;
using CoolVacationT.Web.ViewModels.RelaxPrograms.InputModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoolVacationT.Web.Controllers
{
    public class RelaxProgramsController : BaseController
    {
        private readonly IRelaxProgramService relaxProgramService;

        public RelaxProgramsController(IRelaxProgramService relaxProgramService)
        {
            this.relaxProgramService = relaxProgramService;
        }

        [Authorize]
        public IActionResult Add()
        {
            return this.View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Add(CreateRelaxProgramInputModel inputModel)
        {
            await this.relaxProgramService.AddAsync(inputModel.EcoTrail, inputModel.Party, inputModel.SwimmingPool);

            return this.Redirect("/Reservations/Add");
        }
    }
}
