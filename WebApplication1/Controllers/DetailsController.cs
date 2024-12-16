using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DJ_s_League.Models;
using WebApplication1.Data;

namespace WebApplication1.Controllers
{
    public class DetailsController : Controller
    {
        // This is where we connect to the database
        private readonly ApplicationDbContext _context;

        // Constructor to set up the database context
        public DetailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Details (This shows the list of all details)
        public async Task<IActionResult> Index()
        {
            // Fetches all details from the database and shows them
            return View(await _context.Detail.ToListAsync());
        }

        // GET: Details/Details/5 (This shows details for a single item)
        public async Task<IActionResult> Details(int? id)
        {
            // If the id is not given, show an error (404 page)
            if (id == null)
            {
                return NotFound();
            }

            // Find the detail in the database by its id
            var detail = await _context.Detail
                .FirstOrDefaultAsync(m => m.Id == id);
            if (detail == null)
            {
                // If no detail is found, show an error (404 page)
                return NotFound();
            }

            // Show the detail information in the view
            return View(detail);
        }

        // GET: Details/Create (This shows a form to create a new detail)
        public IActionResult Create()
        {
            return View();
        }

        // POST: Details/Create (This saves the new detail to the database)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,StartDate,EndDate,MinimumLevel")] Detail detail)
        {
            // Check if the model is valid (everything is correct)
            if (ModelState.IsValid)
            {
                // Add the new detail to the database
                _context.Add(detail);
                await _context.SaveChangesAsync();
                // After saving, redirect to the list of all details
                return RedirectToAction(nameof(Index));
            }
            // If something is wrong with the form, show it again with error messages
            return View(detail);
        }

        // GET: Details/Edit/5 (This shows a form to edit an existing detail)
        public async Task<IActionResult> Edit(int? id)
        {
            // If no id is given, show an error (404 page)
            if (id == null)
            {
                return NotFound();
            }

            // Find the detail by its id
            var detail = await _context.Detail.FindAsync(id);
            if (detail == null)
            {
                // If no detail is found, show an error (404 page)
                return NotFound();
            }
            // Show the detail in the form for editing
            return View(detail);
        }

        // POST: Details/Edit/5 (This saves the updated detail to the database)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,StartDate,EndDate,MinimumLevel")] Detail detail)
        {
            // Check if the id from the URL matches the id of the detail
            if (id != detail.Id)
            {
                return NotFound();
            }

            // If the model is valid (everything is correct)
            if (ModelState.IsValid)
            {
                try
                {
                    // Update the existing detail in the database
                    _context.Update(detail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    // If there is an issue with updating (like it doesn't exist anymore), show an error
                    if (!DetailExists(detail.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        // If another error occurs, throw it
                        throw;
                    }
                }
                // After saving, redirect to the list of all details
                return RedirectToAction(nameof(Index));
            }
            // If something is wrong with the form, show it again with error messages
            return View(detail);
        }

        // GET: Details/Delete/5 (This shows a page asking if you are sure you want to delete the detail)
        public async Task<IActionResult> Delete(int? id)
        {
            // If no id is given, show an error (404 page)
            if (id == null)
            {
                return NotFound();
            }

            // Find the detail by its id
            var detail = await _context.Detail
                .FirstOrDefaultAsync(m => m.Id == id);
            if (detail == null)
            {
                // If no detail is found, show an error (404 page)
                return NotFound();
            }

            // Show the detail in the confirmation page
            return View(detail);
        }

        // POST: Details/Delete/5 (This deletes the detail from the database)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            // Find the detail by its id
            var detail = await _context.Detail.FindAsync(id);
            if (detail != null)
            {
                // Remove the detail from the database
                _context.Detail.Remove(detail);
            }

            // Save the changes to the database
            await _context.SaveChangesAsync();
            // After deleting, redirect to the list of all details
            return RedirectToAction(nameof(Index));
        }

        // This checks if a detail with a specific id exists
        private bool DetailExists(int id)
        {
            return _context.Detail.Any(e => e.Id == id);
        }
    }
}
