using System.ComponentModel.DataAnnotations;

namespace DataPipeline.Dtos
{
    public class CreateUserDTO
    {
        [Required]
        public string FullName { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        public string Age { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
    }
}
