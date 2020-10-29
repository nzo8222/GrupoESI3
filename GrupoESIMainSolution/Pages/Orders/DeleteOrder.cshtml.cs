using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using GrupoESIModels.Models;
using GrupoESIDataAccess;
using GrupoESIUtility;
using GrupoESIDataAccess.Queries;
using GrupoESIDataAccess.Repository.IRepository;

namespace GrupoESINuevo
{
    [Authorize(Roles = SD.AdminEndUser)]
    public class DeleteOrderModel : PageModel
    {
        private readonly IQueries _queries;
        private readonly IOrderRepository _orderRepository;
        private readonly IQuotationRepository _quotationRepository;
        private readonly IOrderDetailsRepository _orderDetailsRepository;
        public DeleteOrderModel(IQueries queries,
                                IOrderRepository orderRepository,
                                IQuotationRepository quotationRepository,
                                IOrderDetailsRepository orderDetailsRepository)
        {
            _queries = queries;
            _orderRepository = orderRepository;
            _quotationRepository = quotationRepository;
            _orderDetailsRepository = orderDetailsRepository;
        }

        [BindProperty]
        public Order Order { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? orderId)
        {
            if (orderId == null)
            {
                return NotFound();
            }
            Order = _queries.GetOrderIncludeOrderDetailsServiceApplicationUserFirstOrDefault((Guid)orderId);
            if (Order == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (Order.Id == null)
            {
                return NotFound();
            }

            LoadAndRemoveOrderAndItsDependantModels();
            return RedirectToPage("../ManageOrders/OrderIndexAdmin");
        }

        private void LoadAndRemoveOrderAndItsDependantModels()
        {
            Order = _queries.GetOrderByOrderId(Order.Id);
            if (Order != null)
            {
                var orderDetailsLocal = _queries.GetOrderDetailsFromSameOrder(Order.Id);
                foreach (var orderDetails in orderDetailsLocal)
                {
                    var quotationLocal = _queries.GetQuotationIncludeOrderDetailsOrdersEmployeeTasksListMaterialPicturesFirstOrDefault(orderDetails.Id);
                    _orderDetailsRepository.Remove(orderDetails);
                    if (quotationLocal != null)
                    {
                        _quotationRepository.Remove(quotationLocal);
                    }
                }
                _orderRepository.Remove(Order);
                _queries.SaveChanges();
            }
        }
    }
}
