using MovieSharing.Data;
using MovieSharing.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace MovieSharing.Pages.Movies
{
    public class DeleteModel : BasePageModel
    {

        public DeleteModel(MovieSharingContext context) : base(context)
        {
        }

        [BindProperty]
        public Movie Movie { get; set; }
        public bool CanBeDeleted { get; set; } = true;
        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Movie = await _context.Movie.FirstOrDefaultAsync(m => m.ID == id);

            if (Movie == null)
            {
                return NotFound();
            }
            CanBeDeleted = String.IsNullOrEmpty(Movie.SharedWithEmailAddress);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Movie = await _context.Movie.FindAsync(id);

            if (Movie != null)
            {
                CanBeDeleted = String.IsNullOrEmpty(Movie.SharedWithEmailAddress);
                if (CanBeDeleted)
                {
                    _context.Movie.Remove(Movie);
                    await _context.SaveChangesAsync();
                }

            }

            return RedirectToPage("./Index");
        }
    }
}
