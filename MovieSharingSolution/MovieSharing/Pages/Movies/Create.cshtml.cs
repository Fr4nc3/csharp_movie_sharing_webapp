using MovieSharing.Data;
using MovieSharing.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace MovieSharing.Pages.Movies
{
    public class CreateModel : BasePageModel
    {

        public CreateModel(MovieSharingContext context) : base(context)
        {
        }
        public SelectList Categories { get; set; }
        public string email { get; set; }
        public string name { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {

            Categories = new SelectList(await _context.Category.ToListAsync(), nameof(Category.Name), nameof(Category.Name));
            email = Request.Cookies["ImpersonateEmail"] ?? User.EmailAddress();
            name = Request.Cookies["ImpersonateName"] ?? User.DisplayName();
            return Page();
        }

        [BindProperty]
        public Movie Movie { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _context.Movie.Add(Movie);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
