﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Gazenergokomplekt.Context;
using Gazenergokomplekt.Models.DBModels;
using Microsoft.Data.SqlClient;
using Gazenergokomplekt.Service;

namespace Gazenergokomplekt.Controllers
{
    public class OrdersController : Controller
    {
        private readonly DataContext _context;
        private Auth _auth = new Auth();

        public OrdersController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Products()
        {
            return View();
        }
        public IActionResult Admin()
        {
            return View();
        }
        public async Task<IActionResult> Check([Bind("Login,Password")] Admins admins)
        {
            if (ModelState.IsValid)
            {
                var admin = await _context.Admins!.FirstOrDefaultAsync(x => x.Login == admins.Login && x.Password == admins.Password);

                if (admin != null)
                {
                    _auth.SetAuthStatus(true);
                    return RedirectToAction(nameof(Index));
                }
                if (admin == null)
                {
                    _auth.SetAuthStatus(false);
                    return RedirectToAction(nameof(Admin));
                }
            }
            return RedirectToAction(nameof(Admin));
        }
        // GET: Orders
        public async Task<IActionResult> Index()
        {
            var status = _auth.ReturnAuthetStatus();

            if (status == true)
            {
                return _context.Orders != null ?
             View(await _context.Orders.ToListAsync()) :
             Problem("Entity set 'DataContext.Orders'  is null.");
            }
            if (status == false)
            {
                return RedirectToAction(nameof(Admin));
            }
            return RedirectToAction(nameof(Admin));
        }
        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Orders == null)
            {
                return NotFound();
            }

            var orders = await _context.Orders
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orders == null)
            {
                return NotFound();
            }

            return View(orders);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Email,PhoneNumber,Message,Product,DateCreationOrder")] Orders orders)
        {
            if (ModelState.IsValid)
            {
                orders.DateCreationOrder = DateTime.Now;
                _context.Add(orders);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Products));
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Orders == null)
            {
                return NotFound();
            }

            var orders = await _context.Orders.FindAsync(id);
            if (orders == null)
            {
                return NotFound();
            }
            return View(orders);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email,PhoneNumber,Message,Product,DateCreationOrder")] Orders orders)
        {
            if (id != orders.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orders);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrdersExists(orders.Id))
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
            return View(orders);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Orders == null)
            {
                return NotFound();
            }

            var orders = await _context.Orders
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orders == null)
            {
                return NotFound();
            }

            return View(orders);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Orders == null)
            {
                return Problem("Entity set 'DataContext.Orders'  is null.");
            }
            var orders = await _context.Orders.FindAsync(id);
            if (orders != null)
            {
                _context.Orders.Remove(orders);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrdersExists(int id)
        {
            return (_context.Orders?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
