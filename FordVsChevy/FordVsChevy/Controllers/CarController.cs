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
    public class CarController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CarController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Car
        public async Task<IActionResult> Index()
        {
            return View(await _context.CarInfos.ToListAsync());
        }

        // GET: Car/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carInfo = await _context.CarInfos
                .SingleOrDefaultAsync(m => m.CarInfoId == id);
            if (carInfo == null)
            {
                return NotFound();
            }

            return View(carInfo);
        }

        // GET: Car/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Car/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CarInfoId,FirstName,LastName,Email,CarPref,NumberCars,PhoneNumber")] CarInfo carInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(carInfo);
        }

        // GET: Car/Edit/5
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
            return View(carInfo);
        }

        // POST: Car/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CarInfoId,FirstName,LastName,Email,CarPref,NumberCars,PhoneNumber")] CarInfo carInfo)
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
            return View(carInfo);
        }

        // GET: Car/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carInfo = await _context.CarInfos
                .SingleOrDefaultAsync(m => m.CarInfoId == id);
            if (carInfo == null)
            {
                return NotFound();
            }

            return View(carInfo);
        }

        // POST: Car/Delete/5
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
