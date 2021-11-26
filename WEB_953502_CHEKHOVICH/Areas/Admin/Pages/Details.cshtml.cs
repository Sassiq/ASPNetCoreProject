using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WEB_953502_CHEKHOVICH.Data;
using WEB_953502_CHEKHOVICH.Entities;

namespace WEB_953502_CHEKHOVICH.Areas.Admin.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly WEB_953502_CHEKHOVICH.Data.ApplicationDbContext _context;

        public DetailsModel(WEB_953502_CHEKHOVICH.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Computer Computer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Computer = await _context.Computers
                .Include(c => c.Group).FirstOrDefaultAsync(m => m.ComputerId == id);

            if (Computer == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
