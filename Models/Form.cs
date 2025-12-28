using System.ComponentModel.DataAnnotations;

namespace Activity3.Models
{
    public class Form
    {
        public string? Name { get; set; }

        [Required]
        public string? Character { get; set; }
        public string? MessageText { get; set; }
        public int? Rating { get; set; }



    }
}
