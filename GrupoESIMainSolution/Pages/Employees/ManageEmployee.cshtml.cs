using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GrupoESIDataAccess;
using GrupoESIDataAccess.Queries;
using GrupoESIModels.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GrupoESINuevo.Pages.Employees
{
    public class ManageEmployeeModel : PageModel
    {

        private readonly IQueries _queries;
        public ManageEmployeeModel(IQueries queries)
        {
            _queries = queries;
        }
        [BindProperty]
        public IList<EmployeeUser> EmployeeUsrLst { get; set; }
        public async Task<IActionResult> OnGetAsync(string employersId = null)
        {
            if (employersId == null)
            {
                return Page();
            }
            LoadEmployeeLst(employersId);
            return Page();
        }

        private void LoadEmployeeLst(string employersId)
        {
            var localEmployeeUserLst = _queries.GetLstEmployeesIncludeServiceList();
            EmployeeUsrLst = new List<EmployeeUser>();
            var employer = _queries.GetApplicationUserIncludeServiceLst(employersId.ToString());
            foreach (var item in localEmployeeUserLst)
            {
                if (item.EmployedBy == employer)
                {
                    EmployeeUsrLst.Add(item);
                }
            }
        }
    }
}