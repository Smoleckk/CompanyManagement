using ApiProject.Data;
using ApiProject.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiProject.Services.NoteService
{
    public class NoteService : INoteService
    {
        private readonly DataContext _context;
        public NoteService(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<Note>>> GetNotes()
        {
            var response = new ServiceResponse<List<Note>>();
            var notes = await _context.Notes.ToListAsync();
            if (notes == null)
            {
                response.Success = false;
                response.Message = "Notes not found.";
                return response;
            }
            response.Message = "Notes found successfully.";
            response.Data = notes;
            return response;
        }
        public async Task<ServiceResponse<Note>> GetNote(int id)
        {
            var response = new ServiceResponse<Note>();
            var note = await _context.Notes.FirstOrDefaultAsync(i => i.Id == id);
            if (note == null)
            {
                response.Success = false;
                response.Message = "Note not found.";
                return response;
            }
            response.Message = "Note found successfully.";
            response.Data = note;
            return response;
        }
        public async Task<ServiceResponse<Note>> DeleteNote(int id)
        {
            var response = new ServiceResponse<Note>();
            var note = await _context.Notes.FirstOrDefaultAsync(i => i.Id == id);
            if (note == null)
            {
                response.Success = false;
                response.Message = "Note not found, delete is impossible.";
                return response;
            }
            _context.Notes.Remove(note);
            await _context.SaveChangesAsync();

            response.Message = "Note deleted successfully.";
            response.Data = note;
            return response;
        }
            public async Task<ServiceResponse<Note>> PutNote(Note putNote)
        {
            var response = new ServiceResponse<Note>();
            var note = await _context.Notes.FirstOrDefaultAsync(i => i.Id == putNote.Id);
            if (note == null)
            {
                response.Success = false;
                response.Message = "Note not found, update is impossible.";
                return response;
            }
            _context.Update(note);
            await _context.SaveChangesAsync();

            response.Message = "Note updated successfully.";
            response.Data = note;
            return response;
        }

        public async Task<ServiceResponse<List<Note>>> GetNotesByUser(string userName)
        {
            var response = new ServiceResponse<List<Note>>();
            var user = await _context.Users.Include(d => d.Notes).FirstOrDefaultAsync(i => i.Username == userName);
            if (user == null)
            {
                response.Success = false;
                response.Message = "User not found, impossible to get notes.";
                return response;
            }
            response.Message = "Notes found successfully from user"+user.Username;
            response.Data = user.Notes.ToList();
            return response;
        }

        public async Task<ServiceResponse<Note>> PostNoteByUser(Note note, string userName)
        {
            var response = new ServiceResponse<Note>();
            var user = await _context.Users.FirstOrDefaultAsync(i => i.Username == userName);
            if (user == null)
            {
                response.Success = false;
                response.Message = "User not found, impossible to add notes.";
                return response;
            }
            user.Notes.Add(note);
            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            response.Message = "Note add successfully from user" + user.Username;
            response.Data = note;
            return response;
        }


    }
}
