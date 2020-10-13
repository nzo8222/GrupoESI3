
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

namespace GrupoESINuevo
{
    [Authorize(Roles = SD.AdminEndUser)]
    public class IndexUserModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IndexUserModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public UsersListViewModel UsersListVM { get; set; }
        public async Task<IActionResult> OnGet(int productPage = 1, string searchName = null, string searchCompany = null, string searchEmail = null)
        {
            UsersListVM = new UsersListViewModel()
            {
                ApplicationUserList = await _db.ApplicationUser.ToListAsync()
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
                UsersListVM.ApplicationUserList = await _db.ApplicationUser.Where(u => u.Email.ToLower().Contains(searchName.ToLower())).ToListAsync();
            }
            else
            {
                if (searchCompany != null)
                {
                    UsersListVM.ApplicationUserList = await _db.ApplicationUser.Where(u => u.CompanyName.ToLower().Contains(searchCompany.ToLower())).ToListAsync();
                }
                else
                {
                    if (searchEmail != null)
                    {
                        UsersListVM.ApplicationUserList = await _db.ApplicationUser.Where(u => u.PhoneNumber.ToLower().Contains(searchEmail.ToLower())).ToListAsync();
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