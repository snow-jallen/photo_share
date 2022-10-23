using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Photos.Shared.Models;

namespace Photos.Web.Pages.Admin.Events;

public class DeleteModel : PageModel
{
    private readonly Photos.Web.Data.PhotoContext _context;

    public DeleteModel(Photos.Web.Data.PhotoContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Event Event { get; set; }

    public async Task<IActionResult> OnGetAsync(long? id)
    {
        if (id == null || _context.Events == null)
        {
            return NotFound();
        }

        var e = await _context.Events.FirstOrDefaultAsync(m => m.Id == id);

        if (e == null)
        {
            return NotFound();
        }
        else
        {
            Event = e;
        }
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(long? id)
    {
        if (id == null || _context.Events == null)
        {
            return NotFound();
        }
        var e = await _context.Events.FindAsync(id);

        if (e != null)
        {
            Event = e;
            _context.Events.Remove(Event);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}