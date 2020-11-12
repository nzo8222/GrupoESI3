using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using GrupoESIDataAccess.Queries;
using GrupoESIModels.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GrupoESI.Pages.Employees
{
    public class RegisterEmployeeModel : PageModel
    {

        private readonly IQueries _queries;
        public RegisterEmployeeModel(IQueries queries)
        {
            _queries = queries;
        }
        [BindProperty]
        public InputModel Input { get; set; }
        public class InputModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            public string Name { get; set; }
            public string idEmpleador { get; set; }
            public List<Service> serviceLst { get; set; }
        }
        public async Task<IActionResult> OnGet(string EmployersId)
        {
           if(EmployersId != null)
            {
                Input = new InputModel()
                {
                    serviceLst = new List<Service>()
                };
                var Employer = _queries.GetApplicationUserIncludeServiceLst(EmployersId);
                Input.serviceLst = Employer.ServiceLst;
                Input.idEmpleador = Employer.Id;
                return Page();
            }
            return Page();
        }
    }
}