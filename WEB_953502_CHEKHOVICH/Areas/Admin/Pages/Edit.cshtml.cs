using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WEB_953502_CHEKHOVICH.Data;
using WEB_953502_CHEKHOVICH.Entities;

namespace WEB_953502_CHEKHOVICH.Areas.Admin.Pages
{
    public class EditModel : PageModel
    {
        private readonly WEB_953502_CHEKHOVICH.Data.ApplicationDbContext _context;
        private IWebHostEnvironment _environment;

        public EditModel(WEB_953502_CHEKHOVICH.Data.ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _environment = env;
        }

        [BindProperty]
        public Computer Computer { get; set; }

        [BindProperty]
        public IFormFile Image { get; set; }

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
           ViewData["ComputerGroupId"] = new SelectList(_context.ComputerGroups, "ComputerGroupId", "GroupName");
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

            if (Image != null)
            {
                var fileName = $"{Computer.ComputerId}" + Path.GetExtension(Image.FileName);
                Computer.Image = fileName;
                var path = Path.Combine(_environment.WebRootPath, "Images", fileName);
                using (var fStream = new FileStream(path, FileMode.Create))
                {
                    await Image.CopyToAsync(fStream);
                }
            }

            _context.Attach(Computer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComputerExists(Computer.ComputerId))
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

        private bool ComputerExists(int id)
        {
            return _context.Computers.Any(e => e.ComputerId == id);
        }
    }
}
