using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using GrupoESIModels.Models;
using GrupoESIUtility;
using GrupoESIDataAccess.Repository.IRepository;

namespace GrupoESINuevo
{
    [Authorize(Roles = SD.AdminEndUser)]
    public class EditServiceTypeModel : PageModel
    {
        private readonly IServiceTypeRepository _ServiceTypeRepo;

        public EditServiceTypeModel(IServiceTypeRepository ServiceTypeRepository)
        {
            _ServiceTypeRepo = ServiceTypeRepository;
        }

        [BindProperty]
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

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            EditServiceType();

            return RedirectToPage("./IndexServiceType");
        }

        private void EditServiceType()
        {
            var serviceTypeLocal = _ServiceTypeRepo.FirstOrDefault(s => s.Id == ServiceType.Id);
            serviceTypeLocal.Descripcion = ServiceType.Descripcion;
            serviceTypeLocal.Category = ServiceType.Category;

            try
            {
                _ServiceTypeRepo.Save();
            }
            catch (DbUpdateConcurrencyException)
            {

            }
        }

    }
}
