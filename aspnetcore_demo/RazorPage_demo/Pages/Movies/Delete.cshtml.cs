using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPage_demo.Models;

namespace RazorPage_demo.Pages.Movies
{
    public class DeleteModel : PageModel
    {
        private readonly RazorPage_demo.Models.RazorPage_demoContext _context;

        public DeleteModel(RazorPage_demo.Models.RazorPage_demoContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Moviescs = await _context.Moviescs.FindAsync(id);

            if (Moviescs != null)
            {
                _context.Moviescs.Remove(Moviescs);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
