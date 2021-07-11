using MovieSharing.Data;
using MovieSharing.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace MovieSharing.Pages.Categories
{
    public class EditModel : BasePageModel
    {

        public EditModel(MovieSharingContext context) : base(context)
        {
        }

        [BindProperty]
        public Category Category { get; set; }
        public bool CanBeEdited { get; set; } = true;
        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Category = await _context.Category.FirstOrDefaultAsync(m => m.ID == id);

            if (Category == null)
            {
                return NotFound();
            }
            var movies = await _context.Movie.Where(x => x.Category == Category.Name).ToListAsync();
            CanBeEdited = movies.Count() == 0;
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

            _context.Attach(Category).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(Category.ID))
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

        private bool CategoryExists(long id)
        {
            return _context.Category.Any(e => e.ID == id);
        }
    }
}
