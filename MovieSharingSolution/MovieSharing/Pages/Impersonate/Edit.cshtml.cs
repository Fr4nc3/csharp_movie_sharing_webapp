using MovieSharing.Data;
using MovieSharing.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace MovieSharing.Pages.Impersonate
{
    public class EditModel : BasePageModel
    {

        public EditModel(MovieSharingContext context) : base(context)
        {
        }

        [BindProperty]
        public Imperson Imperson { get; set; }
        public bool CanBeEdited { get; set; } = true;
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

            _context.Attach(Imperson).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ImpersonExists(Imperson.ID))
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

        private bool ImpersonExists(long id)
        {
            return _context.Imperson.Any(e => e.ID == id);
        }
    }
}
