using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces.Models.Note
{
    public class NoteResponseModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string AdditionalInfo { get; set; }
        public DateTime CreationDate { get; set; }

        public NoteResponseModel(Guid id, string firstName, string lastName, string phone, string email, DateTime creationDate) : base()
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Phone = phone;
            Email = email;
            CreationDate = creationDate;
        }
    }
}
