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
    public class NewsletterModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NewsletterModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: NewsletterModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.NewsletterModel.ToListAsync());
        }

        // GET: NewsletterModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newsletterModel = await _context.NewsletterModel
                .SingleOrDefaultAsync(m => m.ID == id);
            if (newsletterModel == null)
            {
                return NotFound();
            }

            return View(newsletterModel);
        }

        // GET: NewsletterModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NewsletterModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Email")] NewsletterModel newsletterModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(newsletterModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(newsletterModel);
        }

        // GET: NewsletterModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newsletterModel = await _context.NewsletterModel.SingleOrDefaultAsync(m => m.ID == id);
            if (newsletterModel == null)
            {
                return NotFound();
            }
            return View(newsletterModel);
        }

        // POST: NewsletterModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Email")] NewsletterModel newsletterModel)
        {
            if (id != newsletterModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(newsletterModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NewsletterModelExists(newsletterModel.ID))
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
            return View(newsletterModel);
        }

        // GET: NewsletterModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newsletterModel = await _context.NewsletterModel
                .SingleOrDefaultAsync(m => m.ID == id);
            if (newsletterModel == null)
            {
                return NotFound();
            }

            return View(newsletterModel);
        }

        // POST: NewsletterModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var newsletterModel = await _context.NewsletterModel.SingleOrDefaultAsync(m => m.ID == id);
            _context.NewsletterModel.Remove(newsletterModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NewsletterModelExists(int id)
        {
            return _context.NewsletterModel.Any(e => e.ID == id);
        }
    }
}
