using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using GrupoESIDataAccess;
using GrupoESIModels.Models;
using GrupoESIModels.ViewModels;
using GrupoESINuevo.Data;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GrupoESINuevo.Pages.Employees
{
    [Authorize]
    public class EmployeeOrderIndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public EmployeeOrderIndexModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public EmployeeIndexVM _employeeIndexVM { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            var userId = claim.Value;
            _employeeIndexVM = new EmployeeIndexVM()
            {
                EmployeeLocal = await _db.Employee
                                                    .Include(e => e.QuotationLst)
                                                    .Include(e => e.EmployedBy)
                                                    .FirstOrDefaultAsync(e => e.Id == userId),
                orderDetailsList = new List<OrderDetails>()
            };
            foreach (var item in _employeeIndexVM.EmployeeLocal.QuotationLst)
            {
                var orderDetailsLocal = _db.Quotation.Include(q => q.OrderDetailsModel).FirstOrDefault(q => q == item);
                _employeeIndexVM.orderDetailsList.Add(orderDetailsLocal.OrderDetailsModel);
            }
            
            return Page();
        }
    }
}