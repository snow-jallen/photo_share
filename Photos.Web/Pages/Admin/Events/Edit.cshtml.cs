﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Photos.Shared.Models;

namespace Photos.Web.Pages.Admin.Events
{
    public class EditModel : PageModel
    {
        private readonly Photos.Web.Data.PhotoContext _context;

        public EditModel(Photos.Web.Data.PhotoContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Event Event { get; set; } = default!;

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
            Event = e;
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

            _context.Attach(Event).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventExists(Event.Id))
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

        private bool EventExists(long id)
        {
            return _context.Events.Any(e => e.Id == id);
        }
    }
}
