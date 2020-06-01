using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Note: Entity
    {
        [MaxLength(255)]
        public virtual string FirstName { get; set; }

        [MaxLength(255)]
        public virtual string LastName { get; set; }

        [Required]
        [Phone]
        public virtual string Phone { get; set; }

        [EmailAddress]
        public virtual string Email { get; set; }

        [MaxLength(500)]
        public virtual string AdditionalInfo { get; set; }

        public virtual DateTime CreationDate { get; set; }

        public Note()
        {
            CreationDate = DateTime.UtcNow;
        }

        public Note(string firstName, string lastName, string phone, string email, string additionalInfo): base()
        {
            FirstName = firstName;
            LastName = lastName;
            Phone = phone;
            Email = email;
            AdditionalInfo = additionalInfo;
        }


    }
}
