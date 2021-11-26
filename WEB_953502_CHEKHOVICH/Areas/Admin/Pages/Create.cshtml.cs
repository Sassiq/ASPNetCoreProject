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
using WEB_953502_CHEKHOVICH.Data;
using WEB_953502_CHEKHOVICH.Entities;

namespace WEB_953502_CHEKHOVICH.Areas.Admin.Pages
{
    public class CreateModel : PageModel
    {
        private readonly WEB_953502_CHEKHOVICH.Data.ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public CreateModel(WEB_953502_CHEKHOVICH.Data.ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _environment = env;
        }

        public IActionResult OnGet()
        {
            ViewData["ComputerGroupId"] = new SelectList(_context.ComputerGroups, "ComputerGroupId", "GroupName");
            return Page();
        }

        [BindProperty]
        public Computer Computer { get; set; }

        [BindProperty]
        public IFormFile Image { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Computers.Add(Computer);
            await _context.SaveChangesAsync();

            if (Image != null)
            {
                var fileName = $"{Computer.ComputerId}" + Path.GetExtension(Image.FileName);
                Computer.Image = fileName;
                var path = Path.Combine(_environment.WebRootPath, "Images", fileName);
                using (var fStream = new FileStream(path, FileMode.Create))
                {
                    await Image.CopyToAsync(fStream);
                }
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
