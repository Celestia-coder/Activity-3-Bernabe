using System.ComponentModel.DataAnnotations;

namespace Activity3.Models
{
    public class Form
    {
        [Key]
        public int Id { get; set; }
        public string? Username { get; set; }

        [Required]
        public string? Character { get; set; }
        public string? MessageText { get; set; }
        public int? Rating { get; set; }



    }
}
