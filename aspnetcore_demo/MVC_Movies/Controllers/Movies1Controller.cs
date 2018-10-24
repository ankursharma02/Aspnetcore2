using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_Movies.Models;

namespace MVC_Movies.Controllers
{
    public class Movies1Controller : Controller
    {
        private readonly MVC_MoviesContext _context;

        public Movies1Controller(MVC_MoviesContext context)
        {
            _context = context;
        }

        // GET: Movies1
        public async Task<IActionResult> Index()
        {
            return View(await _context.Movies1.ToListAsync());
        }

        // GET: Movies1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movies1 = await _context.Movies1
                .FirstOrDefaultAsync(m => m.ID == id);
            if (movies1 == null)
            {
                return NotFound();
            }

            return View(movies1);
        }

        // GET: Movies1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Movies1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title,ReleaseDate,Genre,Price")] Movies1 movies1)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movies1);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movies1);
        }

        // GET: Movies1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movies1 = await _context.Movies1.FindAsync(id);
            if (movies1 == null)
            {
                return NotFound();
            }
            return View(movies1);
        }

        // POST: Movies1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,ReleaseDate,Genre,Price")] Movies1 movies1)
        {
            if (id != movies1.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movies1);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Movies1Exists(movies1.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(movies1);
        }

        // GET: Movies1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movies1 = await _context.Movies1
                .FirstOrDefaultAsync(m => m.ID == id);
            if (movies1 == null)
            {
                return NotFound();
            }

            return View(movies1);
        }

        // POST: Movies1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movies1 = await _context.Movies1.FindAsync(id);
            _context.Movies1.Remove(movies1);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Movies1Exists(int id)
        {
            return _context.Movies1.Any(e => e.ID == id);
        }
    }
}
