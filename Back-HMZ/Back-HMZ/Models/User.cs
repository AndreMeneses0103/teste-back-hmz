using System.ComponentModel.DataAnnotations;

namespace Back_HMZ.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string email { get; set; }
        public string? first_name { get; set; }
        public string? last_name { get; set; }
        public string? avatar { get; set; }
    }
}
