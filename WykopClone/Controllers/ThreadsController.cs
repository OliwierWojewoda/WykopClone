using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WykopClone.Data;
using WykopClone.Models;

namespace WykopClone.Controllers
{
    public class ThreadsController : Controller
    {
        private readonly DataContext _context;

        public ThreadsController(DataContext context)
        {
            _context = context;
        }

        // GET: Threads
        public async Task<IActionResult> Index()
        {
              return View(await _context.Threads.ToListAsync());
        }

        // GET: Threads/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Threads == null)
            {
                return NotFound();
            }

            var thread = await _context.Threads
                .FirstOrDefaultAsync(m => m.Id == id);
            if (thread == null)
            {
                return NotFound();
            }

            return View(thread);
        }

        // GET: Threads/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Threads/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Models.Thread newthread)
        {
                var thread = new Models.Thread()
                {
                    Description = newthread.Description,
                    Title = newthread.Title,
                    Votes = newthread.Votes,
                    Category = newthread.Category
                };
                await _context.Threads.AddAsync(thread);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
        }

        // GET: Threads/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Threads == null)
            {
                return NotFound();
            }

            var thread = await _context.Threads.FindAsync(id);
            if (thread == null)
            {
                return NotFound();
            }
            return View(thread);
        }

        // POST: Threads/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,Votes,Category")] Models.Thread thread)
        {
            if (id != thread.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(thread);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ThreadExists(thread.Id))
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
            return View(thread);
        }

        // GET: Threads/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Threads == null)
            {
                return NotFound();
            }

            var thread = await _context.Threads
                .FirstOrDefaultAsync(m => m.Id == id);
            if (thread == null)
            {
                return NotFound();
            }

            return View(thread);
        }

        // POST: Threads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Threads == null)
            {
                return Problem("Entity set 'DataContext.Threads'  is null.");
            }
            var thread = await _context.Threads.FindAsync(id);
            if (thread != null)
            {
                _context.Threads.Remove(thread);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ThreadExists(int id)
        {
          return _context.Threads.Any(e => e.Id == id);
        }

        //Categories threads
        public async Task<IActionResult> Other()
        {
            return View(await _context.Threads.Where(x => x.Category == Models.Thread.CategoryType.Inna).ToListAsync());
        }     
        public async Task<IActionResult> Info()
        {
            return View(await _context.Threads.Where(x => x.Category == Models.Thread.CategoryType.Informacje).ToListAsync());
        }
        public async Task<IActionResult> Entertainment()
        {
            return View(await _context.Threads.Where(x => x.Category == Models.Thread.CategoryType.Rozrywka).ToListAsync());
        }
        public async Task<IActionResult> Sport()
        {
            return View(await _context.Threads.Where(x => x.Category == Models.Thread.CategoryType.Sport).ToListAsync());
        }
        public async Task<IActionResult> Politics()
        {
            return View(await _context.Threads.Where(x => x.Category == Models.Thread.CategoryType.Polityka).ToListAsync());
        }
        public async Task<IActionResult> Travels()
        {
            return View(await _context.Threads.Where(x => x.Category == Models.Thread.CategoryType.Podróże).ToListAsync());
        }
        public async Task<IActionResult> Technology()
        {
            return View(await _context.Threads.Where(x => x.Category == Models.Thread.CategoryType.Technologia).ToListAsync());
        }
        public async Task<IActionResult> Economy()
        {
            return View(await _context.Threads.Where(x => x.Category == Models.Thread.CategoryType.Gospodarka).ToListAsync());
        }
        public async Task<IActionResult> Motorization()
        {
            return View(await _context.Threads.Where(x => x.Category == Models.Thread.CategoryType.Motoryzacja).ToListAsync());
        }
        public async Task<IActionResult> Facts()
        {
            return View(await _context.Threads.Where(x=>x.Category== Models.Thread.CategoryType.Ciekawostki).ToListAsync());
        }

    }
}
