using System.ComponentModel.DataAnnotations;

namespace APIS.Models
{
    public class AddUser
    {
        [Required]
        [MinLength(2)]
        [MaxLength(10)]
        public string? FirstName { get; set; }

        [MaxLength(10)]
        [MinLength(2)]
        public string? LastName { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        public string? Phone { get; set; }
    }
}
