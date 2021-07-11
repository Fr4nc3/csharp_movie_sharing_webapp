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
    /// <summary>
    /// available movies page
    /// </summary>
    public class AvailableModel : BasePageModel
    {

        public AvailableModel(MovieSharingContext context) : base(context)
        {
        }

        public IList<Movie> Movies { get; set; } // shared Movies
        public string email { get; set; }
        public async Task OnGetAsync()
        {
            /// check the user is impersonate 
            email = Request.Cookies["ImpersonateEmail"] ?? User.EmailAddress();
            Movies = await _context.Movie.Where(x => x.IsSharable && x.OwnerEmailAddress != email).ToListAsync();
        }
        /// <summary>
        /// User Action post
        /// </summary>
        /// <param name="id"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public async Task<IActionResult> OnPostAsync(long? id, string action)
        {
            /// check the user is impersonate 
            string email = Request.Cookies["ImpersonateEmail"] ?? User.EmailAddress();
            string name = Request.Cookies["ImpersonateName"] ?? User.DisplayName();
            string redirect = await StatusResponse.ExecuteMovieAsync(_context, id, action, email, name, "./Available");

            if (redirect == "nofound")
            {
                return NotFound();
            }
            // return RedirectToPage(redirect);
            return Redirect("/Movies/Available?t=1");
        }

    }
}
