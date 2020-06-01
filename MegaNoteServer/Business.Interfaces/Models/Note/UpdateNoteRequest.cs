using System;

namespace Business.Interfaces.Models
{
    public class UpdateNoteRequest: CreateNoteRequest
    {
        public Guid Id { get; set; }

    }
}
