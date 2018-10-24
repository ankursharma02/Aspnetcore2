using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPage_demo.Models;

namespace RazorPage_demo.Pages.Movies
{
    public class EditModel : PageModel
    {
        private readonly RazorPage_demo.Models.RazorPage_demoContext _context;

        public EditModel(RazorPage_demo.Models.RazorPage_demoContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Moviescs Moviescs { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Moviescs = await _context.Moviescs.FirstOrDefaultAsync(m => m.ID == id);

            if (Moviescs == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Moviescs).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MoviescsExists(Moviescs.ID))
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

        private bool MoviescsExists(int id)
        {
            return _context.Moviescs.Any(e => e.ID == id);
        }
    }
}
