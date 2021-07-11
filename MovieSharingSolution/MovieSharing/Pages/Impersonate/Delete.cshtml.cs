using MovieSharing.Data;
using MovieSharing.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace MovieSharing.Pages.Impersonate
{
    public class DeleteModel : BasePageModel
    {

        public DeleteModel(MovieSharingContext context) : base(context)
        {
        }


        [BindProperty]
        public Imperson Imperson { get; set; }
        public bool CanBeDeleted { get; set; } = true;
        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Imperson = await _context.Imperson.FirstOrDefaultAsync(m => m.ID == id);

            if (Imperson == null)
            {
                return NotFound();
            }
            var movies = await _context.Movie.Where(x => x.OwnerEmailAddress == Imperson.Email || x.SharedWithEmailAddress == Imperson.Email).ToListAsync();
            CanBeDeleted = movies.Count() == 0;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Imperson = await _context.Imperson.FindAsync(id);

            if (Imperson != null)
            {
                _context.Imperson.Remove(Imperson);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
