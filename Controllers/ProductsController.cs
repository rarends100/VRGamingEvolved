﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VRGamingEvolved.Data;
using VRGamingEvolved.Models;

namespace VRGamingEvolved.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public ProductsController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
              return _context.products != null ? 
                          View(await _context.products.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.products'  is null.");
        }

        public async Task<IActionResult> GamesIndex()
        {
            return _context.games != null ? //This should work since a game is instantiated as a product, fingeers crossed
                        View(await _context.games.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.products'  is null.");
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.products == null)
            {
                return NotFound();
            }

            var product = await _context.products
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        [Authorize(Roles = "Admin, Employee")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Employee")]
        public async Task<IActionResult> Create([Bind("ProductId,ProductName,Cost,Sell,FileName,Review")] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Edit/5
        [Authorize(Roles = "Admin, Employee")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.products == null)
            {
                return NotFound();
            }

            var product = await _context.products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Employee")]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,ProductName,Cost,Sell,FileName,Review")] Product product)
        {
            if (id != product.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ProductId))
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
            return View(product);
        }

        // GET: Products/Delete/5
        [Authorize(Roles = "Admin, Employee")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.products == null)
            {
                return NotFound();
            }

            var product = await _context.products
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Employee")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.products == null)
            {
                return Problem("Entity set 'ApplicationDbContext.products'  is null.");
            }
            var product = await _context.products.FindAsync(id);
            if (product != null)
            {
                _context.products.Remove(product);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
          return (_context.products?.Any(e => e.ProductId == id)).GetValueOrDefault();
        }

        public IActionResult AddToCart(int id, string returnUrl)
        {
            Product product = _context.products.FirstOrDefault(p => p.ProductId == id);

            Cart cart = null;

            cart = GetCart();

            cart.AddItem(product, 1);



            SaveCart(cart);

            return View("ShowCart", cart);

        }

        private void SaveCart(Cart cart)
        {
            HttpContext.Session.SetObject<Cart>("cart", cart);
        }

        private Cart? GetCart()
        {
            Cart cart = null;

            if (HttpContext.Session.GetObject<Cart>("cart") == null)
            {
                cart = new Cart();
            }
            else
            {
                cart = HttpContext.Session.GetObject<Cart>("cart");
            }

            
            return cart;
        }

        public IActionResult DeleteCart(int id, string returnUrl)
        {
            Product product = _context.products.FirstOrDefault(p => p.ProductId == id);

            Cart cart = null;

            cart = GetCart();

            cart.RemoveLine(product, 1);

            SaveCart(cart);


            HttpContext.Session.Remove("cart");

            return View("ShowCart", cart);

        }

    }
}
