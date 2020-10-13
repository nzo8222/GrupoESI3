using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using GrupoESIModels.ViewModels;
using GrupoESIDataAccess;
using GrupoESIUtility;

namespace GrupoESINuevo
{
    [Authorize(Roles = SD.AdminEndUser)]
    public class ManageOrdersIndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public ManageOrdersIndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        

        [BindProperty]
        public ManageOrdersVM _manageOrdersVM { get; set; }

        public IActionResult OnGet(Guid orderId)
        {
            if(orderId == null)
            {
                return Page();
            }

            _manageOrdersVM = new ManageOrdersVM()
            {
                OrderModel = _context.Order.FirstOrDefault(o => o.Id == orderId),

                OrderDetailsList = _context.OrderDetails.Include(od => od.Order)
                                                       .Include(od => od.Service)
                                                           .ThenInclude(s => s.serviceType)
                                                           .Where(od => od.Order.Id == orderId).ToList(),

                ListQuotations = _context.Quotation.Include(q => q.OrderDetailsModel)
                                                       .ThenInclude(od => od.Order)
                                                     .Include(q => q.Tasks)
                                                        .ThenInclude(t => t.ListMaterial)
                                                     .Where(q => q.OrderDetailsModel.Order.Id == orderId).ToList(),

                ListServices = new List<ManageServiceQuotationVM>(),

                ServiceModelIdList = new List<Guid>(),

                stringIds = ""
            };

           

            if(_manageOrdersVM.OrderDetailsList.Count == 0 )
            {
                return Page();
            }

            // lista de ID de servicios con el mismo tipo de servicio
            List<Guid> lstServiceDelmismoTipoDeLaOrden =    _context.ServiceModel
                                                                    .Include(c => c.serviceType)
                                                                    .Where(c => c.serviceType == _manageOrdersVM.OrderDetailsList[0].Service.serviceType)
                                                                    .Select(c => c.ID)
                                                                    .ToList();

            List<Guid> lstServiciosConCotizacion = new List<Guid>();

            foreach (var item in _manageOrdersVM.OrderDetailsList)
            {
                lstServiciosConCotizacion.Add(item.Service.ID);
            }

            lstServiceDelmismoTipoDeLaOrden = lstServiceDelmismoTipoDeLaOrden.FindAll(x => !lstServiciosConCotizacion.Contains(x));

            foreach (var item in lstServiceDelmismoTipoDeLaOrden)
            {
                var localVM = new ManageServiceQuotationVM()
                {
                    sendQuotation = false,
                    ServiceModel = _context.ServiceModel
                                                        .Include(s => s.ApplicationUser)
                                                        .FirstOrDefault(s => s.ID == item)
                };
                _manageOrdersVM.ListServices.Add(localVM);
            }
            
            return Page();
        }
      
    }
}
