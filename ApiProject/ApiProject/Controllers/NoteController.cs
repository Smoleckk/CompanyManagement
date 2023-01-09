using ApiProject.Data;
using ApiProject.Dtos;
using ApiProject.Models;
using ApiProject.Services.NoteService;
using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]

    public class NoteController : ControllerBase
    {
        private readonly INoteService _noteService;

        public NoteController(INoteService noteService)
        {
            _noteService = noteService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Note>>> GetNotes()
        {

            var response = await _noteService.GetNotes();
            return Ok(response.Data);
        }

        [HttpGet("/single-note/{id}")]
        public async Task<ActionResult<Note>> GetNote(int id)
        {
            var response = await _noteService.GetNote(id);
            if (!response.Success)
            {
                return NotFound(response);
            }
            return Ok(response.Data);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<Note>>> DeleteNote(int id)
        {
            var response = await _noteService.DeleteNote(id);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        [HttpPut]
        public async Task<ActionResult<string>> PutNote(Note note)
        {
            var response = await _noteService.PutNote(note);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        [HttpGet("{userName}")]
        public async Task<ActionResult<List<Note>>> GetNotes(string userName)
        {
            var response = await _noteService.GetNotesByUser(userName);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response.Data);
        }

        [HttpPost("{userName}")]
        public async Task<ActionResult<string>> PostNote(Note note, string userName)
        {
            var response = await _noteService.PostNoteByUser(note, userName);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}
