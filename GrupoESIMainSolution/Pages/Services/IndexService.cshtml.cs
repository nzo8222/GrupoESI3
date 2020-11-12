using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using GrupoESIModels.ViewModels;
using GrupoESIDataAccess.Repository.IRepository;

namespace GrupoESI
{
    [Authorize]
    public class IndexServiceModel : PageModel
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly IApplicationUserRepository _applicationUserRepository;


        [BindProperty]
        public ServiceAndProviderVM ServiceAndProviderVM { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        public IndexServiceModel(IServiceRepository serviceRepository,
                                IApplicationUserRepository applicationUserRepository)
        {
            _serviceRepository = serviceRepository;
            _applicationUserRepository = applicationUserRepository;
        }

        public async Task<IActionResult> OnGet(string userId = null)
        {
            if (userId == null)
            {
                userId = LoadUserFromLoggedSession();
            }
            LoadService(userId);
            return Page();
        }

        private string LoadUserFromLoggedSession()
        {
            string userId;
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            userId = claim.Value;
            return userId;
        }

        private void LoadService(string userId)
        {
            ServiceAndProviderVM = new ServiceAndProviderVM()
            {
                Services = (List<GrupoESIModels.Models.Service>)_serviceRepository.GetAll(c => c.ApplicationUser.Id == userId, includeProperties: "serviceType,ApplicationUser"),
                UserObj = _applicationUserRepository.FirstOrDefault(u => u.Id == userId)
            };
            ServiceAndProviderVM.UserLocalId = userId;
        }
    }
}
