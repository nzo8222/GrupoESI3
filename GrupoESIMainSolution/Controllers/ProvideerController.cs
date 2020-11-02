using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrupoESIDataAccess.Queries;
using GrupoESIModels.Models;
using GrupoESIModels.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GrupoESI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvideerController : Controller
    {
        private readonly IQueries _queries;
        public ProvideerController(IQueries queries)
        {
            _queries = queries;
        }
        [HttpGet]
        [Route("GetProvideerOrderList")]
        public IActionResult GetOrderList(string provideerId)
        {
            List<OrderDetails> orderList = _queries.GetAllOrderDetailsIncludeOrderQuotationServiceServiceTypeApplicationUserWhereUserIdEquialsUserId(provideerId);
            var orderVM = new List<ProvideerOrderIndexVM>();
            for (int i = 0; i < orderList.Count; i++)
            {
                var orderLocal = new ProvideerOrderIndexVM();
                orderLocal.orderDetailsId = orderList[i].Id.ToString();
                orderLocal.address = orderList[i].Order.Direccion;
                orderLocal.date = orderList[i].Order.OrderDate.ToString();
                orderLocal.orderDetailsId = orderList[i].Id.ToString();
                orderLocal.serviceName = orderList[i].Service.Name;
                if(orderList[i].Service.serviceType != null && orderList[i].Service != null)
                {
                    orderLocal.serviceType = orderList[i].Service.serviceType.Category;
                }
                
                orderLocal.concept = orderList[i].Order.Concepto;
                orderVM.Add(orderLocal);
            }
            return Json(new { data = orderVM });
        }
    }
}
