using System.ComponentModel.DataAnnotations;

namespace Commander.Dtos
{
    public class PersonUpdateDto
    {
        [Required]
        public string FullNames { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public int MobileNumber { get; set; }
    }
}
