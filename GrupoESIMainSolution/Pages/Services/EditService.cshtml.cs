using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GrupoESI.Data;
using GrupoESIModels.Models;
using GrupoESIDataAccess;
using GrupoESIDataAccess.Repository.IRepository;

namespace GrupoESI
{
    public class EditeServiceModel : PageModel
    {
        private readonly IServiceRepository _serviceRepository;

        public EditeServiceModel(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        [BindProperty]
        public Service ServiceModel { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid serviceId)
        {
            if (serviceId == null)
            {
                return NotFound();
            }

            ServiceModel = _serviceRepository.FirstOrDefault(m => m.serviceId == serviceId, includeProperties: "serviceType, ApplicationUser");
                

            if (ServiceModel == null)
            {
                return NotFound();
            }
          
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var service = _serviceRepository.FirstOrDefault(s => s.serviceId == ServiceModel.serviceId);
            service.Name = ServiceModel.Name;
            service.Description = ServiceModel.Description;
            try
            {
                _serviceRepository.Save();
            }
            catch (DbUpdateConcurrencyException)
            {

            }

            return RedirectToPage("./IndexService");
        }

       
    }
}
