using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using GrupoESIModels.ViewModels;

using GrupoESIUtility;
using GrupoESIDataAccess.Queries;
using GrupoESIModels.GrupoESIModels;

namespace GrupoESINuevo
{
    [Authorize]
    public class IndexQuotationModel : PageModel
    {
        private readonly IQueries _queries;
        public IndexQuotationModel(IQueries queries)
        {
            _queries = queries;
        }
        public IndexQuotationVM _indexQuotationVM;
        public async Task<IActionResult> OnGetAsync(int productPage = 1, string searchConcepto = null, string searchNombre = null, string searchDescripcion = null)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            var userId = claim.Value;
            _indexQuotationVM = new IndexQuotationVM()
            {
                OrderDetails = _queries.GetOrderDetailsIncludeOrderQuotationServiceThenIncludeApplicationUserWhereUserIdEquialsUserId(userId)
            };
            StringBuilder param = SetParameter(searchConcepto, searchNombre, searchDescripcion);
            filterQuotationList(searchConcepto, searchNombre, searchDescripcion);
            SetPagination(productPage, param);
            return Page();
        }

        private void SetPagination(int productPage, StringBuilder param)
        {
            var count = _indexQuotationVM.OrderDetails.Count;
            _indexQuotationVM.pagingInfo = new PagingInfo
            {
                CurrentPage = productPage,
                ItemsPerPage = SD.PaginationUsersPageSize,
                TotalItems = count,
                UrlParam = param.ToString()
            };

            _indexQuotationVM.OrderDetails = _indexQuotationVM.OrderDetails.OrderByDescending(od => od.Order.OrderDate)
                       .Skip((productPage - 1) * SD.PaginationUsersPageSize)
                       .Take(SD.PaginationUsersPageSize).ToList();
        }

        private void filterQuotationList(string searchConcepto, string searchNombre, string searchDescripcion)
        {
            if (searchConcepto != null)
            {
                _indexQuotationVM.OrderDetails = _indexQuotationVM.OrderDetails.Where(od => od.Order.Concepto.ToLower().Contains(searchConcepto.ToLower())).ToList();
            }
            else
            {
                if (searchNombre != null)
                {
                    _indexQuotationVM.OrderDetails = _indexQuotationVM.OrderDetails.Where(od => od.Service.Name.ToLower().Contains(searchNombre.ToLower())).ToList();
                }
                else
                {
                    if (searchDescripcion != null)
                    {
                        //_indexQuotationVM.OrderDetails = _indexQuotationVM.OrderDetails.Where(od => od.Quotation.Description.ToLower().Contains(searchDescripcion.ToLower())).ToList();
                    }
                }
            }
        }

        private static StringBuilder SetParameter(string searchConcepto, string searchNombre, string searchDescripcion)
        {
            StringBuilder param = new StringBuilder();
            param.Append("/Quotations/IndexQuotation?productPage=:");
            param.Append("&searchConcepto=");
            if (searchConcepto != null)
            {
                param.Append(searchConcepto);
            }
            param.Append("&searchNombre");
            if (searchDescripcion != null)
            {
                param.Append(searchNombre);
            }
            if (searchDescripcion != null)
            {
                param.Append(searchDescripcion);
            }
            return param;
        }
    }
}
