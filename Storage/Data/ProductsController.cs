﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Storage.Data;
using Storage.Models;
using Storage.Models.ViewModels;

namespace Storage.Controllers
{
    public class ProductsController : Controller
    {
        private readonly StorageContext _context;

        public ProductsController(StorageContext context)
        {
            _context = context;
        }

        // GET: Products
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.Product.ToListAsync());
        //}
        public async Task<IActionResult> Index()
        {
            var model = _context.Product.Select(e => new ProductIndexViewModel
            {
                Id = e.Id,
                Name = e.Name,
                Price = e.Price,
                Count = e.Count,
                Category = e.Category,
                InventoryValue = e.Price * e.Count
                
            });

            return View("Index2", await model.ToListAsync());
        }

        public async Task<IActionResult> Search(string searchField)
        {
            if (!string.IsNullOrEmpty(searchField)) { 
            var results = _context.Product.Where(e =>e.Category.Contains(searchField))
                .Select(e =>new ProductIndexViewModel
                {
                    Id = e.Id,
                    Name = e.Name,
                    Price = e.Price,
                    Count = e.Count,
                    InventoryValue = e.Price * e.Count,
                    Categories = new SelectListItem()
                    
                });
            return View("Index2", await results.ToListAsync());
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }
        }

        public async Task<SelectList> ListCategories()
        {
            var categories = _context.Product
                .GroupBy(e => e.Category)
                .Select(g => g.First());
            SelectList result = new SelectList(categories);       

            return result;
        }
        public async Task<IActionResult> Category(string category)
        {
            var results = _context.Product.Where(e => e.Category.Contains(category))
                .Select(e => new ProductIndexViewModel
                {
                    Id = e.Id,
                    Name = e.Name,
                    Price = e.Price,
                    Count = e.Count,
                    InventoryValue = e.Price * e.Count,
                    Categories = new SelectListItem()
                });
            return View("Index2", await results.ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(/*[Bind("Id,Name,Price,Orderdate,Category,Shelf,Count,Description")] Product product*/ CreateProductNewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var product = new Product
                {
                    Name = viewModel.Name,
                    Price = viewModel.Price,
                    Category = viewModel.Category,
                    Orderdate = viewModel.Orderdate,
                    Shelf = viewModel.Shelf,
                    Count = viewModel.Count,
                    Description = viewModel.Description

                };
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product.FindAsync(id);
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price,Orderdate,Category,Shelf,Count,Description")] Product product)
        {
            if (id != product.Id)
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
                    if (!ProductExists(product.Id))
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
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Product.FindAsync(id);
            if (product != null)
            {
                _context.Product.Remove(product);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.Id == id);
        }
    }
}
