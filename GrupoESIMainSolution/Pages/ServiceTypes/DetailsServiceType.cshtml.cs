using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using GrupoESIModels.Models;
using GrupoESIUtility;
using GrupoESIDataAccess.Repository.IRepository;

namespace GrupoESI
{
    [Authorize(Roles = SD.AdminEndUser)]
    public class DetailsServiceTypeModel : PageModel
    {

        private readonly IServiceTypeRepository _ServiceTypeRepo;

        public DetailsServiceTypeModel(IServiceTypeRepository ServiceTypeRepository)
        {
            _ServiceTypeRepo = ServiceTypeRepository;
        }

        public ServiceType ServiceType { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ServiceType = _ServiceTypeRepo.FirstOrDefault(m => m.Id == id);

            if (ServiceType == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
