using Microsoft.AspNetCore.Mvc;

namespace KanbanNewDemo.Controllers
{
    public class KanbanController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}
