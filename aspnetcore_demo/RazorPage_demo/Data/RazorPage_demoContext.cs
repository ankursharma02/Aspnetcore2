using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RazorPage_demo.Models
{
    public class RazorPage_demoContext : DbContext
    {
        public RazorPage_demoContext (DbContextOptions<RazorPage_demoContext> options)
            : base(options)
        {
        }

        public DbSet<RazorPage_demo.Models.Moviescs> Moviescs { get; set; }
    }
}
