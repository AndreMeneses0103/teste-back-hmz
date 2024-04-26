using System.ComponentModel.DataAnnotations;

namespace Back_HMZ.Models
{
    public class Login
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
        [Key]
        public int UserId { get; set; }
    }
}
