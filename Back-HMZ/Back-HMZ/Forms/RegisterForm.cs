using System.ComponentModel.DataAnnotations;

namespace Back_HMZ.Forms
{
    public class RegisterForm
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
