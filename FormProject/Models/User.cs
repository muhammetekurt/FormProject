using System.ComponentModel.DataAnnotations;

namespace FormProject.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        public int Age { get; set; }
        public ICollection<Form> Forms { get; set; }
        public User()
        {
            Forms = new List<Form>();
        }
    }
}
