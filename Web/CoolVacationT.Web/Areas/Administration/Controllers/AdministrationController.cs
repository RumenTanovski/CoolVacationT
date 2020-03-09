namespace CoolVacationT.Web.Areas.Administration.Controllers
{
    using CoolVacationT.Common;
    using CoolVacationT.Web.Controllers;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class AdministrationController : BaseController
    {
    }
}
