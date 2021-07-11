using MovieSharing.Data;
using MovieSharing.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MovieSharing.Pages.Impersonate
{
    public class CreateModel : BasePageModel
    {

        public CreateModel(MovieSharingContext context) : base(context)
        {
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Imperson Imperson { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Imperson.Add(Imperson);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
