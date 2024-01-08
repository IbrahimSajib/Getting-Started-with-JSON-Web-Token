#nullable disable
using System.ComponentModel.DataAnnotations;

namespace JSON_Web_Token.Models
{
    public class RegisterVM
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        [Display(Name = "Confirm password")]
        [Compare("Password",
            ErrorMessage = "Password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
