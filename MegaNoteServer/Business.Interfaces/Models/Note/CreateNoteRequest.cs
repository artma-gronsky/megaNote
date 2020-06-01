using System.ComponentModel.DataAnnotations;

namespace Business.Interfaces.Models
{
    public class CreateNoteRequest
    {
        [MaxLength(255)]
        public string FirstName { get; set; }

        [MaxLength(255)]
        public string LastName { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [MaxLength(500)]
        public string AdditionalInfo { get; set; }

    }
}
