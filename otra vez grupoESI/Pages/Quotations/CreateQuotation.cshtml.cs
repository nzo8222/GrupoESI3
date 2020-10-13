using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity.UI.Services;
using GrupoESIModels.ViewModels;
using GrupoESIModels.Models;
using GrupoESIUtility;
using GrupoESIDataAccess.Queries;

namespace GrupoESINuevo
{
    public class CreateQuotationModel : PageModel
    {

        private readonly IEmailSender _emailSender;
        private readonly IQueries _iqueries;

        public CreateQuotationModel(IEmailSender emailSender,
                                    IQueries queries)
        {
            _emailSender = emailSender;
            _iqueries = queries;
        }
        [BindProperty]
        public QuotationTaskMaterialVM _QuotationTaskMaterialVM { get; set; }
        public IActionResult OnGet(Guid orderDetailsId)
        {
            if (orderDetailsId == null || orderDetailsId.ToString() == "00000000-0000-0000-0000-000000000000")
            {
                return NotFound();
            }
            LoadQuotation(orderDetailsId);
            LoadSameUserServices(orderDetailsId);
            GetEmployees();
            return Page();
        }

        private void LoadQuotation(Guid orderDetailsId)
        {
            _QuotationTaskMaterialVM = new QuotationTaskMaterialVM();
            _QuotationTaskMaterialVM.orderDetailsId = orderDetailsId;
            _QuotationTaskMaterialVM.QuotationModel = _iqueries.GetQuotationWithOrderDetailsOrdersTasksListMaterialFirstOrDefault(orderDetailsId);
        }

        private void LoadSameUserServices(Guid orderDetailsId)
        {
            OrderDetails userOD = _iqueries.GetOrderDetailsWithOrderServiceApplicationUser(orderDetailsId);
            List<OrderDetails> orderDetailsServicesSameUser = _iqueries.GetListOrderDetailsWithOrderServiceApplicationUserFromSameUser(userOD);

            if (orderDetailsServicesSameUser == null)
                orderDetailsServicesSameUser = new List<OrderDetails>();

            foreach (var item in orderDetailsServicesSameUser)
            {
                _QuotationTaskMaterialVM.lstOrderDetailsSameUserServices.Add(item);
            }
        }

        private void GetEmployees()
        {
            List<EmployeeUser> employeeLst = _iqueries.GetEmployeesAssosiatedToThisQuotation();
            foreach (var item in employeeLst)
            {
                foreach (var item2 in item.QuotationLst)
                {
                    if (item2 == _QuotationTaskMaterialVM.QuotationModel)
                    {
                        _QuotationTaskMaterialVM.lstEmployees.Add(item);
                    }
                }
            }
        }


        public async Task<IActionResult> OnPostEmployeeFinishedQuotationAsync()
        {
            if (_QuotationTaskMaterialVM.QuotationModel.Description == null)
            {
                return RedirectToPage("CreateQuotation", new { orderDetailsId = _QuotationTaskMaterialVM.QuotationModel.OrderDetailsModel.Id });
            }
            var quotation = _iqueries.GetQuotationByQuotationId(_QuotationTaskMaterialVM.QuotationModel.Id);
            if (quotation.Tasks.Count == 0)
            {
                return RedirectToPage("CreateQuotation", new { orderDetailsId = _QuotationTaskMaterialVM.QuotationModel.OrderDetailsModel.Id });
            }
            quotation.Description = _QuotationTaskMaterialVM.QuotationModel.Description;
            try
            {
                await _iqueries.SaveChangesAsync();
            }
            catch (Exception ex)
            {

            }
            return RedirectToPage("CreateQuotation", new { orderDetailsId = _QuotationTaskMaterialVM.QuotationModel.OrderDetailsModel.Id });
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (_QuotationTaskMaterialVM.QuotationModel.Description == null)
            {
                return RedirectToPage("CreateQuotation", new { orderDetailsId = _QuotationTaskMaterialVM.QuotationModel });
            }
            var quotation = _iqueries.GetQuotationWithOrderDetailsOrdersTasksListMaterialFirstOrDefault(_QuotationTaskMaterialVM.QuotationModel.Id);
            if (quotation.Tasks.Count == 0)
            {
                return RedirectToPage("CreateQuotation", new { orderDetailsId = _QuotationTaskMaterialVM.QuotationModel.OrderDetailsModel.Id });
            }
            SetQuotationForPosting(quotation);
            try
            {
                await _emailSender.SendEmailAsync(SD.AdminEmail, "El proveedor terminó la cotizacion",
               $"La cotizacion en el domicilio '{quotation.OrderDetailsModel.Order.Direccion}' fue terminada");
                _iqueries.SaveChanges();
            }
            catch (Exception ex)
            {

            }

            return RedirectToPage("IndexQuotation");
        }

        private void SetQuotationForPosting(Quotation quotation)
        {
            quotation.Description = _QuotationTaskMaterialVM.QuotationModel.Description;
            quotation.FechaGuardadoCotizacion = DateTime.Now;
            var order = _iqueries.GetOrderByOrderId(quotation.OrderDetailsModel.Order.Id);
            quotation.OrderDetailsModel.Status = SD.EstadoCotizado;
            order.EstadoDelPedido = SD.EstadoCotizado;
        }

        public async Task<IActionResult> OnPostCheckArrivalToLocationAsync()
        {
            if (_QuotationTaskMaterialVM.QuotationModel.Id == null)
            {
                return Page();
            }
            var quotation = _iqueries.GetQuotationWithOrderDetailsServiceApplicationUserWhereQuotationIdEqualsId(_QuotationTaskMaterialVM.QuotationModel.Id);
            if (quotation != null)
            {
                try
                {

                    quotation.OrderDetailsModel.Status = SD.EstadoCotizando;

                    await _emailSender.SendEmailAsync(SD.AdminEmail, "El proveedor llego al domicilio",
                          $"El proveedor '{quotation.OrderDetailsModel.Service.ApplicationUser.CompanyName}' llego al domicilio");
                    quotation.FechaGuardadoCotizacion = DateTime.Now;
                    _iqueries.SaveChanges();
                }
                catch (Exception ex)
                {

                }

            }
            return RedirectToPage("CreateQuotation", new { orderDetailsId = quotation.OrderDetailsModel.Id });
        }
    }
}