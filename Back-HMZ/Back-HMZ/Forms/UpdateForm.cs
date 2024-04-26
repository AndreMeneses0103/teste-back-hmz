using System.ComponentModel.DataAnnotations;

namespace Back_HMZ.Forms
{
    public class UpdateForm
    {
        public string? email { get; set; }
        public string? first_name { get; set; }
        public string? last_name { get; set; }
        public string? avatar { get; set; }
    }
}
