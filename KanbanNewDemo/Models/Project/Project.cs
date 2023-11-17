
using System.ComponentModel.DataAnnotations;


namespace KanbanNewDemo.Models.Project
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }

        [MaxLength(200)]
        [Required]
        public string Title { get; set; }

        public int UserId { get; set; }

        [MaxLength(400)]
        public string Description { get; set; }

        public DateTime CreateDate { get; set; }

        public bool IsDelete { get; set; }

        #region Relations

        public User.User User { get; set; }
        public List<Cart> Carts { get; set; }

        #endregion
    }
}