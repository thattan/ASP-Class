using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FordVSChevy.Data;
using FordVSChevy.Models;

namespace FordVSChevy.Controllers
{
    public class AutoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AutoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Auto
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.CarInfos.Include(c => c.CarType);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Auto/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carInfo = await _context.CarInfos
                .Include(c => c.CarType)
                .SingleOrDefaultAsync(m => m.CarInfoId == id);
            if (carInfo == null)
            {
                return NotFound();
            }

            return View(carInfo);
        }

        // GET: Auto/Create
        public IActionResult Create()
        {
            ViewData["CarTypeId"] = new SelectList(_context.carTypes, "CarTypeId", "CarMake");
            return View();
        }

        // POST: Auto/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CarInfoId,FirstName,LastName,Email,CarPref,NumberCars,PhoneNumber,CarTypeId")] CarInfo carInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarTypeId"] = new SelectList(_context.carTypes, "CarTypeId", "CarTypeId", carInfo.CarTypeId);
            return View(carInfo);
        }

        // GET: Auto/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carInfo = await _context.CarInfos.SingleOrDefaultAsync(m => m.CarInfoId == id);
            if (carInfo == null)
            {
                return NotFound();
            }
            ViewData["CarTypeId"] = new SelectList(_context.carTypes, "CarTypeId", "CarTypeId", carInfo.CarTypeId);
            return View(carInfo);
        }

        // POST: Auto/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CarInfoId,FirstName,LastName,Email,CarPref,NumberCars,PhoneNumber,CarTypeId")] CarInfo carInfo)
        {
            if (id != carInfo.CarInfoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarInfoExists(carInfo.CarInfoId))
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
            ViewData["CarTypeId"] = new SelectList(_context.carTypes, "CarTypeId", "CarTypeId", carInfo.CarTypeId);
            return View(carInfo);
        }

        // GET: Auto/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carInfo = await _context.CarInfos
                .Include(c => c.CarType)
                .SingleOrDefaultAsync(m => m.CarInfoId == id);
            if (carInfo == null)
            {
                return NotFound();
            }

            return View(carInfo);
        }

        // POST: Auto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carInfo = await _context.CarInfos.SingleOrDefaultAsync(m => m.CarInfoId == id);
            _context.CarInfos.Remove(carInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarInfoExists(int id)
        {
            return _context.CarInfos.Any(e => e.CarInfoId == id);
        }
    }
}
