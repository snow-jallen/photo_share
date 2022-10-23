using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Photos.Shared.Models;
using Photos.Web.Data;

namespace Photos.Web.Pages.Admin.Seasons
{
    public class DeleteModel : PageModel
    {
        private readonly Photos.Web.Data.PhotoContext _context;

        public DeleteModel(Photos.Web.Data.PhotoContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Season Season { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null || _context.Seasons == null)
            {
                return NotFound();
            }

            var season = await _context.Seasons.FirstOrDefaultAsync(m => m.Id == id);

            if (season == null)
            {
                return NotFound();
            }
            else 
            {
                Season = season;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(long? id)
        {
            if (id == null || _context.Seasons == null)
            {
                return NotFound();
            }
            var season = await _context.Seasons.FindAsync(id);

            if (season != null)
            {
                Season = season;
                _context.Seasons.Remove(Season);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
