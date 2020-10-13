using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrupoESIDataAccess;
using GrupoESIModels.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GrupoESINuevo.Pages.Employees
{
    public class AddQuotationToEmployeeModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public AddQuotationToEmployeeModel(ApplicationDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public AddQuotationToEmployeeVM _AddQuotationToEmployeeVM { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? quotationId = null)
        {
            if (quotationId == null)
            {

                return Page();
            }
            _AddQuotationToEmployeeVM = new AddQuotationToEmployeeVM();

            _AddQuotationToEmployeeVM.QuotationIdLocal = (Guid)quotationId;
            var quotationLocal = await _context.Quotation
                                                         .Include(q => q.OrderDetailsModel)
                                                            .ThenInclude(od => od.Service)
                                                                .ThenInclude(s => s.ApplicationUser)
                                                         .FirstOrDefaultAsync(q => q.Id == quotationId);
            
            var employer = await _context.ApplicationUser
                                                       .FirstOrDefaultAsync(a => a.Id == quotationLocal.OrderDetailsModel.Service.ApplicationUser.Id);
            var localEmployeeUserLst = await _context.Employee
                                                              .Include(e => e.ServiceLst)
                                                              .Include(e => e.EmployedBy)
                                                              .Where(e => e.EmployedBy == employer)
                                                              .ToListAsync();

            _AddQuotationToEmployeeVM.OrderDetailsId = quotationLocal.OrderDetailsModel.Id;


            foreach (var item in localEmployeeUserLst)
            {
                if (item.EmployedBy == employer)
                {
                    _AddQuotationToEmployeeVM.EmployeeUsrLst.Add(item);
                }
            }

            return Page();
        }
    }
}