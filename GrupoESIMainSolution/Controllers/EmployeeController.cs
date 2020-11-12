using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using GrupoESIDataAccess.Queries;
using GrupoESIModels.Models;
using GrupoESIModels.ViewModels;
using GrupoESIUtility;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;

namespace GrupoESI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly IQueries _queries;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<EmployeeController> _logger;
        private readonly IEmailSender _emailSender;
        RoleManager<IdentityRole> _roleManager;
        public EmployeeController(UserManager<IdentityUser> userManager,
                                                ILogger<EmployeeController> logger,
                                                IEmailSender emailSender,
                                                RoleManager<IdentityRole> roleManager,
                                                IQueries queries)
        {
            _userManager = userManager;
            _logger = logger;
            _emailSender = emailSender;
            _roleManager = roleManager;
            _queries = queries;
        }
        [HttpGet]
        [Route("GetEmployeeOrderList")]
        public IActionResult GetOrderList(string employeeId)
        {
            var orderDetailsList = _queries.GetAllOrderDetailsIncludeOrderServiceQuotationWhereEmployeeIdEquals(employeeId);
            var orderVM = new List<OrderAdminIndexVM>();
            for (int i = 0; i < orderDetailsList.Count; i++)
            {
                var orderLocal = new OrderAdminIndexVM();
                orderLocal.orderId = orderDetailsList[i].Id.ToString();
                orderLocal.Concept = orderDetailsList[i].Order.Concepto;
                orderLocal.Address = orderDetailsList[i].Order.Direccion;
                orderLocal.Date = orderDetailsList[i].Order.OrderDate.ToString();
                orderLocal.StateOfTheOrder = orderDetailsList[i].Status;
                orderVM.Add(orderLocal);
            }
            return Json(new { data = orderVM });
        }
        [HttpGet]
        [Route("GetInquiryList")]
        public IActionResult GetInquiryList(string EmployerId)
        {
            if(EmployerId == null)
            {
                return NotFound();
            }
            var employeeLst = _queries.GetAllEmployeesWhereEmployedByIdEquals(EmployerId);
            var justEmployees = new List<EmployeeVM>();
            foreach (var employee in employeeLst)
            {
                var employeeLocal = new EmployeeVM();
                employeeLocal.Name = employee.Name;
                employeeLocal.Email = employee.Email;
                justEmployees.Add(employeeLocal);
            }
            return Json(new { data = justEmployees });
                //;
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
            await AddQuotationToEmployeesList(_AddQuotationToEmployeeControllerVM);

            try
            {
                _queries.SaveChanges();
            }
            catch (Exception ex)
            {

            }
            return Ok();
        }

        private async Task AddQuotationToEmployeesList(AddQuotationToEmployeeControllerVM _AddQuotationToEmployeeControllerVM)
        {
            var employee = _queries.GetEmployeeIncludeLstEmployedByFirstOrDefaultEmployeeIdEqualsEmployeeId(_AddQuotationToEmployeeControllerVM.idEmployee);
            var quotation = _queries.GetQuotationByQuotationId(_AddQuotationToEmployeeControllerVM.idQuotation);
            quotation.Employee = employee;
            _queries.SaveChanges();
            //employee.QuotationLst.Add(quotation);
            await _emailSender.SendEmailAsync(employee.UserName, "Se te asigno una orden",
                   $"Revisa tu cuenta de la aplicacion Grupo ESI se te asigno una orden");
        }

        [HttpPost]
        [Route("PostRegisterEmployee")]
        public async  Task<IActionResult> PostRegisterEmployee([FromBody] RegisterEmployeeVM _RegisterEmployee)
        {
            if (_RegisterEmployee.email == "")
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
            EmployeeUser _userEmployee = setEmployeesAttributes(_RegisterEmployee);
            addServicesToEmployee(_RegisterEmployee, _userEmployee);
            var result2 = await _userManager.CreateAsync(_userEmployee, _RegisterEmployee.pw);
            if (result2.Succeeded)
            {
                if (!await _roleManager.RoleExistsAsync(SD.EmployeeEndUser))
                {
                    await _roleManager.CreateAsync(new IdentityRole(SD.EmployeeEndUser));
                }
                await sendRegistrationCodeToEmployee(_RegisterEmployee, _userEmployee);

                return Ok();
            }
            foreach (var error in result2.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return NotFound();
        }

        private async Task sendRegistrationCodeToEmployee(RegisterEmployeeVM _RegisterEmployee, EmployeeUser _userEmployee)
        {
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
        }

        private void addServicesToEmployee(RegisterEmployeeVM _RegisterEmployee, EmployeeUser _userEmployee)
        {
            List<string> serviceList = _RegisterEmployee.listaServiciosId.Split(',').ToList();
            foreach (var serviceId in serviceList)
            {
                Guid id = Guid.Parse(serviceId);
                var service = _queries.GetServiceIncludeApplicationUserFirstOrDefault(id);
                _userEmployee.ServiceLst.Add(service);
            }
        }

        private EmployeeUser setEmployeesAttributes(RegisterEmployeeVM _RegisterEmployee)
        {
            var _userEmployee = new EmployeeUser();
            _userEmployee.UserName = _RegisterEmployee.email;
            _userEmployee.Email = _RegisterEmployee.email;
            _userEmployee.Name = _RegisterEmployee.Nombre;
            var Employer = _queries.GetApplicationUserIncludeServiceLst(_RegisterEmployee.idEmpleador);
            _userEmployee.EmployedBy = Employer;
            return _userEmployee;
        }
    }
}
