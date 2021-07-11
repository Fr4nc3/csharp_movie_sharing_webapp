using MovieSharing.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MovieSharing.Pages
{
    public class BasePageModel : PageModel
    {
        /// <summary>
        /// Gets the context.
        /// </summary>
        /// <value>The context.</value>
        protected MovieSharingContext _context { get; }

        /// <summary>
        /// The decoded claims
        /// </summary>
        private DecodedClaims _decodedClaims = null;

        /// <summary>
        /// Gets the authenticated user information.
        /// </summary>
        /// <value>The authenticated user information.</value>
        public DecodedClaims AuthenticatedUserInfo
        {
            get
            {
                if (_decodedClaims == null)
                {
                    _decodedClaims = new DecodedClaims(this.User);
                }
                return _decodedClaims;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BasePageModel"/> class.
        /// </summary>
        public BasePageModel(MovieSharingContext context)
        {
            _context = context;
        }
    }
}
