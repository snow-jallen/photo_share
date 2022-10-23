using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Photos.Shared.Models;
using Photos.Web.Data;

namespace Photos.Web.Pages.Admin.Organizations
{
    public class IndexModel : PageModel
    {
        private readonly Photos.Web.Data.PhotoContext _context;

        public IndexModel(Photos.Web.Data.PhotoContext context)
        {
            _context = context;
        }

        public IList<Organization> Organization { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Organizations != null)
            {
                Organization = await _context.Organizations.ToListAsync();
            }
        }
    }
}
