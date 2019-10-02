using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MilesPerGallon.Models;

namespace MilesPerGallon.Controllers
{
    public class DataPagesController : Controller
    {
        private readonly MilesPerGallonContext _context;

        public DataPagesController(MilesPerGallonContext context)
        {
            _context = context;
        }

        // GET: DataPages
        public async Task<IActionResult> Index()
        {
            return View(await _context.DataPage.ToListAsync());
        }

        // GET: DataPages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dataPage = await _context.DataPage
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dataPage == null)
            {
                return NotFound();
            }

            return View(dataPage);
        }

        // GET: DataPages/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DataPages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,CarModel,MilesDriven,GallonsFilled,FillUpDate")] DataPage dataPage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dataPage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dataPage);
        }

        // GET: DataPages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dataPage = await _context.DataPage.FindAsync(id);
            if (dataPage == null)
            {
                return NotFound();
            }
            return View(dataPage);
        }

        // POST: DataPages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,CarModel,MilesDriven,GallonsFilled,FillUpDate")] DataPage dataPage)
        {
            if (id != dataPage.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dataPage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DataPageExists(dataPage.Id))
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
            return View(dataPage);
        }

        // GET: DataPages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dataPage = await _context.DataPage
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dataPage == null)
            {
                return NotFound();
            }

            return View(dataPage);
        }

        // POST: DataPages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dataPage = await _context.DataPage.FindAsync(id);
            _context.DataPage.Remove(dataPage);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DataPageExists(int id)
        {
            return _context.DataPage.Any(e => e.Id == id);
        }
    }
}
