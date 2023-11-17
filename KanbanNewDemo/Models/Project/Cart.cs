using System.ComponentModel.DataAnnotations;

namespace KanbanNewDemo.Models.Project
{
    public class Cart
    {
        [Key]
        public int CartId { get; set; }

        [MaxLength(200)]
        [Required]
        public string Name { get; set; }

        public int ProjectId { get; set; }

        public int StatusNumber { get; set; }

        public bool IsDelete { get; set; }

        #region Relations

        public Project Project { get; set; }

        #endregion
    }
}