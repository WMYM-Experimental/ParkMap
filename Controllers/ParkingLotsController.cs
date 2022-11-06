using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ParkMap.Areas.Identity.Data;
using ParkMap.Models;

namespace ParkMap.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class ParkingLotsController : Controller
    {
        private readonly ParkMapContext _context;

        public ParkingLotsController(ParkMapContext context)
        {
            _context = context;
        }

        // GET: ParkingLots
        public async Task<IActionResult> Index()
        {
              return View(await _context.ParkingLot.ToListAsync());
        }

        // GET: ParkingLots/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ParkingLot == null)
            {
                return NotFound();
            }

            var parkingLot = await _context.ParkingLot
                .FirstOrDefaultAsync(m => m.Id == id);
            if (parkingLot == null)
            {
                return NotFound();
            }

            return View(parkingLot);
        }

        // GET: ParkingLots/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ParkingLots/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Availability,FreeSpots,DateTime")] ParkingLot parkingLot)
        {
            if (ModelState.IsValid)
            {
                _context.Add(parkingLot);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(parkingLot);
        }

        // GET: ParkingLots/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ParkingLot == null)
            {
                return NotFound();
            }

            var parkingLot = await _context.ParkingLot.FindAsync(id);
            if (parkingLot == null)
            {
                return NotFound();
            }
            return View(parkingLot);
        }

        // POST: ParkingLots/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Availability,FreeSpots")] ParkingLot parkingLot)
        {
            if (id != parkingLot.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    parkingLot.DateTime = DateTime.Now;
                    
                    _context.Update(parkingLot);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParkingLotExists(parkingLot.Id))
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
            return View(parkingLot);
        }

        // GET: ParkingLots/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ParkingLot == null)
            {
                return NotFound();
            }

            var parkingLot = await _context.ParkingLot
                .FirstOrDefaultAsync(m => m.Id == id);
            if (parkingLot == null)
            {
                return NotFound();
            }

            return View(parkingLot);
        }

        // POST: ParkingLots/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ParkingLot == null)
            {
                return Problem("Entity set 'ParkMapContext.ParkingLot'  is null.");
            }
            var parkingLot = await _context.ParkingLot.FindAsync(id);
            if (parkingLot != null)
            {
                _context.ParkingLot.Remove(parkingLot);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParkingLotExists(int id)
        {
          return _context.ParkingLot.Any(e => e.Id == id);
        }
    }
}
