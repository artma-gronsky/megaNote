using Business.Interfaces;
using Business.Interfaces.Models;
using Business.Interfaces.Models.Note;
using Domain.Entities;
using Domain.RepositoriesInterfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Services
{
    public class NoteService: INoteService
    {
        private readonly INoteRepository _noteRepository;
        public NoteService(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public async Task<Guid> Create(CreateNoteRequest request)
        {
            var note = new Note(request.FirstName, request.LastName, request.Phone, request.Email, request.AdditionalInfo);

            _noteRepository.Create(note);

            await _noteRepository.SaveChangesAsync();

            return note.Id;
        }

        public async Task Update(UpdateNoteRequest request)
        {
            
            var note = GetOrThrowIfNotFound(request.Id);

            note.FirstName = request.FirstName;
            note.LastName = request.LastName;
            note.Phone = request.Phone;
            note.AdditionalInfo = request.AdditionalInfo;
            request.Email = request.Email;

            _noteRepository.Update(note);
            await _noteRepository.SaveChangesAsync();
        }

        public Note GetDetails(Guid Id)
        {
            return GetOrThrowIfNotFound(Id);
        }
        
        private Note GetOrThrowIfNotFound(Guid id)
        {
            var note = _noteRepository.GetById(id);

            if (note == null)
                throw new ArgumentException($"Unable to find Entity with ID = {id}");

            return note;
        }

        public NoteResponseModel[] GetAll()
        {
            return _noteRepository.GetAll()
                .Select(x => new NoteResponseModel(x.Id, x.FirstName, x.FirstName, x.Phone, x.Email, x.CreationDate))
                .ToArray();
        }

        public async Task Delete(Guid id)
        {
            var note = GetOrThrowIfNotFound(id);
            _noteRepository.Delete(note);

            await _noteRepository.SaveChangesAsync();
        }
    }
}
