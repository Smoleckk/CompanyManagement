using ApiProject.Models;

namespace ApiProject.Services.NoteService
{
    public interface INoteService
    {
        public Task<ServiceResponse<List<Note>>> GetNotes();
        public Task<ServiceResponse<Note>> GetNote(int id);
        public Task<ServiceResponse<Note>> DeleteNote(int id);
        public Task<ServiceResponse<Note>> PutNote(Note note);

        public Task<ServiceResponse<List<Note>>> GetNotesByUser(string userName);
        public Task<ServiceResponse<Note>> PostNoteByUser(Note note, string userName);



    }
}
