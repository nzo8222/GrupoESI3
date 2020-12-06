using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrupoESIDataAccess.Queries;
using GrupoESIDataAccess.Repository.IRepository;
using GrupoESIModels;
using GrupoESIModels.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GrupoESI.Pages.PredefinedMaterials
{
    public class DeletePredefinedMaterialModel : PageModel
    {
        private readonly IQueries _queries;
        private readonly IPredefinedMaterialRepository _predefinedMaterialRepository;
        public DeletePredefinedMaterialModel(IQueries queries,
                                             IPredefinedMaterialRepository predefinedMaterialRepository)
        {
            _queries = queries;
            _predefinedMaterialRepository = predefinedMaterialRepository;
        }
        public CreatePredefinedTaskMaterialDescriptionVM _PredefinedTaskDescription { get; set; }

        [BindProperty]
        public CreatePredefinedTaskMaterialVM _CreatePredefinedTaskMaterialVM { get; set; }
        public IActionResult OnGet(string predefinedMaterialId = null)
        {
            _PredefinedTaskDescription = new CreatePredefinedTaskMaterialDescriptionVM();
            _CreatePredefinedTaskMaterialVM = new CreatePredefinedTaskMaterialVM();
            Guid id = Guid.Parse(predefinedMaterialId);
            _CreatePredefinedTaskMaterialVM.predefinedMaterialId = id;
            GrupoESIModels.PredefinedMaterial predefinedMaterial = _queries.GetPredefinedMaterialIncludePredefinedTaskServiceWherePredefinedMaterialIdEquals(id);
            _PredefinedTaskDescription.predefinedTaskName = predefinedMaterial.PredefinedTask.Name;
            _PredefinedTaskDescription.predefinedTaskCost = predefinedMaterial.PredefinedTask.Cost;
            _PredefinedTaskDescription.predefinedTaskDuration = predefinedMaterial.PredefinedTask.Duration;
            _PredefinedTaskDescription.predefinedTaskDescription = predefinedMaterial.Description;
            _PredefinedTaskDescription.serviceDescription = predefinedMaterial.PredefinedTask.Description;
            _PredefinedTaskDescription.serviceName = predefinedMaterial.PredefinedTask.Service.Name;
            _CreatePredefinedTaskMaterialVM.predefinedTaskMaterialName = predefinedMaterial.Name;
            _CreatePredefinedTaskMaterialVM.predefinedTaskMaterialDescription = predefinedMaterial.Description;
            _CreatePredefinedTaskMaterialVM.predefinedTaskMaterialCost = predefinedMaterial.Price;
            return Page();
        }
        public IActionResult OnPost()
        {
            PredefinedMaterial predefinedMaterial = _queries.GetPredefinedMaterialIncludePredefinedTaskServiceWherePredefinedMaterialIdEquals(_CreatePredefinedTaskMaterialVM.predefinedMaterialId);
            _predefinedMaterialRepository.Remove(predefinedMaterial);
            _queries.SaveChanges();
            PredefinedTask predefinedTask = _queries.GetPredefinedTaskIncludeServiceLstPredefinedMaterialWherePredefinedTaskIdEquals(predefinedMaterial.PredefinedTaskId);
            double localCost = 0.0;

            for (int i = 0; i < predefinedTask.ListPredefinedMaterial.Count(); i++)
            {
                localCost = +predefinedTask.ListPredefinedMaterial[i].Price;
            }
            predefinedTask.Cost = localCost + predefinedTask.CostHandLabor;
            _queries.SaveChanges();
            return RedirectToPage("ManagePredefinedTaskMaterial", new { predefinedTaskId = predefinedTask.PredefinedTaskId });
        }
    }
}
