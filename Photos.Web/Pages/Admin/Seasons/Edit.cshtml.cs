﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Photos.Shared.Models;
using Photos.Web.Data;

namespace Photos.Web.Pages.Admin.Seasons
{
    public class EditModel : PageModel
    {
        private readonly Photos.Web.Data.PhotoContext _context;

        public EditModel(Photos.Web.Data.PhotoContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Season Season { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null || _context.Seasons == null)
            {
                return NotFound();
            }

            var season =  await _context.Seasons.FirstOrDefaultAsync(m => m.Id == id);
            if (season == null)
            {
                return NotFound();
            }
            Season = season;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Season).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SeasonExists(Season.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool SeasonExists(long id)
        {
          return _context.Seasons.Any(e => e.Id == id);
        }
    }
}
