using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using GrupoESIDataAccess.Queries;
using GrupoESIModels.Models;
using GrupoESIModels.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GrupoESI.Pages.Employees
{
    [Authorize]
    public class EmployeeOrderIndexModel : PageModel
    {
        private readonly IQueries _queries;
        public EmployeeOrderIndexModel(IQueries queries)
        {
            _queries = queries;
        }
        [BindProperty]
        public EmployeeIndexVM _employeeIndexVM { get; set; }
        public IActionResult OnGetAsync()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            var userId = claim.Value;
            
            _employeeIndexVM = new EmployeeIndexVM()
            {
                EmployeeLocal = _queries.GetEmployeeIncludeLstEmployedByFirstOrDefaultEmployeeIdEqualsEmployeeId(userId),
                orderDetailsList = new List<OrderDetails>()
            };
            _employeeIndexVM.EmployeeId = userId;
            _employeeIndexVM.orderDetailsList = _queries.GetAllOrderDetailsIncludeOrderServiceQuotationWhereEmployeeIdEquals(_employeeIndexVM.EmployeeLocal.Id);
            //foreach (var quotation in _employeeIndexVM.EmployeeLocal.QuotationLst)
            //{
            //    var quotationLocal = _queries.GetQuotationIncludeOrderDetailsOrdersTasksListMaterialPicturesFirstOrDefault(quotation.OrderDetailsId);
            //    _employeeIndexVM.orderDetailsList.Add(quotationLocal.OrderDetailsModel);
            //}
            
            return Page();
        }
    }
}