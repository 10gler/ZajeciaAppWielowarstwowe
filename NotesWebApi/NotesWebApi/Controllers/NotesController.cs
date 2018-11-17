using Microsoft.AspNetCore.Mvc;
using NotesWebApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly NotesContext _context;

        public NotesController(NotesContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<Note>> GetAllNotes()
        {
            return _context.Notes.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Note> GetById(Guid id)
        {
            var note = _context.Notes.Find(id);
            if (note == null)
            {
                return NotFound();
            }
            return note;
        }

        [HttpPost]
        [ProducesResponseType(400)]
        [ProducesResponseType(201)]
        public ActionResult<Note> CreateNote(Note note)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _context.Notes.Add(note);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = note.Id }, note);
        }

        //public List<Note> GetAllNotes()
        //{
        //    return _context.Notes.ToList();
        //}

        //public IActionResult GetAllNotes() {
        //    return Ok(_context.Notes.ToList());
        //}

    }
}
