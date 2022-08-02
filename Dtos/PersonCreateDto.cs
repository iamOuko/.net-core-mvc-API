
using System.ComponentModel.DataAnnotations;

namespace Commander.Dtos
{
    public class PersonCreateDto
    {
        [Required]
        public string FullNames { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public int MobileNumber { get; set; }
    }
}
