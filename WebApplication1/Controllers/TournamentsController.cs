using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DJ_s_League.Models;
using WebApplication1.Data;

namespace DJ_League.Controllers
{
    // Controller for managing tournaments
    public class TournamentsController : Controller
    {
        // Database context for accessing the tournament data
        private readonly ApplicationDbContext _context;

        // Constructor that initializes the database context
        public TournamentsController(ApplicationDbContext context)
        {
            _context = context; // Store the context for later use
        }

        // GET: Tournaments - Display a list of all tournaments
        public async Task<IActionResult> Index()
        {
            // Retrieve all tournaments and include the associated game data
            var applicationDbContext = _context.Tournament.Include(t => t.game);
            return View(await applicationDbContext.ToListAsync()); // Return the list to the view
        }

        // GET: Tournaments/Details/5 - Display details for a specific tournament
        public async Task<IActionResult> Details(int? id)
        {
            // If no ID is provided, return a "not found" error
            if (id == null)
            {
                return NotFound();
            }

            // Find the tournament by ID, including the associated game data
            var tournament = await _context.Tournament
                .Include(t => t.game)
                .FirstOrDefaultAsync(m => m.Id == id);
            // If the tournament is not found, return a "not found" error
            if (tournament == null)
            {
                return NotFound();
            }

            // Return the tournament details to the view
            return View(tournament);
        }

        // GET: Tournaments/Create - Show the form to create a new tournament
        public IActionResult Create()
        {
            // Populate the dropdown list for the GameId field (games available for the tournament)
            ViewData["GameId"] = new SelectList(_context.Game, "Id", "Id");
            return View(); // Show the form to create a new tournament
        }

        // POST: Tournaments/Create - Handle the form submission to create a new tournament
        [HttpPost]
        [ValidateAntiForgeryToken] // Protect against CSRF attacks
        public async Task<IActionResult> Create([Bind("Id,GameId,Name,Description")] Tournament tournament)
        {
            // Check if the form data is valid
            if (ModelState.IsValid)
            {
                _context.Add(tournament); // Add the new tournament to the database
                await _context.SaveChangesAsync(); // Save changes to the database
                return RedirectToAction(nameof(Index)); // Redirect to the list of tournaments
            }
            // If the form data is invalid, show the form again with the entered data
            ViewData["GameId"] = new SelectList(_context.Game, "Id", "Id", tournament.GameId);
            return View(tournament);
        }

        // GET: Tournaments/Edit/5 - Show the form to edit an existing tournament
        public async Task<IActionResult> Edit(int? id)
        {
            // If no ID is provided, return a "not found" error
            if (id == null)
            {
                return NotFound();
            }

            // Find the tournament by ID
            var tournament = await _context.Tournament.FindAsync(id);
            // If the tournament is not found, return a "not found" error
            if (tournament == null)
            {
                return NotFound();
            }
            // Populate the dropdown list for the GameId field (the game the tournament is associated with)
            ViewData["GameId"] = new SelectList(_context.Game, "Id", "Id", tournament.GameId);
            return View(tournament); // Return the form with the current tournament data
        }

        // POST: Tournaments/Edit/5 - Handle the form submission to update an existing tournament
        [HttpPost]
        [ValidateAntiForgeryToken] // Protect against CSRF attacks
        public async Task<IActionResult> Edit(int id, [Bind("Id,GameId,Name,Description")] Tournament tournament)
        {
            // Ensure the ID in the URL matches the ID in the form data
            if (id != tournament.Id)
            {
                return NotFound(); // If they don't match, return a "not found" error
            }

            // Check if the form data is valid
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tournament); // Update the tournament in the database
                    await _context.SaveChangesAsync(); // Save changes to the database
                }
                catch (DbUpdateConcurrencyException) // Handle concurrency issues if the data has been changed by someone else
                {
                    // If the tournament no longer exists, return a "not found" error
                    if (!TournamentExists(tournament.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw; // Rethrow the error if it is a different issue
                    }
                }
                return RedirectToAction(nameof(Index)); // Redirect back to the list of tournaments
            }
            // If the form data is invalid, show the form again with the entered data
            ViewData["GameId"] = new SelectList(_context.Game, "Id", "Id", tournament.GameId);
            return View(tournament);
        }

        // GET: Tournaments/Delete/5 - Show confirmation page to delete a tournament
        public async Task<IActionResult> Delete(int? id)
        {
            // If no ID is provided, return a "not found" error
            if (id == null)
            {
                return NotFound();
            }

            // Find the tournament by ID, including the associated game data
            var tournament = await _context.Tournament
                .Include(t => t.game)
                .FirstOrDefaultAsync(m => m.Id == id);
            // If the tournament is not found, return a "not found" error
            if (tournament == null)
            {
                return NotFound();
            }

            // Return the confirmation view for deletion
            return View(tournament);
        }

        // POST: Tournaments/Delete/5 - Handle the actual deletion of a tournament
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken] // Protect against CSRF attacks
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            // Find the tournament by ID
            var tournament = await _context.Tournament.FindAsync(id);
            // If the tournament exists, remove it from the database
            if (tournament != null)
            {
                _context.Tournament.Remove(tournament);
            }

            await _context.SaveChangesAsync(); // Save changes to the database
            return RedirectToAction(nameof(Index)); // Redirect back to the list of tournaments
        }

        // Helper method to check if a tournament exists by ID
        private bool TournamentExists(int id)
        {
            return _context.Tournament.Any(e => e.Id == id); // Check if any tournament has the given ID
        }
    }
}
