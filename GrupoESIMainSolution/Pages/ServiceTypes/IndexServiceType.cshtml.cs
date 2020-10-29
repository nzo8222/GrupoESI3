
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using System.Text;
using GrupoESIModels.ViewModels;
using GrupoESIModels.Models;
using GrupoESIUtility;
using GrupoESIDataAccess.Repository.IRepository;
using GrupoESIModels.GrupoESIModels;

namespace GrupoESINuevo
{
    [Authorize(Roles = SD.AdminEndUser)]
    public class IndexServiceTypeModel : PageModel
    {
        private readonly IServiceTypeRepository _ServiceTypeRepo;

        public IndexServiceTypeModel(IServiceTypeRepository ServiceTypeRepository)
        {
            _ServiceTypeRepo = ServiceTypeRepository;
        }
        [BindProperty]
        public ServiceTypeVM ServiceType { get;set; }

        public async Task<IActionResult> OnGetAsync(int productPage = 1, string searchCategory = null, string searchDescription = null)
        {
            ServiceType = new ServiceTypeVM()
            {
                ServiceTypeList = (List<ServiceType>)_ServiceTypeRepo.GetAll()
            };
            StringBuilder param = BuildParameter(searchCategory, searchDescription);
            filterList(searchCategory, searchDescription);
            paginateList(productPage, param);
            return Page();
        }

        private void paginateList(int productPage, StringBuilder param)
        {
            var count = ServiceType.ServiceTypeList.Count;

            ServiceType.PagingInfo = new PagingInfo
            {
                CurrentPage = productPage,
                ItemsPerPage = SD.PaginationUsersPageSize,
                TotalItems = count,
                UrlParam = param.ToString()
            };

            ServiceType.ServiceTypeList = ServiceType.ServiceTypeList.OrderBy(p => p.Category)
                .Skip((productPage - 1) * SD.PaginationUsersPageSize)
                .Take(SD.PaginationUsersPageSize).ToList();
        }

        private void filterList(string searchCategory, string searchDescription)
        {
            if (searchCategory != null)
            {
                ServiceType.ServiceTypeList = (List<ServiceType>)_ServiceTypeRepo.GetAll(u => u.Category.ToLower().Contains(searchCategory.ToLower()));
            }
            else
            {
                if (searchDescription != null)
                {
                    ServiceType.ServiceTypeList = (List<ServiceType>)_ServiceTypeRepo.GetAll(u => u.Descripcion.ToLower().Contains(searchDescription.ToLower()));
                }

            }
        }

        private static StringBuilder BuildParameter(string searchCategory, string searchDescription)
        {
            StringBuilder param = new StringBuilder();
            param.Append("/ServiceTypes/IndexServiceType?productPage=:");
            param.Append("&searchDescription=");
            if (searchDescription != null)
            {
                param.Append(searchDescription);
            }
            param.Append("&searchCategory=");
            if (searchCategory != null)
            {
                param.Append(searchCategory);
            }

            return param;
        }
    }
}
