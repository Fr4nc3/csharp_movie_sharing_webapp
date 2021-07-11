using MovieSharing.Data;
using MovieSharing.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieSharing.Pages.Impersonate
{
    /// <summary>
    /// impersonate page
    /// </summary>
    public class IndexModel : BasePageModel
    {

        public IndexModel(MovieSharingContext context) : base(context)
        {
        }

        public IList<Imperson> Impersons { get; set; }
        public bool IsImpersonate { get; set; } = false;
        public async Task OnGetAsync()
        {
            string email = Request.Cookies["ImpersonateEmail"];
            if (!String.IsNullOrEmpty(email))
            {
                IsImpersonate = true;
            }
            Impersons = await _context.Imperson.ToListAsync();
        }
        /// <summary>
        /// Impersonate handler
        /// </summary>
        /// <param name="id">user id</param>
        /// <returns></returns>
        public async Task<IActionResult> OnPostAsync(long? id)
        {
            // null if id is null
            if (id == null)
            {
                return NotFound();
            }
            // if cookie exist is stop impersonation
            string email = Request.Cookies["ImpersonateEmail"];
            if (!String.IsNullOrEmpty(email))
            {
                Response.Cookies.Delete("ImpersonateEmail");
                Response.Cookies.Delete("ImpersonateName");
                return Redirect("/Impersonate/Index?t=1");
            }
            Imperson Imperson = await _context.Imperson.FirstOrDefaultAsync(m => m.ID == id);


            if (Imperson == null)
            {
                return NotFound();
            }
            // set cookies and start impersonation
            Response.Cookies.Append("ImpersonateEmail", Imperson.Email);
            Response.Cookies.Append("ImpersonateName", Imperson.Name);
            return Redirect("/Impersonate/Index?t=2");
        }
    }
}
