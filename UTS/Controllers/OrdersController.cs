using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UTS.Models;

namespace UTS.Controllers
{
    public class OrdersController : Controller
    {
        private readonly BillyardContext _context;

        public OrdersController(BillyardContext context)
        {
            _context = context;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            var billyardContext = _context.Order.Include(o => o.IdPacket1).Include(o => o.IdPacketNavigation).Include(o => o.IdStatusNavigation);
            return View(await billyardContext.ToListAsync());
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Order
                .Include(o => o.IdPacket1)
                .Include(o => o.IdPacketNavigation)
                .Include(o => o.IdStatusNavigation)
                .FirstOrDefaultAsync(m => m.IdOrder == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            ViewData["IdPacket"] = new SelectList(_context.Table, "IdTable", "IdTable");
            ViewData["IdPacket"] = new SelectList(_context.Packet, "IdPacket", "IdPacket");
            ViewData["IdStatus"] = new SelectList(_context.OrderStatus, "IdStatus", "IdStatus");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdOrder,IdPacket,IdUser,IdStatus,OrderDate,ExpireDate,CodePayment")] Order order)
        {
            if (ModelState.IsValid)
            {
                _context.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdPacket"] = new SelectList(_context.Table, "IdTable", "IdTable", order.IdPacket);
            ViewData["IdPacket"] = new SelectList(_context.Packet, "IdPacket", "IdPacket", order.IdPacket);
            ViewData["IdStatus"] = new SelectList(_context.OrderStatus, "IdStatus", "IdStatus", order.IdStatus);
            return View(order);
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Order.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            ViewData["IdPacket"] = new SelectList(_context.Table, "IdTable", "IdTable", order.IdPacket);
            ViewData["IdPacket"] = new SelectList(_context.Packet, "IdPacket", "IdPacket", order.IdPacket);
            ViewData["IdStatus"] = new SelectList(_context.OrderStatus, "IdStatus", "IdStatus", order.IdStatus);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdOrder,IdPacket,IdUser,IdStatus,OrderDate,ExpireDate,CodePayment")] Order order)
        {
            if (id != order.IdOrder)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.IdOrder))
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
            ViewData["IdPacket"] = new SelectList(_context.Table, "IdTable", "IdTable", order.IdPacket);
            ViewData["IdPacket"] = new SelectList(_context.Packet, "IdPacket", "IdPacket", order.IdPacket);
            ViewData["IdStatus"] = new SelectList(_context.OrderStatus, "IdStatus", "IdStatus", order.IdStatus);
            return View(order);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Order
                .Include(o => o.IdPacket1)
                .Include(o => o.IdPacketNavigation)
                .Include(o => o.IdStatusNavigation)
                .FirstOrDefaultAsync(m => m.IdOrder == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await _context.Order.FindAsync(id);
            _context.Order.Remove(order);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
            return _context.Order.Any(e => e.IdOrder == id);
        }
    }
}
