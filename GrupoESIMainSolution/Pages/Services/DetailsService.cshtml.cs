using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GrupoESIModels.Models;
using GrupoESIDataAccess.Repository.IRepository;

namespace GrupoESINuevo
{
    public class DetailsServiceModel : PageModel
    {
        private readonly IServiceRepository _serviceRepository;
        public DetailsServiceModel(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public Service ServiceModel { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid serviceId)
        {
            if (serviceId == null)
            {
                return NotFound();
            }

            ServiceModel = _serviceRepository.FirstOrDefault(m => m.ID == serviceId, includeProperties: "serviceType,ApplicationUser");
                

            if (ServiceModel == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
