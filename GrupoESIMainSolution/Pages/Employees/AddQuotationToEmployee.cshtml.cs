using System;
using GrupoESIDataAccess.Queries;
using GrupoESIModels.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GrupoESINuevo.Pages.Employees
{
    public class AddQuotationToEmployeeModel : PageModel
    {
        private readonly IQueries _queries;
        public AddQuotationToEmployeeModel(IQueries queries)
        {
            _queries = queries;
        }
        [BindProperty]
        public AddQuotationToEmployeeVM _AddQuotationToEmployeeVM { get; set; }

        public IActionResult OnGetAsync(Guid? quotationId = null)
        {
            if (quotationId == null)
            {
                return Page();
            }
            _AddQuotationToEmployeeVM = new AddQuotationToEmployeeVM();

            _AddQuotationToEmployeeVM.QuotationIdLocal = (Guid)quotationId;
            var quotationLocal = _queries.GetQuoationIncludeOrderDetailsServiceApplicationUserFirstOrDefaultWhereQuotationIdEquals((Guid)quotationId);

            var employer = _queries.GetApplicationUserIncludeServiceLst(quotationLocal.OrderDetails.Service.ApplicationUser.Id);
                
            var localEmployeeUserLst = _queries.GetAllEmployeesIncludeServiceLstEmployedByWhereEmployedByIdEquals(employer.Id);
                
                 

            _AddQuotationToEmployeeVM.OrderDetailsId = quotationLocal.OrderDetails.Id;


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