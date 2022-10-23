using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Photos.Shared.Models;

namespace Photos.Web.Pages.Admin.Events;

public class DetailsModel : PageModel
{
    private readonly Photos.Web.Data.PhotoContext _context;

    public DetailsModel(Photos.Web.Data.PhotoContext context)
    {
        _context = context;
    }

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
}
