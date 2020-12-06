using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrupoESIDataAccess.Queries;
using GrupoESIModels;
using GrupoESIModels.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GrupoESI.Pages.PredefinedTasks
{
    public class EditPredefinedTaskModel : PageModel
    {
        private readonly IQueries _queries;
        public EditPredefinedTaskModel(IQueries queries)
        {
            _queries = queries;
        }
        [BindProperty]
        public CreatePredefinedTaskMaterialDescriptionVM _createPredefinedTaskMaterialDescriptionVM  { get; set; }
        public IActionResult OnGet(string predefinedTaskId = null)
        {
            _createPredefinedTaskMaterialDescriptionVM = new CreatePredefinedTaskMaterialDescriptionVM();
            Guid id = Guid.Parse(predefinedTaskId);
            PredefinedTask predefinedTask = _queries.GetPredefinedTaskIncludeServiceLstPredefinedMaterialWherePredefinedTaskIdEquals(id);
            _createPredefinedTaskMaterialDescriptionVM.predefinedTaskId = id;
            _createPredefinedTaskMaterialDescriptionVM.serviceDescription = predefinedTask.Service.Description;
            _createPredefinedTaskMaterialDescriptionVM.serviceName = predefinedTask.Service.Name;
            _createPredefinedTaskMaterialDescriptionVM.predefinedTaskName = predefinedTask.Name;
            _createPredefinedTaskMaterialDescriptionVM.predefinedTaskDescription = predefinedTask.Description;
            _createPredefinedTaskMaterialDescriptionVM.predefinedTaskCost = predefinedTask.Cost;
            _createPredefinedTaskMaterialDescriptionVM.serviceId = predefinedTask.ServiceId;
            return Page();
        }
        public IActionResult OnPost()
        {
            PredefinedTask predefinedTask = _queries.GetPredefinedTaskIncludeServiceLstPredefinedMaterialWherePredefinedTaskIdEquals(_createPredefinedTaskMaterialDescriptionVM.predefinedTaskId);
            
            predefinedTask.Name = _createPredefinedTaskMaterialDescriptionVM.predefinedTaskName;
            predefinedTask.Description = _createPredefinedTaskMaterialDescriptionVM.predefinedTaskDescription;
            predefinedTask.Duration = _createPredefinedTaskMaterialDescriptionVM.predefinedTaskDuration;
            double costLocal = new double();
            for (int i = 0; i < predefinedTask.ListPredefinedMaterial.Count(); i++)
            {
                costLocal = costLocal +  predefinedTask.ListPredefinedMaterial[i].Price;
            }
            predefinedTask.Cost = costLocal + _createPredefinedTaskMaterialDescriptionVM.predefinedTaskCost;
            predefinedTask.CostHandLabor = _createPredefinedTaskMaterialDescriptionVM.predefinedTaskCost;
            _queries.SaveChanges();
            return RedirectToPage("PredefinedTaskIndex", new { serviceId = predefinedTask.ServiceId });
        }
    }
}
