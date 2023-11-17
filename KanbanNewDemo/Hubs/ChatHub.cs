using Microsoft.AspNetCore.SignalR;

namespace KanbanNewDemo.Hubs

{
    public class ChatHub : Hub
    {

        //public async Task SendMessage(string user, string message)
        //{
        //    await Clients.All.SendAsync("ReceiveMessage", user, message);
        //}
        //public async Task SendMessage(string task, string ProjectId)
        //{
        //    var redirectUrl = "/Project/Kanban/" + ProjectId;
        //    await Clients.All.SendAsync("ReceiveMessage", task, redirectUrl);
        //}

        //public async Task AddCart(string user)
        //{
        //    await Clients.All.SendAsync("ReceiveToDoId", user);
        //}





        //public async Task SendMessage(string user, string ProjectId)
        //{
        //    Kanban(int.Parse(ProjectId));

        //    await Clients.All.SendAsync("ReceiveMessage", user, ProjectId);
        //}
        //public IActionResult Kanban(int id)
        //{
        //    return Redirect($"/Project/Kanban/{id}");
        //}




        //private readonly IUrlHelper _urlHelper;

        //public ChatHub(IUrlHelper urlHelper)
        //{
        //    _urlHelper = urlHelper;
        //}

        //public async Task SendMessage(string user, string ProjectId)
        //{
        //    var redirectUrl = Kanban(int.Parse(ProjectId));

        //    await Clients.All.SendAsync("ReceiveMessage", user, ProjectId, redirectUrl);
        //}

        //public string Kanban(int id)
        //{
        //    return _urlHelper.Action("Kanban", "Project", new { id = id });
        //}
    }

}
