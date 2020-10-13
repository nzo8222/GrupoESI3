using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GrupoESIModels.Models;
using GrupoESIDataAccess.Queries;
using GrupoESIDataAccess.Repository.IRepository;

namespace GrupoESINuevo
{
    public class DeleteQuotationModel : PageModel
    {

        private readonly IQueries _queries;

        private readonly IQuotationRepository _quotationRepository;
        private readonly IOrderDetailsRepository _orderDetailsRepository;
        private readonly IOrderRepository _orderRepository;

        public DeleteQuotationModel(IQueries queries,
                                    IQuotationRepository quotationRepository,
                                    IOrderRepository orderRepository,
                                    IOrderDetailsRepository orderDetailsRepository)
        {
            _quotationRepository = quotationRepository;
            _orderDetailsRepository = orderDetailsRepository;
            _orderRepository = orderRepository;
            _queries = queries;
        }

        [BindProperty]
        public OrderDetails OrderDetails { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? orderDetailsId)
        {
            if (orderDetailsId == null)
            {
                return NotFound();
            }
            OrderDetails = _queries.GetOrderDetailsWithOrderServiceApplicationUser((Guid)orderDetailsId);
            if (OrderDetails == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {

            if (OrderDetails.Id == null)
            {
                return NotFound();
            }

            LoadRelatedEntities();

            return RedirectToPage("../Index");
        }

        private void LoadRelatedEntities()
        {
            OrderDetails = _queries.GetOrderDetailsWithOrderServiceApplicationUser(OrderDetails.Id);
            var quotationLocal = _queries.GetQuotationWithOrderDetailsOrdersTasksListMaterialFirstOrDefault(OrderDetails.Id);
            if (OrderDetails != null && quotationLocal != null)
            {
                checkIfThereAreMoreThanOneOrderDetails();
                removeRelatedEntities(quotationLocal);
            }
        }

        private void removeRelatedEntities(Quotation quotationLocal)
        {
            _orderDetailsRepository.Remove(OrderDetails);
            _quotationRepository.Remove(quotationLocal);
            _queries.SaveChanges();
        }

        private void checkIfThereAreMoreThanOneOrderDetails()
        {
            var orderDetailFromSameOrder = _queries.GetOrderDetailsFromSameOrder(OrderDetails.Order.Id);
            if (orderDetailFromSameOrder.Count == 1)
            {
                _orderRepository.Remove(orderDetailFromSameOrder[0].Order);
            }
        }
    }
}
