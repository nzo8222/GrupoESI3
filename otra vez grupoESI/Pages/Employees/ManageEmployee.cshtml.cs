using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrupoESIDataAccess;
using GrupoESIModels.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GrupoESINuevo.Pages.Employees
{
    public class ManageEmployeeModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public ManageEmployeeModel(ApplicationDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public IList<EmployeeUser> EmployeeUsrLst { get; set; }
        public async Task<IActionResult> OnGetAsync(Guid? employersId = null)
        {
            if (employersId == null)
            {
                
                return Page();
            }
            var localEmployeeUserLst = await _context.Employee.Include(e => e.ServiceLst).ToListAsync();
            EmployeeUsrLst = new List<EmployeeUser>();
            var employer = await _context.ApplicationUser.FirstOrDefaultAsync(a => a.Id == employersId.ToString());
            foreach (var item in localEmployeeUserLst)
            {
                if(item.EmployedBy == employer)
                {
                    EmployeeUsrLst.Add(item);
                }
            }
            
            return Page();
        }
    }
}