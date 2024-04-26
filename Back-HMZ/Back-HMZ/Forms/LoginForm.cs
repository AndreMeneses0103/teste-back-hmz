using System.ComponentModel.DataAnnotations;

namespace Back_HMZ.Forms
{
    public class LoginForm
    {
        [Required]
        public string LoginName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
