using System.ComponentModel.DataAnnotations;

namespace Cv.Models.Items
{
    public class ContactItem
    {
        [Required]
        [MinLength(5)]
        [MaxLength(100)]
        public string FullName { get; set; }
        [MaxLength(50)]
        public string Role { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        [MinLength(7)]
        public string Phone { get; set; }
    }
}
