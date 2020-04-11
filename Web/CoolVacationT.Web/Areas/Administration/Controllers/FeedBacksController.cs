namespace CoolVacationT.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CoolVacationT.Common;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Area("Administration")]
    [Authorize(Roles= GlobalConstants.AdministratorRoleName)]
    public class FeedBacksController : Controller
    {
        public IActionResult Index()
        {
            return this.View();
        }
    }
}
