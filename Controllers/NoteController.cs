

using api.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using notes_api.Data;
using notes_api.Dtos.Note;
using notes_api.Models;

namespace notes_api.Controllers
{

    [Route("api/note")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private readonly AppDBContext _context;

        public NoteController(AppDBContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UpdateNoteRequestDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var noteModel = new Note
            {
                Content = dto.Content,
                Title = dto.Title

            };
            await _context.Note.AddAsync(noteModel);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = noteModel.Id }, noteModel);
        }



        [HttpGet]
        public IActionResult GetAllNotes(string title = "", string sortOrder = "newest")
        {
            IQueryable<Note> notesQuery = _context.Note;

            if (!string.IsNullOrWhiteSpace(title))
            {
                notesQuery = notesQuery.Where(n => n.Title.Contains(title));
            }

            switch (sortOrder.ToLower())
            {
                case "oldest":
                    notesQuery = notesQuery.OrderBy(n => n.CreatedAt); // Assuming 'CreatedDate' is a field in your 'Note' model
                    break;
                case "newest":
                    notesQuery = notesQuery.OrderByDescending(n => n.CreatedAt);
                    break;
                default:
                    return BadRequest("Invalid sort order. Please use 'newest' or 'oldest'.");
            }

            var notes = notesQuery.ToList();
            return Ok(notes);
        }


        [HttpGet("{id:int}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var note = _context.Note.Find(id);

            if (note == null)
            {
                return NotFound();
            }

            return Ok(note);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var noteModel = _context.Note.FirstOrDefault(x => x.Id == id);

            if (noteModel == null)
            {
                return NotFound();
            }
            _context.Note.Remove(noteModel);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateNoteRequestDto updateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingNote = await _context.Note.FirstOrDefaultAsync(x => x.Id == id);

            if (existingNote == null)
            {
                return null;
            }


            existingNote.Title = updateDto.Title;
            existingNote.Content = updateDto.Content;
            existingNote.UpdatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();

            return Ok(existingNote);
        }

    }
}