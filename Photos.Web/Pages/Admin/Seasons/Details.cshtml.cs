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
    public class DetailsModel : PageModel
    {
        private readonly Photos.Web.Data.PhotoContext _context;

        public DetailsModel(Photos.Web.Data.PhotoContext context)
        {
            _context = context;
        }

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
    }
}
