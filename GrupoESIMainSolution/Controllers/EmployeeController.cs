using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using GrupoESIDataAccess;
using GrupoESIModels.Models;
using GrupoESIModels.ViewModels;
using GrupoESINuevo.Data;
using GrupoESIUtility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace GrupoESINuevo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<EmployeeController> _logger;
        private readonly IEmailSender _emailSender;
        RoleManager<IdentityRole> _roleManager;
        public EmployeeController(UserManager<IdentityUser> userManager,
                                                ILogger<EmployeeController> logger,
                                                IEmailSender emailSender,
                                                RoleManager<IdentityRole> roleManager,
                                                ApplicationDbContext context)
        {
            _userManager = userManager;
            _logger = logger;
            _emailSender = emailSender;
            _roleManager = roleManager;
            _context = context;
        }
        [HttpPost]
        [Route("PostAddQuotationToEmployee")]
        public async Task<IActionResult> PostAddQuotationToEmployee([FromBody] AddQuotationToEmployeeControllerVM _AddQuotationToEmployeeControllerVM)
        {
            if (_AddQuotationToEmployeeControllerVM.idEmployee == "")
            {
                return NotFound();
            }
            if (_AddQuotationToEmployeeControllerVM.idQuotation == null)
            {
                return NotFound();
            }
            var employee = await _context.Employee.FirstOrDefaultAsync(e => e.Id == _AddQuotationToEmployeeControllerVM.idEmployee);
            var quotation = await _context.Quotation.FirstOrDefaultAsync(q => q.Id == _AddQuotationToEmployeeControllerVM.idQuotation);
            employee.QuotationLst.Add(quotation);
            await _emailSender.SendEmailAsync(employee.UserName, "Se te asigno una orden",
                   $"Revisa tu cuenta de la aplicacion Grupo ESI se te asigno una orden");

            try
            {
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {

            }
            return Ok();
        }
        [HttpPost]
        [Route("PostRegisterEmployee")]
        public async  Task<IActionResult> PostRegisterEmployee([FromBody] RegisterEmployeeVM _RegisterEmployee)
        {
            if(_RegisterEmployee.email == "")
            {
                return NotFound();
            }
            if (_RegisterEmployee.Nombre == "")
            {
                return NotFound();
            }
            if (_RegisterEmployee.pw == "")
            {
                return NotFound();
            }
            if (_RegisterEmployee.idEmpleador == "")
            {
                return NotFound();
            }
            var _userEmployee = new EmployeeUser();
            _userEmployee.UserName = _RegisterEmployee.email;
            _userEmployee.Email = _RegisterEmployee.email;
            _userEmployee.Name = _RegisterEmployee.Nombre;
            var Employer = _context.ApplicationUser.FirstOrDefault(a => a.Id == _RegisterEmployee.idEmpleador);
            _userEmployee.EmployedBy = Employer;
            List<string> result = _RegisterEmployee.listaServiciosId.Split(',').ToList();
            foreach(var item in result)
            {
                var service = _context.ServiceModel.FirstOrDefault(s => s.ID.ToString() == item);
                _userEmployee.ServiceLst.Add(service);
            }
            var result2 = await _userManager.CreateAsync(_userEmployee, _RegisterEmployee.pw);
            if (result2.Succeeded)
            {
                if (!await _roleManager.RoleExistsAsync(SD.EmployeeEndUser))
                {
                    await _roleManager.CreateAsync(new IdentityRole(SD.EmployeeEndUser));
                }
                _logger.LogInformation("EmployedUser created a new account with password.");
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(_userEmployee);
                code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                var callbackUrl = Url.Page(
                    "/Account/ConfirmEmail",
                    pageHandler: null,
                    values: new { area = "Identity", userId = _userEmployee.Id, code = code },
                    protocol: Request.Scheme);

                await _emailSender.SendEmailAsync(_RegisterEmployee.email, "Confirm your email",
                    $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");
                await _userManager.AddToRoleAsync(_userEmployee, SD.EmployeeEndUser);

                return Ok();
            }
            foreach (var error in result2.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return NotFound();
        }
    }
}
