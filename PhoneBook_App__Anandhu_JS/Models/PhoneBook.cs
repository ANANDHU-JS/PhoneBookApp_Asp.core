using System.ComponentModel.DataAnnotations;

namespace PhoneBook_App__Anandhu_JS.Models
{
    public class PhoneBook
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string UserId { get; set; }
    }
}
