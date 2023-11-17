using System.ComponentModel.DataAnnotations;

namespace KanbanNewDemo.DTOs.Users
{
    public class RegisterViewModel
    {
        [Display(Name = "Username")]
        [Required]
        [MaxLength(250)]
        public string Username { get; set; }

        [Display(Name = "Email")]
        [Required]
        [MaxLength(250)]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [Required]
        [MaxLength(250)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "RePassword")]
        [Required]
        [MaxLength(250)]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string RePassword { get; set; }
    }

    public class LoginViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}