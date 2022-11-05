using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ParkMap.Controllers
{
    public class RolesController : Controller
    {
        [Authorize(Policy = "RequireAdministratorRole")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
