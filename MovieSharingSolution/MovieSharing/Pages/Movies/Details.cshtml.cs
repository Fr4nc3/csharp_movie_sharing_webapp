using MovieSharing.Data;
using MovieSharing.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace MovieSharing.Pages.Movies
{
    public class DetailsModel : BasePageModel
    {

        public DetailsModel(MovieSharingContext context) : base(context)
        {
        }

        public Movie Movie { get; set; }

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
            return Page();
        }
    }
}
