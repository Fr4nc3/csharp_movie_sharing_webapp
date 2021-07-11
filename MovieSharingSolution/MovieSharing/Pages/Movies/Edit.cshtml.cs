using MovieSharing.Data;
using MovieSharing.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MovieSharing.Pages.Movies
{
    public class EditModel : BasePageModel
    {

        public EditModel(MovieSharingContext context) : base(context)
        {
        }

        public SelectList Categories { get; set; }

        [BindProperty]
        public Movie Movie { get; set; }
        public bool CanBeEdited { get; set; } = true;
        public string email { get; set; }
        public string name { get; set; }
        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            email = Request.Cookies["ImpersonateEmail"] ?? User.EmailAddress();
            name = Request.Cookies["ImpersonateName"] ?? User.DisplayName();
            Movie = await _context.Movie.FirstOrDefaultAsync(m => m.ID == id);

            if (Movie == null)
            {
                return NotFound();
            }
            Categories = new SelectList(await _context.Category.ToListAsync(), nameof(Category.Name), nameof(Category.Name));
            CanBeEdited = String.IsNullOrEmpty(Movie.SharedWithEmailAddress);
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Movie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(Movie.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool MovieExists(long id)
        {
            return _context.Movie.Any(e => e.ID == id);
        }
    }
}
