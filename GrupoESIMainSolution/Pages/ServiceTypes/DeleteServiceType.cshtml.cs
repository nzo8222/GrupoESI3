using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using GrupoESIModels.Models;
using GrupoESIUtility;
using GrupoESIDataAccess.Repository.IRepository;

namespace GrupoESINuevo
{
    [Authorize(Roles = SD.AdminEndUser)]
    public class DeleteServiceTypeModel : PageModel
    {
        private readonly IServiceTypeRepository _ServiceTypeRepo;
        private readonly IQuotationRepository _QuotationRepository;
        private readonly IServiceRepository _ServiceRepository;
        private readonly IOrderDetailsRepository _OrderDetailsRepository;
        private readonly ITaskRepository _TaskRepository;
        private readonly IMaterialRepository _MaterialRepository;
        private readonly IPictureRepository _PictureRepository;

        public DeleteServiceTypeModel(IServiceTypeRepository ServiceTypeRepository,
                                      IServiceRepository ServiceRepository,
                                      IOrderDetailsRepository OrderDetailsRepository,
                                      IQuotationRepository QuotationRepository,
                                      ITaskRepository TaskRepository,
                                      IMaterialRepository materialRepository,
                                      IPictureRepository pictureRepository)
        {
            _ServiceTypeRepo = ServiceTypeRepository;
            _ServiceRepository = ServiceRepository;
            _OrderDetailsRepository = OrderDetailsRepository;
            _QuotationRepository = QuotationRepository;
            _TaskRepository = TaskRepository;
            _MaterialRepository = materialRepository;
            _PictureRepository = pictureRepository;
        }

        [BindProperty]
        public ServiceType ServiceType { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid serviceTypeId)
        {
            if (serviceTypeId == null)
            {
                return NotFound();
            }
           
            ServiceType =  _ServiceTypeRepo.FirstOrDefault(m => m.Id == serviceTypeId);



            if (ServiceType == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ServiceType.Id == null)
                return NotFound();

            DeleteServiceTypeWithAllItsRelatedModels();

            return RedirectToPage("./IndexServiceType");
        }

        private void DeleteServiceTypeWithAllItsRelatedModels()
        {
            ServiceType = _ServiceTypeRepo.FirstOrDefault(s => s.Id == ServiceType.Id);

            if (ServiceType != null)
            {
                LoadAndDeleteServicesRelatedToThisServiceType();
                _ServiceTypeRepo.Remove(ServiceType);
                _ServiceTypeRepo.Save();
            }
        }

        private void LoadAndDeleteServicesRelatedToThisServiceType()
        {
            IEnumerable<Service> lstServicios = _ServiceRepository.GetAll(s => s.ServiceTypeId == ServiceType.Id, includeProperties: "serviceType");
            foreach (var service in lstServicios)
            {
                LoadAllOrderDetailsRelatedToThisService(service);

                _ServiceRepository.Remove(service);
                _ServiceRepository.Save();
            }
        }

        private void LoadAllOrderDetailsRelatedToThisService(Service service)
        {
            var orderDetailsLocal = _OrderDetailsRepository.GetAll(s => s.ServiceId == service.ID, includeProperties: "Order,Service");
            foreach (var orderDetails in orderDetailsLocal)
            {
                LoadAndRemoveAllQuotationsRelatedToThisOrderDetails(orderDetails);

                _OrderDetailsRepository.Remove(orderDetails);
            }
        }

        private void LoadAndRemoveAllQuotationsRelatedToThisOrderDetails(OrderDetails orderDetails)
        {
            var quotationLocal = _QuotationRepository.FirstOrDefault(s => s.OrderDetails.Id == orderDetails.Id, includeProperties: "OrderDetailsModel,Tasks");

            foreach (var task in quotationLocal.Tasks)
            {
                LoadAndRemoveAllMaterialRelatedToThisTask(task);
                LoadAndRemoveAllPicturesRelatedToThisTask(task);
                _TaskRepository.Remove(task);
            }

            if (quotationLocal != null)
            {
                _QuotationRepository.Remove(quotationLocal);
            }
        }

        private void LoadAndRemoveAllPicturesRelatedToThisTask(TaskModel task)
        {
            var lstPictures = _PictureRepository.GetAll(s => s.TaskModelId == task.Id);
            foreach (var picture in lstPictures)
            {
                _PictureRepository.Remove(picture);
            }
        }

        private void LoadAndRemoveAllMaterialRelatedToThisTask(TaskModel task)
        {
            var lstMaterial = _MaterialRepository.GetAll(m => m.TaskModelId == task.Id);
            foreach (var mat in lstMaterial)
            {
                _MaterialRepository.Remove(mat);
            }
        }
    }
}
