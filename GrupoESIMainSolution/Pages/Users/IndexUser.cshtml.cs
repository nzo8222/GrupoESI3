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

namespace GrupoESI
{
    [Authorize(Roles = SD.AdminEndUser)]
    public class IndexUserModel : PageModel
    {
        private readonly IQueries _queries;

        public IndexUserModel(IQueries queries)
        {
            _queries = queries;
        }
        [BindProperty]
        public UsersListViewModel UsersListVM { get; set; }
        public async Task<IActionResult> OnGet(int productPage = 1, string searchName = null, string searchCompany = null, string searchEmail = null)
        {
            UsersListVM = new UsersListViewModel()
            {
                ApplicationUserList = _queries.GetAllApplicationUser()
            };

            StringBuilder param = new StringBuilder();
            param.Append("/Users/IndexUser?productPage=:");
            param.Append("&searchName=");
            if (searchCompany != null)
            {
                param.Append(searchCompany);
            }
            param.Append("&searchCompany=");
            if (searchName != null)
            {
                param.Append(searchName);
            }
            param.Append("&searchEmail=");
            if (searchEmail != null)
            {
                param.Append(searchEmail);
            }

            if (searchName != null)
            {
                UsersListVM.ApplicationUserList = UsersListVM.ApplicationUserList.Where(u => u.Email.ToLower().Contains(searchName.ToLower())).ToList();
            }
            else
            {
                if (searchCompany != null)
                {
                    UsersListVM.ApplicationUserList = UsersListVM.ApplicationUserList.Where(u => u.CompanyName.ToLower().Contains(searchCompany.ToLower())).ToList();
                }
                else
                {
                    if (searchEmail != null)
                    {
                        UsersListVM.ApplicationUserList = UsersListVM.ApplicationUserList.Where(u => u.PhoneNumber.ToLower().Contains(searchEmail.ToLower())).ToList();
                    }
                }
            }


            var count = UsersListVM.ApplicationUserList.Count;

            UsersListVM.PagingInfo = new PagingInfo
            {
                CurrentPage = productPage,
                ItemsPerPage = SD.PaginationUsersPageSize,
                TotalItems = count,
                UrlParam = param.ToString()
            };

            UsersListVM.ApplicationUserList = UsersListVM.ApplicationUserList.OrderBy(p => p.Email)
                .Skip((productPage - 1) * SD.PaginationUsersPageSize)
                .Take(SD.PaginationUsersPageSize).ToList();

            return Page();
        }
    }
}