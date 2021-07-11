using MovieSharing.Common;
using MovieSharing.Data;
using MovieSharing.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieSharing.Pages.Movies
{
    // owner video page
    public class IndexModel : BasePageModel
    {

        public IndexModel(MovieSharingContext context) : base(context)
        {
        }

        public IList<Movie> Movie { get; set; } // my Movies

        public async Task OnGetAsync()
        {
            /// check the user is impersonate 
            string email = Request.Cookies["ImpersonateEmail"] ?? User.EmailAddress();
            Movie = await _context.Movie.Where(x => x.OwnerEmailAddress == email).ToListAsync();
        }
        /// <summary>
        ///  owner post action handler
        /// </summary>
        /// <param name="id"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public async Task<IActionResult> OnPostAsync(long? id, string action)
        {
            /// check the user is impersonate 
            string email = Request.Cookies["ImpersonateEmail"] ?? User.EmailAddress();
            string name = Request.Cookies["ImpersonateName"] ?? User.DisplayName();
            string redirect = await StatusResponse.ExecuteMovieAsync(_context, id, action, email, name, "./Index");

            if (redirect == "nofound")
            {
                return NotFound();
            }


            //return RedirectToPage(redirect);
            return Redirect("/Movies/Index?t=1");
        }

    }
}
