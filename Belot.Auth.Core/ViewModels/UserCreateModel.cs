using System.ComponentModel.DataAnnotations;

namespace Belot.Auth.Core.ViewModels
{
    public class UserCreateModel
    {
        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        public string Username { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        public string Password { get; set; }
    }
}
