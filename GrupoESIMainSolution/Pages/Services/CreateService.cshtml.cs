using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GrupoESI.Data;

using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using GrupoESIModels.Models;
using GrupoESIDataAccess;
using GrupoESIDataAccess.Repository.IRepository;

namespace GrupoESI
{
    [Authorize]
    public class CreateServoceModel : PageModel
    {

        private readonly IServiceTypeRepository _ServiceTypeRepo;
        private readonly IServiceRepository _ServiceRepository;
        public List<ServiceType> ServiceTypesList { get; set; }
        [BindProperty]
        public Service Service { get; set; }

        [TempData]
        public string StatusMessage { get; set; }
        public CreateServoceModel(IServiceTypeRepository ServiceTypeRepository, IServiceRepository ServiceRepository)
        {
            _ServiceTypeRepo = ServiceTypeRepository;
            _ServiceRepository = ServiceRepository;
        }
        public IActionResult OnGet(string userId = null)
        {
            initiateServiceVariables();
            if (userId == null)
            {
                userId = GetUserIdFromLoggedSession();
            }
            Service.UserId = userId;
            //lista de tipos de servicios que ya tienen un servicio registrado
            LoadServiceTypeListThatHadNotBeenAlreadyRegisteredAServiceByThisUser();

            return Page();
        }

        private void LoadServiceTypeListThatHadNotBeenAlreadyRegisteredAServiceByThisUser()
        {
            List<Guid> lstTiposDeServiciosConServicioRegistrado = LoadServicesRegisteredByThisUser();
            List<Guid> lstDeTiposDeServicios = LoadAllServiceType();
            lstDeTiposDeServicios = FilterListOfRegisteredServiceType(lstTiposDeServiciosConServicioRegistrado, lstDeTiposDeServicios);
        }

        private List<Guid> FilterListOfRegisteredServiceType(List<Guid> lstTiposDeServiciosConServicioRegistrado, List<Guid> lstDeTiposDeServicios)
        {
            lstDeTiposDeServicios = lstDeTiposDeServicios.FindAll(x => !lstTiposDeServiciosConServicioRegistrado.Contains(x));

            foreach (var item in lstDeTiposDeServicios)
            {
                var _serviceType = _ServiceTypeRepo.FirstOrDefault(s => s.Id == item);
                ServiceTypesList.Add(_serviceType);
            }

            return lstDeTiposDeServicios;
        }

        private List<Guid> LoadAllServiceType()
        {
            List<Guid> lstDeTiposDeServicios = new List<Guid>();

            var lstTiposDeServicios = _ServiceTypeRepo.GetAll();

            foreach (var item in lstTiposDeServicios)
            {
                lstDeTiposDeServicios.Add(item.Id);
            }

            return lstDeTiposDeServicios;
        }

        private List<Guid> LoadServicesRegisteredByThisUser()
        {
            var servicios = _ServiceRepository.GetAll(au => au.ApplicationUser.Id == Service.UserId, includeProperties: "serviceType,ApplicationUser");

            List<Guid> lstTiposDeServiciosConServicioRegistrado = new List<Guid>();

            foreach (var item in servicios)
            {
                lstTiposDeServiciosConServicioRegistrado.Add(item.serviceType.Id);
            }

            return lstTiposDeServiciosConServicioRegistrado;
        }

        private string GetUserIdFromLoggedSession()
        {
            string userId;
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            userId = claim.Value;
            return userId;
        }

        private void initiateServiceVariables()
        {
            ServiceTypesList = new List<ServiceType>();
            Service = new Service();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (Service.Description == null)
            {
                return RedirectToPage("CreateService", new { userId = Service.UserId });
            }
            if (Service.Name == null)
            {
                return RedirectToPage("CreateService", new { userId = Service.UserId });
            }
            AddServiceToDataBase();
            return RedirectToPage("IndexService", new { userId = Service.UserId });
        }

        private void AddServiceToDataBase()
        {
            Service.serviceType = _ServiceTypeRepo.FirstOrDefault(s => s.Id == Service.serviceType.Id);
            _ServiceRepository.Add(Service);
            _ServiceRepository.Save();
            StatusMessage = "El servicio fue creado correctamente";
        }
    }
}
