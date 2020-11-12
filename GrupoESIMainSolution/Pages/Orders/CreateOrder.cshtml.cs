using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.UI.Services;
using GrupoESIModels.ViewModels;
using GrupoESIModels.Models;
using GrupoESIUtility;
using GrupoESIDataAccess.Queries;
using GrupoESIDataAccess.Repository.IRepository;

namespace GrupoESI
{
    [Authorize(Roles = SD.AdminEndUser)]
    public class CreateOrderModel : PageModel
    {
        private readonly IEmailSender _emailSender;
        private readonly IQueries _queries;
        private readonly IQuotationRepository _quotationRepository;
        private readonly IOrderDetailsRepository _orderDetailsRepository;
        private readonly IOrderRepository _orderRepository;

        public CreateOrderModel(IEmailSender emailSender, 
                                IQueries queries,
                                IQuotationRepository quotationRepository,
                                IOrderRepository orderRepository,
                                IOrderDetailsRepository orderDetailsRepository)
        {
            _queries = queries;
            _emailSender = emailSender;
            _quotationRepository = quotationRepository;
            _orderDetailsRepository = orderDetailsRepository;
            _quotationRepository = quotationRepository;
            _orderRepository = orderRepository;
        }
        [BindProperty]
        public OrderAndOrderDetailsVM _OrderAndOrderDetailsVM { get; set; }
        public async Task<IActionResult> OnGet(Guid serviceId)
        {
            if (serviceId == null)
            {
                return Page();
            }
            LoadModels(serviceId);

            return Page();
        }

        private void LoadModels(Guid serviceId)
        {
            _OrderAndOrderDetailsVM = new OrderAndOrderDetailsVM()
            {
                OrderModel = new Order(),
                OrderDetailsModel = new OrderDetails()
            };

            _OrderAndOrderDetailsVM.OrderDetailsModel.Order = _OrderAndOrderDetailsVM.OrderModel;
            _OrderAndOrderDetailsVM.OrderDetailsModel.Service = _queries.GetServiceIncludeApplicationUserFirstOrDefault(serviceId);
            _OrderAndOrderDetailsVM.serviceIdVM = serviceId;
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (_OrderAndOrderDetailsVM.OrderModel.Direccion == null)
            {
                return Page();
            }
            if (_OrderAndOrderDetailsVM.OrderModel.Concepto == null)
            {
                return Page();
            }
            AssignAtributesToModels();
            Quotation quotationLocal = InitializeQuotationModel();
            SaveModels(quotationLocal);
            
            await _emailSender.SendEmailAsync(_OrderAndOrderDetailsVM.OrderDetailsModel.Service.ApplicationUser.Email, "Se te a asignado una orden",
                $"Checa tu cuenta de la aplicacion grupo ESI se te a asignado una orden");
            return RedirectToPage("/ManageOrders/OrderIndexAdmin");
        }

        private void SaveModels(Quotation quotationLocal)
        {
            _quotationRepository.Add(quotationLocal);
            _orderDetailsRepository.Add(_OrderAndOrderDetailsVM.OrderDetailsModel);
            _orderRepository.Add(_OrderAndOrderDetailsVM.OrderModel);
            try
            {
                _queries.SaveChanges();
            }
            catch (Exception ex)
            {

            }
        }

        private Quotation InitializeQuotationModel()
        {
            var quotationLocal = new Quotation();
            quotationLocal.Tasks = new List<TaskModel>();
            quotationLocal.OrderDetails = _OrderAndOrderDetailsVM.OrderDetailsModel;
            return quotationLocal;
        }

        private void AssignAtributesToModels()
        {
            _OrderAndOrderDetailsVM.OrderModel.OrderDate = DateTime.Now;
            _OrderAndOrderDetailsVM.OrderDetailsModel.Service = _queries.GetServiceIncludeApplicationUserServiceTypeFirstOrDefault(_OrderAndOrderDetailsVM.serviceIdVM);
            _OrderAndOrderDetailsVM.OrderModel.EstadoDelPedido = SD.EstadoSinCotizar;
            _OrderAndOrderDetailsVM.OrderDetailsModel.Order = _OrderAndOrderDetailsVM.OrderModel;
            _OrderAndOrderDetailsVM.OrderDetailsModel.Status = SD.EstadoSinCotizar;
        }
    }
}
