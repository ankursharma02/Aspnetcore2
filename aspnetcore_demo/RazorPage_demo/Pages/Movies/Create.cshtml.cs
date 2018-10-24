using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPage_demo.Models;

namespace RazorPage_demo.Pages.Movies
{
    public class CreateModel : PageModel
    {
        private readonly RazorPage_demo.Models.RazorPage_demoContext _context;

        public CreateModel(RazorPage_demo.Models.RazorPage_demoContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Moviescs Moviescs { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Moviescs.Add(Moviescs);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}