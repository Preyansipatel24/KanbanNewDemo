using System.ComponentModel.DataAnnotations;

namespace KanbanNewDemo.DTOs.Projects
{
    public class EditCartViewModel
    {
        public int CartId { get; set; }

        [MaxLength(200)]
        [Required]
        public string Name { get; set; }

        public int ProjectId { get; set; }

        public int StatusNumber { get; set; }

        public bool IsDelete { get; set; }
    }
}
