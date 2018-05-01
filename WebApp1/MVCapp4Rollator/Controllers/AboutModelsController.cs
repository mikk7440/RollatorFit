using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCapp4Rollator.Data;
using MVCapp4Rollator.Models;

namespace MVCapp4Rollator.Controllers
{
    public class AboutModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AboutModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AboutModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.AboutModel.ToListAsync());
        }

        // GET: AboutModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aboutModel = await _context.AboutModel
                .SingleOrDefaultAsync(m => m.ID == id);
            if (aboutModel == null)
            {
                return NotFound();
            }

            return View(aboutModel);
        }

        // GET: AboutModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AboutModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title,Text")] AboutModel aboutModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aboutModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aboutModel);
        }

        // GET: AboutModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aboutModel = await _context.AboutModel.SingleOrDefaultAsync(m => m.ID == id);
            if (aboutModel == null)
            {
                return NotFound();
            }
            return View(aboutModel);
        }

        // POST: AboutModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,Text")] AboutModel aboutModel)
        {
            if (id != aboutModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aboutModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AboutModelExists(aboutModel.ID))
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
            return View(aboutModel);
        }

        // GET: AboutModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aboutModel = await _context.AboutModel
                .SingleOrDefaultAsync(m => m.ID == id);
            if (aboutModel == null)
            {
                return NotFound();
            }

            return View(aboutModel);
        }

        // POST: AboutModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aboutModel = await _context.AboutModel.SingleOrDefaultAsync(m => m.ID == id);
            _context.AboutModel.Remove(aboutModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AboutModelExists(int id)
        {
            return _context.AboutModel.Any(e => e.ID == id);
        }
    }
}
