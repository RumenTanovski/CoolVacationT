using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CoolVacationT.Web.Areas.Administration.Controllers
{
    [Area("Administration")]
    public class FeedBacksController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
