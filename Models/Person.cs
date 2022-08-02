using System.ComponentModel.DataAnnotations;

namespace Commander.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FullNames { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public int MobileNumber { get; set; }


    }
}