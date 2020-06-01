using Domain.Entities;
using Domain.RepositoriesInterfaces;

namespace Domain.Repositories
{
    public class NoteRepository : BaseRepository<Note>, INoteRepository
    {
        public NoteRepository(StorageContext context): base(context) { }
    }
}
