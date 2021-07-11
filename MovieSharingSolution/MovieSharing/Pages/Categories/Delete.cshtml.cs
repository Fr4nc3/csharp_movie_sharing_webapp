using MovieSharing.Data;
using MovieSharing.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace MovieSharing.Pages.Categories
{
    public class DeleteModel : BasePageModel
    {

        public DeleteModel(MovieSharingContext context) : base(context)
        {
        }

        [BindProperty]
        public Category Category { get; set; }

        public bool CanBeDeleted { get; set; } = true;

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
            CanBeDeleted = movies.Count() == 0;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Category = await _context.Category.FindAsync(id);

            if (Category != null)
            {
                var movies = await _context.Movie.Where(x => x.Category == Category.Name).ToListAsync();
                CanBeDeleted = movies.Count() == 0;
                if (CanBeDeleted)
                {
                    _context.Category.Remove(Category);
                    await _context.SaveChangesAsync();
                }
            }

            return RedirectToPage("./Index");
        }
    }
}
