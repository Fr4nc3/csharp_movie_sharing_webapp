using MovieSharing.Data;
using MovieSharing.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieSharing.Pages.Categories
{
    public class IndexModel : BasePageModel
    {

        public IndexModel(MovieSharingContext context) : base(context)
        {
        }

        public IList<Category> Category { get; set; }

        public async Task OnGetAsync()
        {
            Category = await _context.Category.ToListAsync();
        }
    }
}
