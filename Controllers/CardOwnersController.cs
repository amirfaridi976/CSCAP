using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CSCAP.Data;
using CSCAP.Models;

namespace CSCAP.Controllers
{
    public class CardOwnersController : Controller
    {
        private readonly CSCAPContext _context;

        public CardOwnersController(CSCAPContext context)
        {
            _context = context;
        }

        // GET: CardOwners
        public async Task<IActionResult> Index()
        {
              return _context.CardOwner != null ? 
                          View(await _context.CardOwner.ToListAsync()) :
                          Problem("Entity set 'CSCAPContext.CardOwner'  is null.");
        }

        // GET: CardOwners/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CardOwner == null)
            {
                return NotFound();
            }

            var cardOwner = await _context.CardOwner
                .FirstOrDefaultAsync(m => m.CardOwnerId == id);
            if (cardOwner == null)
            {
                return NotFound();
            }

            return View(cardOwner);
        }

        // GET: CardOwners/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CardOwners/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CardOwnerId,Name")] CardOwner cardOwner)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cardOwner);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cardOwner);
        }

        // GET: CardOwners/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CardOwner == null)
            {
                return NotFound();
            }

            var cardOwner = await _context.CardOwner.FindAsync(id);
            if (cardOwner == null)
            {
                return NotFound();
            }
            return View(cardOwner);
        }

        // POST: CardOwners/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CardOwnerId,Name")] CardOwner cardOwner)
        {
            if (id != cardOwner.CardOwnerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cardOwner);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CardOwnerExists(cardOwner.CardOwnerId))
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
            return View(cardOwner);
        }

        // GET: CardOwners/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CardOwner == null)
            {
                return NotFound();
            }

            var cardOwner = await _context.CardOwner
                .FirstOrDefaultAsync(m => m.CardOwnerId == id);
            if (cardOwner == null)
            {
                return NotFound();
            }

            return View(cardOwner);
        }

        // POST: CardOwners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CardOwner == null)
            {
                return Problem("Entity set 'CSCAPContext.CardOwner'  is null.");
            }
            var cardOwner = await _context.CardOwner.FindAsync(id);
            if (cardOwner != null)
            {
                _context.CardOwner.Remove(cardOwner);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CardOwnerExists(int id)
        {
          return (_context.CardOwner?.Any(e => e.CardOwnerId == id)).GetValueOrDefault();
        }
    }
}
