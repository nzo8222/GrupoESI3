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
using GrupoESIDataAccess.Queries;

namespace GrupoESINuevo
{
    [Authorize(Roles = SD.AdminEndUser)]
    public class ManageOrdersIndexModel : PageModel
    {
        private readonly IQueries _queries;
        public ManageOrdersIndexModel(IQueries queries)
        {
            _queries = queries;
        }
        [BindProperty]
        public ManageOrdersVM _manageOrdersVM { get; set; }

        public IActionResult OnGet(Guid orderId)
        {
            if (orderId == null)
            {
                return Page();
            }
            loadManageOrderIndexVM(orderId);
            if (_manageOrdersVM.OrderDetailsList.Count == 0)
            {
                return Page();
            }
            filterServiceListWithSameServiceTypeIdOfThatOrder();
            return Page();
        }

        private void filterServiceListWithSameServiceTypeIdOfThatOrder()
        {
            List<Guid> lstServiceWithSameServiceTypeIdFromOrder = _queries.GetLstServiceFromTheSameServiceTypeFromOrderServiceType(_manageOrdersVM.OrderDetailsList[0].Service.ServiceTypeId);
            List<Guid> lstServiceWithQuotation = new List<Guid>();
            foreach (var item in _manageOrdersVM.OrderDetailsList)
            {
                lstServiceWithQuotation.Add(item.Service.ID);
            }
            lstServiceWithSameServiceTypeIdFromOrder = lstServiceWithSameServiceTypeIdFromOrder.FindAll(x => !lstServiceWithQuotation.Contains(x));
            foreach (var serviceGuid in lstServiceWithSameServiceTypeIdFromOrder)
            {
                var localVM = new ManageServiceQuotationVM()
                {
                    sendQuotation = false,
                    ServiceModel = _queries.GetServiceIncludeApplicationUserFirstOrDefault(serviceGuid)
                };
                _manageOrdersVM.ListServices.Add(localVM);
            }
        }

        private void loadManageOrderIndexVM(Guid orderId)
        {
            _manageOrdersVM = new ManageOrdersVM()
            {
                OrderModel = _queries.GetOrderByOrderId(orderId),
                OrderDetailsList = _queries.GetLstOrderDetailsIncludeOrderServiceServiceTypeWhereOrderIdEqualsOrderId(orderId),
                ListQuotations = _queries.GetLstQuotationIncludeOrderDetailsOrderTaskListMaterialWhereOrderIdEqualsOrderId(orderId),
                ListServices = new List<ManageServiceQuotationVM>(),
                ServiceModelIdList = new List<Guid>(),
                stringIds = ""
            };
        }
    }
}
