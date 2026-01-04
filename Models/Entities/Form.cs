using System.ComponentModel.DataAnnotations;

namespace Activity3.Models.Entities
{
    public class Form
    {
        [Key]
        // This makes Id unique and encrypted
        public Guid Id { get; set; }

        public string? Username { get; set; }

        [Required]
        public string? Character { get; set; }
        public string? MessageText { get; set; }
        public int? Rating { get; set; }
    }
}