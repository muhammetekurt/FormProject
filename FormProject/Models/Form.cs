using System.ComponentModel.DataAnnotations;

namespace FormProject.Models
{
    public class Form
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        /* Related Entities */
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
