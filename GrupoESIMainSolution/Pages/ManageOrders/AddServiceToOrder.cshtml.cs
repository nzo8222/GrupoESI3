using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GrupoESIModels.ViewModels;
using GrupoESIDataAccess.Queries;

namespace GrupoESI
{
    public class AddServiceToOrderModel : PageModel
    {
        private readonly IQueries _queries;
        public AddServiceToOrderModel(IQueries queries)
        {
            _queries = queries;
        }
        [BindProperty]
        public AddServiceVM _AddServiceVM { get;set; }

        public async Task OnGetAsync(Guid orderDetailsId)
        {
            LoadServiceToOrderVM(orderDetailsId);
            if (_AddServiceVM.OrderDetailsList.Count > 0)
            {
                _AddServiceVM.OrderId = _AddServiceVM.OrderDetailsList[0].Order.Id;
            }
            FilterServicesListFromServicesThatHadAlreadyBeenRegisteredOnThisOrder();
        }

        private void FilterServicesListFromServicesThatHadAlreadyBeenRegisteredOnThisOrder()
        {
            List<Guid> lstGuidServicesFromSameUser = _queries.GetLstServiceFromSameUserWhereUserIdEqualsUserIdSelectId(_AddServiceVM.OrderDetailsList[0].Service.UserId);
            //lista de servicios con cotizacion
            List<Guid> lstGuidServicesWithQuotation = new List<Guid>();

            //por cada orderDetails se agrega el id del servicio a la lista de servicios con cotizacion
            foreach (var orderDetail in _AddServiceVM.OrderDetailsList)
            {
                lstGuidServicesWithQuotation.Add(orderDetail.Service.serviceId);
            }
            //de la lista de servicios del mismo usuario se excluyen aquellos registros que ya tengan un OrderDetails 
            lstGuidServicesFromSameUser = lstGuidServicesFromSameUser.FindAll(x => !lstGuidServicesWithQuotation.Contains(x));

            //por cada servicio del mismo usuario que sobre despues de excluir los que ya tienen un orderDetails 
            //se agrega un modelo de servicio a una lista del viewModel
            foreach (var item in lstGuidServicesFromSameUser)
            {
                var serviceModel = _queries.GetServiceIncludeApplicationUserFirstOrDefault(item);
                _AddServiceVM.lstServicios.Add(serviceModel);
            }
        }

        private void LoadServiceToOrderVM(Guid orderDetailsId)
        {
            _AddServiceVM = new AddServiceVM(orderDetailsId);

            _AddServiceVM.OrderDetailsLocal = _queries.GetOrderDetailsIncludeOrderServiceApplicationUserFirstOrDefaultOrderDetailsIdEqualsOrderDetailsId(orderDetailsId);

            _AddServiceVM.OrderDetailsList = _queries.GetLstOrderDetailsIncludeOrderServiceApplicationUserWhereOrderIdAndApplicationUserId(_AddServiceVM.OrderDetailsLocal.OrderId, _AddServiceVM.OrderDetailsLocal.Service.UserId);
        }
    }
}
