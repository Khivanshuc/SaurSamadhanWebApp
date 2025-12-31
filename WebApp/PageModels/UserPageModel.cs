using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace WebApp.PageModels
{
    public class UserPageModel : PageModel
    {
        [BindProperty]
        public long DistrictId { get; set; }

        public List<SelectListItem> Districts { get; set; }

        public void OnGet()
        {
            Districts = new List<SelectListItem>
        {
            new SelectListItem { Value = "1", Text = "District 1" },
            new SelectListItem { Value = "2", Text = "District 2" },
            new SelectListItem { Value = "3", Text = "District 3" }
            // Add more districts as needed
        };
        }
    }

}
