
using KanbanNewDemo.DTOs.Projects;
using KanbanNewDemo.Models.Project;

namespace KanbanNewDemo.Services.Interfaces
{
    public interface IProjectService
    {
        void AddProject(Project model);
        List<ShowProjectsViewModel> GetProjects();
        Project GetProjectById(int id);
        List<Cart> GetTodoCartByProjectId(int projectId);
        List<Cart> GetInProcessByProjectId(int projectId);
        List<Cart> GetDoneCartByProjectId(int projectId);
        void AddCart(Cart model);
        Cart GetCartById(int id);
        void UpdateCart(Cart cart);
        void UpdateProject(Project project);
    }
}