#nullable disable
using System.ComponentModel.DataAnnotations;

namespace JSON_Web_Token.Models
{
    public class LoginVM
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
