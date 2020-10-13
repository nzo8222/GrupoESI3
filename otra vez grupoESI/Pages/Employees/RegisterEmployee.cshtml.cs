using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using GrupoESIDataAccess;
using GrupoESIModels.Models;
using GrupoESINuevo.Data;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace GrupoESINuevo.Pages.Employees
{
    public class RegisterEmployeeModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<RegisterEmployeeModel> _logger;
        private readonly IEmailSender _emailSender;

        RoleManager<IdentityRole> _roleManager;
        ApplicationDbContext _db;
        public RegisterEmployeeModel(UserManager<IdentityUser> userManager,
                                      ILogger<RegisterEmployeeModel> logger,
                                      IEmailSender emailSender,
                                      RoleManager<IdentityRole> roleManager,
                                      ApplicationDbContext db)
        {
            _userManager = userManager;
            _logger = logger;
            _emailSender = emailSender;
            _roleManager = roleManager;
            _db = db;
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

                //lista de servicios del proveedor
                //agregar esos servicios
                var Employer = _db.ApplicationUser
                                                  .Include(a => a.ServiceLst)
                                                  .FirstOrDefault(a => a.Id == EmployersId);

                Input.serviceLst = Employer.ServiceLst;
                Input.idEmpleador = Employer.Id;
                return Page();
            }
            return Page();
        }
    }
}