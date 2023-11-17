using KanbanNewDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace KanbanNewDemo.Controllers
{
    public class NewKanBanController : Controller
    {
        private static List<Task1> Tasks = new List<Task1>
    {
        new Task1 { Id = 1, Title = "Task 1", Status = "Not Started" },
        new Task1 { Id = 2, Title = "Task 2", Status = "In Progress" },
        new Task1 { Id = 3, Title = "Task 3", Status = "Done" },
    };

        public ActionResult NewKanBanIndex()
        {
            return View(Tasks);
        }

        [HttpPost]
        public ActionResult UpdateStatus(int id, string status)
        {
            var task = Tasks.Find(t => t.Id == id);
            if (task != null)
            {
                task.Status = status;
            }
            return Redirect("/NewKanBan/Index");
        }
    }
}

