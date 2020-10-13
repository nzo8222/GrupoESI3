using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrupoESIDataAccess;
using GrupoESIModels.Models;
using GrupoESIModels.ViewModels;
using GrupoESIUtility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GrupoESINuevo.Pages.ManageOrders
{
    [Authorize(Roles = SD.AdminEndUser)]
    public class OrderIndexAdminModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        [BindProperty]
        public OrderIndexAdminVM _OrderIndexAdminVM { get; set; }
        public List<Order> OrderList;
        public OrderIndexAdminModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGet(int productPage = 1, string searchConcepto = null, string searchDireccion = null)
        {
            _OrderIndexAdminVM = new OrderIndexAdminVM()
            {
                OrderList = await _context.Order
                                      .Include(o => o.LstOrderDetails)
                                          .ThenInclude(od => od.Service)
                                          .ThenInclude(od => od.serviceType)
                                      .ToListAsync()
            };
            StringBuilder param = new StringBuilder();
            param.Append("/ManageOrders/OrderIndexAdmin?productPage=:");
            param.Append("&searchConcepto=");
            if(searchConcepto != null)
            {
                param.Append(searchConcepto);
            }
            if(searchDireccion != null)
            {
                param.Append(searchDireccion);
            }

            if(searchConcepto != null)
            {
                _OrderIndexAdminVM.OrderList = await _context.Order
                                                                   .Include(o => o.LstOrderDetails)
                                                                        .ThenInclude(od => od.Service)
                                                                        .ThenInclude(od => od.serviceType)
                                                                   .Where(o => o.Concepto.ToLower().Contains(searchConcepto.ToLower())).ToListAsync();         
            }
            else
            {
                if(searchDireccion != null)
                {
                    _OrderIndexAdminVM.OrderList = await _context.Order
                                                                   .Include(o => o.LstOrderDetails)
                                                                        .ThenInclude(od => od.Service)
                                                                        .ThenInclude(od => od.serviceType)
                                                                   .Where(o => o.Direccion.ToLower().Contains(searchDireccion.ToLower())).ToListAsync();
                }
            }
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
            return Page();
        }
    }
}