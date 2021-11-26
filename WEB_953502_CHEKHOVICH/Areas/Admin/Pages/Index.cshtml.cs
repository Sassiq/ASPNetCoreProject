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
    public class IndexModel : PageModel
    {
        private readonly WEB_953502_CHEKHOVICH.Data.ApplicationDbContext _context;

        public IndexModel(WEB_953502_CHEKHOVICH.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Computer> Computer { get;set; }

        public async Task OnGetAsync()
        {
            Computer = await _context.Computers
                .Include(c => c.Group).ToListAsync();
        }
    }
}
