using MovieSharing.Data;
using MovieSharing.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace MovieSharing.Pages.Impersonate
{
    public class DetailsModel : BasePageModel
    {

        public DetailsModel(MovieSharingContext context) : base(context)
        {
        }

        public Imperson Imperson { get; set; }

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
            return Page();
        }
    }
}
