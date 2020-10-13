
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using Microsoft.AspNetCore.Authorization;

using GrupoESIModels.Models;

using GrupoESIDataAccess.Repository.IRepository;
using GrupoESIUtility;

namespace GrupoESINuevo
{
    [Authorize(Roles = SD.AdminEndUser)]
    public class CreateServiceTypeModel : PageModel
    {
        private readonly IServiceTypeRepository _ServiceTypeRepo;

        public CreateServiceTypeModel(IServiceTypeRepository serviceRepo)
        {
            _ServiceTypeRepo = serviceRepo;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ServiceType ServiceType { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (ServiceType.Category == null)
            {
                TempData[SD.Error] = "No puede haber valores en blanco";
                return Page();
            }
            if(ServiceType.Descripcion == null)
            {
                TempData[SD.Error] = "No puede haber valores en blanco";
                return Page();
            }
            TempData[SD.Success] = "Tipo de servicio fue creado correctamente";
            _ServiceTypeRepo.Add(ServiceType);
            _ServiceTypeRepo.Save();

            return RedirectToPage("./IndexServiceType");
        }
    }
}
