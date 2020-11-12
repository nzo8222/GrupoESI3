using System;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GrupoESI
{
    public class PredefinedTaskIndexModel : PageModel
    {
        [BindProperty]
        public Guid _serviceId { get; set; }
        public IActionResult OnGet(Guid? serviceId = null)
        {
            if(serviceId == null)
            {
                return NotFound();
            }
            _serviceId = (Guid)serviceId;
            return Page();
        }
    }
}
