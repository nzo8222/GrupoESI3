using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GrupoESI.Pages.PredefinedTasks
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
