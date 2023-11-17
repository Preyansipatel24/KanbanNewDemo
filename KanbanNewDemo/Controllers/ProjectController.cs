using KanbanNewDemo.Contxet;
using KanbanNewDemo.DTOs.Projects;
using KanbanNewDemo.Hubs;
using KanbanNewDemo.Models.Project;
using KanbanNewDemo.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace KanbanNewDemo.Controllers
{
    [Authorize]
    public class ProjectController : Controller
    {
        private readonly IHubContext<ChatHub> _hubContext;
        IProjectService _projectService;
        IUserService _userService;
        KanbanContext _context;
        public ProjectController(IProjectService projectService, IUserService userService, KanbanContext context, IHubContext<ChatHub> hubContext)
        {
            _projectService = projectService;
            _userService = userService;
            _context = context;
            _hubContext = hubContext;
        }

        [Route("/Project/Kanban/{id}")]
        public IActionResult Kanban(int id)
        {
            ViewData["TodoCarts"] = _projectService.GetTodoCartByProjectId(id);
            ViewData["InProcessCarts"] = _projectService.GetInProcessByProjectId(id);
            ViewData["DoneCarts"] = _projectService.GetDoneCartByProjectId(id);
            return View(_projectService.GetProjectById(id));
        }

        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(AddProjectViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            Project project = new Project()
            {
                Title = model.Title,
                Description = model.Description,
                CreateDate = System.DateTime.Now,
                UserId = _userService.GetUserIdByEmail(User.Identity.Name),
                IsDelete = false
            };

            _projectService.AddProject(project);

            return Redirect("/Home/Index");
        }

        public IActionResult AddCart(int id)
        {
            ViewBag.ProjectId = id;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCart(AddCartViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            Cart cart = new Cart()
            {
                Name = model.Name,
                ProjectId = model.ProjectId,
                IsDelete = false,
                StatusNumber = 1
            };

            _projectService.AddCart(cart);
            List<Cart> cartList = new List<Cart>();
            cartList.Add(cart);
            await _hubContext.Clients.All.SendAsync("ReceiveMessage", "Cart added", cartList);
            // return View();
            return Redirect($"/Project/Kanban/{model.ProjectId}");
        }

        public IActionResult GoToNextLevel(int id)
        {
            var cart = _projectService.GetCartById(id);
            if (cart != null)
            {
                //if (cart.StatusNumber == 3)
                //{
                //    cart.StatusNumber = 2;
                //}
                if (cart.StatusNumber == 2)
                {
                    cart.StatusNumber = 3;
                }
                else if (cart.StatusNumber == 1)
                {
                    cart.StatusNumber = 2;
                }

                _projectService.UpdateCart(cart);
            }
            return Redirect($"/Project/Kanban/{cart.ProjectId}");
        }

        public async Task<IActionResult> DeleteCartAsync(int id)
        {
            var cart = _projectService.GetCartById(id);
            cart.IsDelete = true;
            _projectService.UpdateCart(cart);
            List<Cart> cartList = _context.Carts.Where(x => x.IsDelete == false && x.ProjectId == cart.ProjectId).ToList();
            await _hubContext.Clients.All.SendAsync("DragandDropReceive", "Cart DragandDrop", cartList);

            return Redirect($"/Project/Kanban/{cart.ProjectId}");
        }

        public async Task<IActionResult> DeleteProjectAsync(int id)
        {
            var project = _projectService.GetProjectById(id);
            project.IsDelete = true;
            _projectService.UpdateProject(project);
            return Redirect("/");
        }

        public IActionResult EditProject(int id)
        {
            var project = _projectService.GetProjectById(id);
            return View(project);
        }

        [HttpPost]
        public IActionResult EditProject(Project model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            _projectService.UpdateProject(model);
            return Redirect("~/Home/Index");
        }

        public IActionResult EditCart(int id)
        {
            var cart = _projectService.GetCartById(id);
            return View(cart);
        }
        [HttpPost]
        public async Task<IActionResult> EditCartAsync(Cart cart)
        {
            //cart.StatusNumber = 1;
            _projectService.UpdateCart(cart);
            List<Cart> cartList = new List<Cart>();
            cartList.Add(cart);
            await _hubContext.Clients.All.SendAsync("ReceiveMessage", "Cart added", cartList);
            return Redirect($"/Project/Kanban/{cart.ProjectId}");
        }
        [HttpPost]
        public async Task<IActionResult> DragandDropAsync(int id, int statusId, int projectId)
        {

            var cart = _projectService.GetCartById(id);
            if (statusId > 0)
            {
                if (cart != null)
                {
                    ////if (cart.StatusNumber == 3)
                    ////{
                    ////    cart.StatusNumber = 2;
                    ////}
                    //if (cart.StatusNumber == 2)
                    //{
                    //    cart.StatusNumber = 3;
                    //}
                    //else if (cart.StatusNumber == 1)
                    //{
                    //    cart.StatusNumber = 2;
                    //}
                    cart.StatusNumber = statusId;
                    _projectService.UpdateCart(cart);
                    projectId = cart.ProjectId;
                }
                List<Cart> cartList = _context.Carts.Where(x => x.IsDelete == false && x.ProjectId == projectId).ToList();
                await _hubContext.Clients.All.SendAsync("DragandDropReceive", "Cart DragandDrop", cartList);
            }
            return Redirect($"/Project/Kanban/{projectId}");

        }
    }
}
