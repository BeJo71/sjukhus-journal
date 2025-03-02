using Microsoft.AspNetCore.Mvc;
using sjukhus_journal.Models;

namespace sjukhus_journal.Controllers;

[Route("api/[controller]")]
[ApiController]
public class JournalController : ControllerBase
{
        private readonly JournalDbContext _context;

        public JournalController(JournalDbContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        public ActionResult<IEnumerable<Journal>> GetJournals()
        {
            return _context.Journaler.ToList();
        } 

         [HttpDelete("{id}")] //radera en journal, kanske onödigt att ta bort en hel journal? 
        public IActionResult DeleteJournal(int id)
        {
        var journal = _context.Journaler.Find(id);

        if (journal == null)
        {
        return NotFound(); 
        }

        _context.Journaler.Remove(journal);
        _context.SaveChanges(); 

        return NoContent(); 
        }
 
    [HttpPut("clear-note/{id}")] // radera en anteckning
    public IActionResult ClearNote(int id)
    {
        var journal = _context.Journaler.Find(id);

        if (journal == null)
        {
            return NotFound(); 
        }

        journal.Anteckning = ""; 
        _context.SaveChanges();  

        return NoContent(); 
    }
}
