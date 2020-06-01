using Business.Interfaces.Models;
using Business.Interfaces.Models.Note;
using Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface INoteService
    {
        Note GetDetails(Guid Id);
        NoteResponseModel[] GetAll();
        Task<Guid> Create(CreateNoteRequest request);

        Task Update(UpdateNoteRequest request);

        Task Delete(Guid id);
    }
}
