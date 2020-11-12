using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GrupoESIDataAccess.Queries;
using GrupoESIModels.GrupoESIModels;
using GrupoESIModels.Models;
using GrupoESIModels.ViewModels;
using GrupoESIUtility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace GrupoESI.Pages.ManageOrders
{
    [Authorize(Roles = SD.AdminEndUser)]
    public class OrderIndexAdminModel : PageModel
    {
        private readonly IQueries _queries;
        [BindProperty]
        public OrderIndexAdminVM _OrderIndexAdminVM { get; set; }
        public List<Order> OrderList;
        public OrderIndexAdminModel(IQueries queries)
        {
            _queries = queries;
        }
        public async Task<IActionResult> OnGet(int productPage = 1, string searchConcepto = null, string searchDireccion = null)
        {
            _OrderIndexAdminVM = new OrderIndexAdminVM()
            {
                OrderList = _queries.GetAllLstOrderIncludeLstOrderDetailsServiceServiceTypeToList()
            };
            StringBuilder param = FilterOrderList(searchConcepto, searchDireccion);
            SetPagination(productPage, param);
            return Page();
        }
        private void SetPagination(int productPage, StringBuilder param)
        {
            var count = _OrderIndexAdminVM.OrderList.Count();
            _OrderIndexAdminVM.PagingInfo = new PagingInfo()
            {
                CurrentPage = productPage,
                ItemsPerPage = SD.PaginationUsersPageSize,
                TotalItems = count,
                UrlParam = param.ToString()
            };
            _OrderIndexAdminVM.OrderList = _OrderIndexAdminVM.OrderList.OrderByDescending(o => o.OrderDate)
                .Skip((productPage - 1) * SD.PaginationUsersPageSize)
                .Take(SD.PaginationUsersPageSize).ToList();
        }
        private StringBuilder FilterOrderList(string searchConcepto, string searchDireccion)
        {
            StringBuilder param = new StringBuilder();
            param.Append("/ManageOrders/OrderIndexAdmin?productPage=:");
            param.Append("&searchConcepto=");
            if (searchConcepto != null)
            {
                param.Append(searchConcepto);
            }
            if (searchDireccion != null)
            {
                param.Append(searchDireccion);
            }

            if (searchConcepto != null)
            {
                _OrderIndexAdminVM.OrderList = (List<Order>)_OrderIndexAdminVM.OrderList
                                                                   .Where(o => o.Concepto.ToLower().Contains(searchConcepto.ToLower()));
            }
            else
            {
                if (searchDireccion != null)
                {
                    _OrderIndexAdminVM.OrderList = (List<Order>)_OrderIndexAdminVM.OrderList
                                                                   .Where(o => o.Direccion.ToLower().Contains(searchDireccion.ToLower()));
                }
            }

            return param;
        }
    }
}