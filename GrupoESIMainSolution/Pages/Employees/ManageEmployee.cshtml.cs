using System.Collections.Generic;
using GrupoESIDataAccess.Queries;
using GrupoESIModels.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GrupoESIModels.ViewModels;
namespace GrupoESI.Pages.Employees
{
    public class ManageEmployeeModel : PageModel
    {

        private readonly IQueries _queries;
        public ManageEmployeeModel(IQueries queries)
        {
            _queries = queries;
        }
        [BindProperty]
        public ManageEmployeesVM _ManageEmployeesVM { get; set; }
        public IActionResult OnGetAsync(string employersId = null)
        {
            if (employersId == null)
            {
                return Page();
            }
            _ManageEmployeesVM = new ManageEmployeesVM();
            _ManageEmployeesVM.EmployerId = employersId;
            LoadEmployeeLst(employersId);
            return Page();
        }

        private void LoadEmployeeLst(string employersId)
        {
            var localEmployeeUserLst = _queries.GetLstEmployeesIncludeServiceList();
            _ManageEmployeesVM.EmployeeUsrLst = new List<EmployeeUser>();
            var employer = _queries.GetApplicationUserIncludeServiceLst(employersId.ToString());
            foreach (var item in localEmployeeUserLst)
            {
                if (item.EmployedBy == employer)
                {
                    _ManageEmployeesVM.EmployeeUsrLst.Add(item);
                }
            }
        }
    }
}