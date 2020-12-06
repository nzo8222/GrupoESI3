using System;

using GrupoESIDataAccess.Queries;
using GrupoESIDataAccess.Repository.IRepository;
using GrupoESIModels;
using GrupoESIModels.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GrupoESI.Pages.PredefinedMaterials
{
    public class CreatePredefinedTaskMaterialModel : PageModel
    {
        private readonly IQueries _queries;
        private readonly IPredefinedMaterialRepository _predefinedMaterialRepository;
        public CreatePredefinedTaskMaterialModel(IQueries queries,
                                                 IPredefinedMaterialRepository predefinedMaterialRepository)
        {
            _predefinedMaterialRepository = predefinedMaterialRepository;
            _queries = queries;
        }
        [BindProperty]
        public CreatePredefinedTaskMaterialVM _CreatePredefinedTaskMaterialVM { get; set; }
        public CreatePredefinedTaskMaterialDescriptionVM _PredefinedTaskDescription { get; set; }
        public IActionResult OnGet(Guid? predefinedTaskId = null)
        {
            if(predefinedTaskId == null || predefinedTaskId == Guid.Empty)
            {
                return NotFound();
            }
            _CreatePredefinedTaskMaterialVM = new CreatePredefinedTaskMaterialVM();
            _PredefinedTaskDescription = new CreatePredefinedTaskMaterialDescriptionVM();
            PredefinedTask predefinedTaskLocal = _queries.GetPredefinedTaskIncludeServiceLstPredefinedMaterialWherePredefinedTaskIdEquals(predefinedTaskId);
            _PredefinedTaskDescription.predefinedTaskCost = predefinedTaskLocal.Cost;
            _PredefinedTaskDescription.predefinedTaskDescription = predefinedTaskLocal.Description;
            _PredefinedTaskDescription.predefinedTaskName = predefinedTaskLocal.Name;
            _PredefinedTaskDescription.serviceDescription = predefinedTaskLocal.Service.Description;
            _PredefinedTaskDescription.serviceName = predefinedTaskLocal.Service.Name;
            _CreatePredefinedTaskMaterialVM.predefinedTaskId = (Guid)predefinedTaskId;
            return Page();
        }
        public IActionResult OnPost()
        {
            if (_CreatePredefinedTaskMaterialVM.predefinedTaskId == Guid.Empty)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                GrupoESIModels.PredefinedMaterial predefinedMaterialLocal = new GrupoESIModels.PredefinedMaterial();
                predefinedMaterialLocal.PredefinedTaskId = _CreatePredefinedTaskMaterialVM.predefinedTaskId;
                predefinedMaterialLocal.Description = _CreatePredefinedTaskMaterialVM.predefinedTaskMaterialDescription;
                predefinedMaterialLocal.Name = _CreatePredefinedTaskMaterialVM.predefinedTaskMaterialName;
                predefinedMaterialLocal.Price = _CreatePredefinedTaskMaterialVM.predefinedTaskMaterialCost;
                PredefinedTask predefinedTaskLocal = _queries.GetPredefinedTaskIncludeServiceLstPredefinedMaterialWherePredefinedTaskIdEquals(_CreatePredefinedTaskMaterialVM.predefinedTaskId);
                predefinedTaskLocal.Cost = predefinedTaskLocal.Cost + predefinedMaterialLocal.Price;
                _predefinedMaterialRepository.Add(predefinedMaterialLocal);
                _queries.SaveChanges();
            }
            return RedirectToPage("/PredefinedMaterials/ManagePredefinedTaskMaterial", new { predefinedTaskId = _CreatePredefinedTaskMaterialVM.predefinedTaskId });
        }
    }
}
