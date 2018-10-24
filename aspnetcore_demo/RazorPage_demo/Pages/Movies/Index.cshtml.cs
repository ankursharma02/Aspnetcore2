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
    public class IndexModel : PageModel
    {
        private readonly RazorPage_demo.Models.RazorPage_demoContext _context;

        public IndexModel(RazorPage_demo.Models.RazorPage_demoContext context)
        {
            _context = context;
        }

        public IList<Moviescs> Moviescs { get;set; }

        public async Task OnGetAsync()
        {
            Moviescs = await _context.Moviescs.ToListAsync();
        }
    }
}
