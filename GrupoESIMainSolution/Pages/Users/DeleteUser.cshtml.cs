using GrupoESIDataAccess.Queries;
using GrupoESIDataAccess.Repository.IRepository;
using GrupoESIModels.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GrupoESI
{
    public class DeleteUserModel : PageModel
    {
        private readonly IQueries _queries;
        private readonly IQuotationRepository _quotationRepository;
        private readonly IOrderDetailsRepository _orderDetailsRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IServiceRepository _serviceRepository;
        private readonly IApplicationUserRepository _applicationUserRepository;

        public DeleteUserModel(IQueries queries,
                               IQuotationRepository quotationRepository,
                               IOrderDetailsRepository orderDetailsRepository,
                               IOrderRepository orderRepository,
                               IServiceRepository serviceRepository,
                               IApplicationUserRepository applicationUserRepository)
        {
            _quotationRepository = quotationRepository;
            _orderDetailsRepository = orderDetailsRepository;
            _orderRepository = orderRepository;
            _queries = queries;
            _serviceRepository = serviceRepository;
            _applicationUserRepository = applicationUserRepository;
        }
        [BindProperty]
        public ApplicationUser _ApplicationUser { get; set; }
        public IActionResult OnGet(string userId)
        {
            if (userId == "")
            {
                return NotFound();
            }
            _ApplicationUser = _queries.GetAppicationUserFirstOrDefault(userId);
                
                
            if (_ApplicationUser == null)
            {
                return NotFound();
            }

            return Page();
        }

        public IActionResult OnPostAsync()
        {
            if (_ApplicationUser.Id == "")
            {
                return NotFound();
            }

            _ApplicationUser = _queries.GetAppicationUserFirstOrDefault(_ApplicationUser.Id);
            
            if (_ApplicationUser != null)
            {

                var serviciosListLocal = _queries.GetServiceLstIncludeApplicationUserWhereUserIdEquals(_ApplicationUser.Id);

                foreach (var service in serviciosListLocal)
                {

                    var orderDetailsLocal = _queries.GetAllOrderDetailsIncludeOrderServiceApplicationUserWhereServiceIdEquals(service.serviceId);
 
                    foreach (var orderDetails in orderDetailsLocal)
                    {

                        var quotationLocal = _queries.GetQuotationIncludeOrderDetailsTaskListMaterialPicturesFirstOrDefaultWhereOrderDetailsIdEquals(orderDetails.Id);

                        _orderDetailsRepository.Remove(orderDetails);
                        if (quotationLocal != null)
                        {

                            _quotationRepository.Remove(quotationLocal);
                        }
                        var _order = _queries.GetOrderFirstOrDefaultWhereOrderIdEquals(orderDetails.Order.Id);
                        if(_order != null)
                        {
                            var orderDetailsConEstaOrden = _queries.GetOrderDetailsIncludeOrderWhereOrderIdEquals(_order.Id);
                            if (orderDetailsConEstaOrden.Count > 0)
                            {

                            }
                            else
                            {
                                _orderRepository.Remove(_order);
                            }
                        }
                        
                    }
                    _serviceRepository.Remove(service);
                }
                _applicationUserRepository.Remove(_ApplicationUser);
                _queries.SaveChanges();
            }
            return RedirectToPage("./IndexUser");
        }
    }
}