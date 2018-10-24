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
    public class DetailsModel : PageModel
    {
        private readonly RazorPage_demo.Models.RazorPage_demoContext _context;

        public DetailsModel(RazorPage_demo.Models.RazorPage_demoContext context)
        {
            _context = context;
        }

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
    }
}
