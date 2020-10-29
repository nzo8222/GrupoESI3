using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GrupoESINuevo.Data;
using GrupoESIModels.Models;
using GrupoESIDataAccess;
using GrupoESIDataAccess.Repository.IRepository;

namespace GrupoESINuevo
{
    public class DeleteServiceModel : PageModel
    {

        private readonly IServiceRepository _serviceRepository;
        private readonly IOrderDetailsRepository _orderDetailsRepository;
        private readonly IQuotationRepository _quotationRepository;
        private readonly IMaterialRepository _materialRepository;

        public DeleteServiceModel(
                                  IServiceRepository service,
                                  IOrderDetailsRepository orderDetailsRepository,
                                  IQuotationRepository quotationRepository,
                                  IMaterialRepository materialRepository)
        {
            _serviceRepository = service;
            _orderDetailsRepository = orderDetailsRepository;
            _quotationRepository = quotationRepository;
            _materialRepository = materialRepository;
        }

        [BindProperty]
        public Service ServiceModel { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid serviceId)
        {
            if (serviceId == null)
            {
                return NotFound();
            }

            ServiceModel = _serviceRepository.FirstOrDefault(m => m.ID == serviceId, includeProperties: "serviceType,ApplicationUser");

            if (ServiceModel == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ServiceModel.ID == null)
            {
                return NotFound();
            }

            LoadServiceModelAndItsDependantModels();

            _serviceRepository.Remove(ServiceModel);
            _serviceRepository.Save();


            return RedirectToPage("./IndexService");
        }

        private void LoadServiceModelAndItsDependantModels()
        {
            ServiceModel = _serviceRepository.FirstOrDefault(s => s.ID == ServiceModel.ID);
            var orderDetailsLocal = _orderDetailsRepository.GetAll(od => od.Service.ID == ServiceModel.ID, includeProperties: "Order,Service");
            RemoveDependantModels(orderDetailsLocal);
        }

        private void RemoveDependantModels(IEnumerable<OrderDetails> orderDetailsLocal)
        {
            foreach (var item in orderDetailsLocal)
            {
                Quotation quotationLocal = LoadQuotation(item);
                if (quotationLocal != null)
                {
                    _quotationRepository.Remove(quotationLocal);
                }
                _orderDetailsRepository.Remove(item);
            }
        }

        private Quotation LoadQuotation(OrderDetails item)
        {
            var quotationLocal = _quotationRepository.FirstOrDefault(q => q.OrderDetails.Id == item.Id, includeProperties: "OrderDetailsModel,Tasks");

            LoadTask(quotationLocal);

            return quotationLocal;
        }

        private void LoadTask(Quotation quotationLocal)
        {
            foreach (var task in quotationLocal.Tasks)
            {
                task.ListMaterial = (List<Material>)_materialRepository.GetAll(m => m.TaskModelId == task.Id);
            }
        }
    }
}
